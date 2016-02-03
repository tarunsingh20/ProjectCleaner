using ProjectCleaner.CommonUtils;
using ProjectCleaner.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;

namespace ProjectCleaner.Forms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Read Application data file
            ReadAppData();
            //Verify Check box state
            VerifyCheckboxes();
            //Write verbose entry in log file
            Log.LogFileWrite();
        }

        #region [ Event Handlers ]

        private async void btnRefreshTree_Click(object sender, RoutedEventArgs e)
        {
            if (!txtFolderPath.Text.Trim().Equals(string.Empty))
            {
                await RefreshTree(txtFolderPath.Text);
                btnGenerate.IsEnabled = true;
            }
            else
            {
                lblMessage.Content = AppConstants.SELECT_FOLDER;
                lblMessage.Foreground = Brushes.IndianRed;

                btnSelect.Focus();
                btnGenerate.IsEnabled = false;

                await Task.Delay(3000);
                lblMessage.Content = "";
                lblMessage.Foreground = Brushes.Black;
            }
        }

        private void FileCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ContentPresenter contentPresenter = (ContentPresenter)((System.Windows.Controls.CheckBox)sender).TemplatedParent;

            if (contentPresenter.Content is FileItem)
            {
                TreeViewItem tv = (TreeViewItem)contentPresenter.TemplatedParent;

                UncheckParentFolder(tv);

                tvExplorer.Items.Refresh();
                tvExplorer.UpdateLayout();
            }
        }

        private async void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new FolderBrowserDialog();

                dialog.SelectedPath = txtFolderPath.Text;

                DialogResult result = dialog.ShowDialog();

                if (result.ToString().Equals(AppConstants.MessageTypes.OK))
                {
                    string path = dialog.SelectedPath;

                    txtFolderPath.Text = path;

                    await RefreshTree(path);

                    btnGenerate.IsEnabled = true;
                }
                else
                {
                    btnGenerate.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                Log.CaptureException(ex);
                Log.LogFileWrite();
            }
        }

        async void chkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            await VerifyAndRefreshTree();
        }

        async void chkBox_Checked(object sender, RoutedEventArgs e)
        {
            await VerifyAndRefreshTree();
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }

        private async void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VerifyCheckboxes();

                Helper.SelectedFoldersInTreeView = new List<string>();
                Helper.SelectedFilesInTreeView = new List<string>();

                ItemCollection collection = tvExplorer.Items;
                List<Item> Items = collection.Cast<Item>().ToList<Item>();
                VerifyFilesToClean(Items);

                if (!txtFolderPath.Text.Equals(string.Empty))
                {
                    string sourceDirectory = txtFolderPath.Text;

                    int index = sourceDirectory.LastIndexOf("\\");

                    string dirName = sourceDirectory.Substring(index + 1);

                    string targetDirectory = txtFolderPath.Text + "\\" + AppConstants.OUTPUT_DIRECTORY + dirName;

                    if (Helper.IsDirectoryExist(sourceDirectory))
                    {
                        lblMessage.Content = AppConstants.PLEASE_WAIT_FOLDER;
                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                        Helper.Copy(sourceDirectory, targetDirectory);

                        VSUnbind.Unbind(targetDirectory);

                        Log.LogFileWrite();

                        lblMessage.Content = AppConstants.PLEASE_WAIT_FILES;

                        if (chkZip.IsChecked == true)
                        {
                            Helper.ZipFiles(targetDirectory);

                            Directory.Delete(targetDirectory, true);
                        }

                        lblMessage.Content = "";
                        lblMessage.Foreground = Brushes.Black;
                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;

                        if (DialogBox.Show(AppConstants.CLEAN_SUCCESS) == true)
                        {
                            if (chkZip.IsChecked == true)
                            {
                                System.Diagnostics.Process.Start(AppConstants.EXPLORER, sourceDirectory);
                            }
                            else
                            {
                                System.Diagnostics.Process.Start(AppConstants.EXPLORER, targetDirectory);
                            }
                        }
                    }
                    else
                    {
                        DialogBox.ShowError(AppConstants.NO_SOURCE_DIR);
                        txtFolderPath.Text = "";
                        tvExplorer.ItemsSource = null;
                        tvExplorer.Items.Clear();
                    }
                }
                else
                {
                    lblMessage.Content = AppConstants.SELECT_FOLDER;
                    lblMessage.Foreground = Brushes.IndianRed;

                    btnSelect.Focus();

                    await Task.Delay(3000);
                    lblMessage.Content = "";
                    lblMessage.Foreground = Brushes.Black;
                }
            }
            catch (Exception ex)
            {
                Log.CaptureException(ex);
                Log.LogFileWrite();
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ContentPresenter contentPresenter = (ContentPresenter)((System.Windows.Controls.CheckBox)sender).TemplatedParent;

            if (contentPresenter.Content is DirectoryItem)
            {
                DirectoryItem di = (DirectoryItem)contentPresenter.Content;

                UnCheckAllItemsInDir(di);

                TreeViewItem tv = (TreeViewItem)contentPresenter.TemplatedParent;

                UncheckParentFolder(tv);

                tvExplorer.Items.Refresh();
                tvExplorer.UpdateLayout();
            }
            else if (contentPresenter.Content is FileItem)
            {
                FileItem fi = (FileItem)contentPresenter.Content;
                StackPanel s = (StackPanel)contentPresenter.Parent;

                int c = s.Children.Count;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ContentPresenter contentPresenter = (ContentPresenter)((System.Windows.Controls.CheckBox)sender).TemplatedParent;

            if (contentPresenter.Content is DirectoryItem)
            {
                DirectoryItem di = (DirectoryItem)contentPresenter.Content;

                CheckAllItemsInDir(di);

                tvExplorer.Items.Refresh();
            }
            else if (contentPresenter.Content is FileItem)
            {
                FileItem fi = (FileItem)contentPresenter.Content;
            }

        }

        #endregion

        #region [ Helper Methods ]

        private async Task RefreshTree(string path)
        {
            lblMessage.Content = AppConstants.PLEASE_WAIT_TREE;
            lblMessage.Foreground = Brushes.Black;
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

            Helper.GotException = false;

            var items = await Task.Run(() => ItemProvider.GetItems(path, false));

            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
            lblMessage.Content = "";

            if ((Helper.GotException) || (!Helper.FolderExist))
            {
                Log.LogFileWrite();
                DialogBox.ShowError(AppConstants.DIR_ERROR);
            }
            else
            {
                tvExplorer.DataContext = items;

                ItemCollection c = tvExplorer.Items;
                List<Item> Items = c.Cast<Item>().ToList<Item>();

                VerifyParentFolders(Items);
            }
        }

        private bool VerifyParentFolders(List<Item> Items)
        {
            bool allSubFilesChecked = true;

            foreach (Item item in Items)
            {
                if (item is DirectoryItem)
                {
                    DirectoryItem dir = (DirectoryItem)item;
                    if (dir.Items.Count > 0)
                    {
                        dir.Selected = VerifyParentFolders(dir.Items);

                        if (dir.Selected == false)
                        {
                            allSubFilesChecked = false;
                            break;
                        }
                    }
                }
                else if (item is FileItem)
                {
                    if (((FileItem)item).Selected == false)
                    {
                        allSubFilesChecked = false;
                        break;
                    }
                }
            }

            return allSubFilesChecked;
        }

        private void ReadAppData()
        {
            try
            {
                XmlDocument AppData = new XmlDocument();

                string xmlDocPath = Helper.GetAppDataXMLPath();

                if (!File.Exists(xmlDocPath))
                {
                    //build the file inline. This file can be edited later.
                    AppData.LoadXml("<?xml version=\"1.0\"?><ProjectCleaner><Folders><Folder name=\"bin\" checked=\"true\" />" +
                        "<Folder name=\"obj\" checked=\"true\" /><Folder name=\"TestResults\" checked=\"true\" /> " +
                        "<Folder name=\"_UpgradeReport_Files\" checked=\"true\" /></Folders>" +
                        "<FileExtensions><File extension=\".user\" checked=\"true\" /></FileExtensions>" +
                        "<File extension=\".webinfo\" checked=\"true\" /><File extension=\".user\" checked=\"true\" />" +
                        "<File extension=\".xap\" checked=\"true\" /><File extension=\".pdb\" checked=\"true\" />" +
                        "<File extension=\".zip\" checked=\"true\" /> <File extension=\".rar\" checked=\"true\" />" +
                        "<File extension=\".cache\" checked=\"true\" /></ProjectCleaner>");

                    XmlTextWriter writer = new XmlTextWriter(AppConstants.APP_DATA_XML, null);
                    writer.Formatting = Formatting.Indented;
                    AppData.Save(writer);

                    writer = null;
                }
                else
                {
                    AppData.Load(xmlDocPath);
                }

                XmlNodeList nodeList = AppData.ChildNodes[1].ChildNodes;

                if (nodeList.Count >= 2)
                {
                    foreach (XmlNode node in nodeList)
                    {
                        if (node.Name == AppConstants.AppDataNodesAttributes.Folders)
                        {
                            if (node.HasChildNodes)
                            {
                                XmlNodeList folderList = node.ChildNodes;

                                foreach (XmlNode folder in folderList)
                                {
                                    string name = folder.Attributes[AppConstants.AppDataNodesAttributes.Name].Value;
                                    string IsChecked = folder.Attributes[AppConstants.AppDataNodesAttributes.Checked].Value;

                                    System.Windows.Controls.CheckBox chkBox = new System.Windows.Controls.CheckBox();
                                    chkBox.Content = name;
                                    chkBox.FontSize = 14;
                                    chkBox.Checked += chkBox_Checked;
                                    chkBox.Unchecked += chkBox_Unchecked;

                                    if (IsChecked.ToLower().Equals(AppConstants.TRUE))
                                    {
                                        chkBox.IsChecked = true;
                                    }

                                    spFolders.Children.Add(chkBox);
                                }
                            }
                            else
                            {
                                DialogBox.ShowError(AppConstants.NO_FOLDER_NAMES);
                            }
                        }
                        else if (node.Name == AppConstants.AppDataNodesAttributes.FileExtensions)
                        {
                            if (node.HasChildNodes)
                            {
                                XmlNodeList fileExtensionList = node.ChildNodes;

                                System.Windows.Controls.CheckBox chBox = new System.Windows.Controls.CheckBox();
                                chBox.Content = AppConstants.SOURCE_CONTROL_BINDINGS;
                                chBox.FontSize = 14;
                                chBox.Checked += chkBox_Checked;
                                chBox.Unchecked += chkBox_Unchecked;
                                chBox.IsChecked = true;
                                spFiles.Children.Add(chBox);

                                foreach (XmlNode fileExt in fileExtensionList)
                                {
                                    string Extension = fileExt.Attributes[AppConstants.AppDataNodesAttributes.Extension].Value.ToLower();
                                    string IsChecked = fileExt.Attributes[AppConstants.AppDataNodesAttributes.Checked].Value;

                                    System.Windows.Controls.CheckBox chkBox = new System.Windows.Controls.CheckBox();

                                    chkBox.Content = Extension;
                                    chkBox.FontSize = 14;
                                    chkBox.Checked += chkBox_Checked;
                                    chkBox.Unchecked += chkBox_Unchecked;

                                    if (IsChecked.ToLower().Equals(AppConstants.TRUE))
                                    {
                                        chkBox.IsChecked = true;
                                    }

                                    spFiles.Children.Add(chkBox);
                                }
                            }
                            else
                            {
                                DialogBox.ShowError(AppConstants.NO_FILE_EXTENSIONS);
                            }
                        }
                    }
                }
                else
                {
                    // Folders or FileExtensions node is missing in the AppData.xml file.
                    DialogBox.ShowError(AppConstants.MISSING_NODES);
                }
            }
            catch (Exception ex)
            {
                // Code to log exception
                Log.CaptureException(ex);
            }
        }

        private async Task VerifyAndRefreshTree()
        {
            VerifyCheckboxes();

            string path = txtFolderPath.Text;

            if (!path.Trim().Equals(string.Empty))
            {
                await RefreshTree(path);
            }
        }

        private void VerifyCheckboxes()
        {
            try
            {
                Helper.ExcludedFiles = new Dictionary<string, bool>();
                Helper.ExcludedFolders = new Dictionary<string, bool>();

                foreach (var FolderName in spFolders.Children)
                {
                    System.Windows.Controls.CheckBox chk = (System.Windows.Controls.CheckBox)FolderName;

                    if (chk.IsChecked == true)
                    {
                        Helper.ExcludedFolders.Add(chk.Content.ToString(), true);
                    }
                    else
                    {
                        Helper.ExcludedFolders.Add(chk.Content.ToString(), false);
                    }
                }

                foreach (var FileName in spFiles.Children)
                {
                    System.Windows.Controls.CheckBox chk = (System.Windows.Controls.CheckBox)FileName;
                    if (chk.IsChecked == true)
                    {
                        if (chk.Content.ToString().Equals(AppConstants.SOURCE_CONTROL_BINDINGS))
                        {
                            Helper.ExcludedFiles.Add(".vssscc", true);
                        }
                        else
                        {
                            Helper.ExcludedFiles.Add(chk.Content.ToString(), true);
                        }
                    }
                    else
                    {
                        if (chk.Content.ToString().Equals(AppConstants.SOURCE_CONTROL_BINDINGS))
                        {
                            Helper.ExcludedFiles.Add(".vssscc", false);
                        }
                        else
                        {
                            Helper.ExcludedFiles.Add(chk.Content.ToString(), false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.CaptureException(ex);
            }
        }

        private static void CheckAllItemsInDir(DirectoryItem directoryItem)
        {
            List<Item> list = directoryItem.Items;

            directoryItem.Selected = true;

            foreach (Item item in directoryItem.Items)
            {
                if (item is DirectoryItem)
                {
                    CheckAllItemsInDir((DirectoryItem)item);
                }
                else
                {
                    item.Selected = true;
                }
            }
        }

        private static void UnCheckAllItemsInDir(DirectoryItem di)
        {
            List<Item> li = di.Items;

            di.Selected = false;

            foreach (Item i in di.Items)
            {
                if (i is DirectoryItem)
                {
                    UnCheckAllItemsInDir((DirectoryItem)i);
                }
                else
                {
                    i.Selected = false;
                }
            }
        }

        private static void UncheckParentFolder(TreeViewItem tv)
        {
            ItemsControl parent = ItemsControl.ItemsControlFromItemContainer(tv);
            if (parent != null)
            {
                if (parent is TreeViewItem)
                {
                    TreeViewItem tvi = (TreeViewItem)parent;

                    DirectoryItem di = (DirectoryItem)tvi.Header;

                    di.Selected = false;

                    UncheckParentFolder(tvi);
                }
            }
        }

        private void VerifyFilesToClean(List<Item> items)
        {
            foreach (Item node in items)
            {
                if (node is DirectoryItem)
                {
                    DirectoryItem dir = (DirectoryItem)node;
                    if ((dir).Selected == true)
                    {
                        Helper.SelectedFoldersInTreeView.Add(node.Path);
                    }

                    if (dir.Items.Count > 0)
                    {
                        VerifyFilesToClean(dir.Items);
                    }
                }
                else if (node is FileItem)
                {
                    if (node.Selected)
                    {
                        Helper.SelectedFilesInTreeView.Add(node.Path);
                    }
                }
            }
        }

        #endregion
    }
}
