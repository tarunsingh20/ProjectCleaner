using ProjectCleaner.CommonUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectCleaner.Forms
{
    /// <summary>
    /// Interaction logic for DialogBox.xaml
    /// </summary>
    public partial class DialogBox : Window
    {
        #region [ Constructors ]

        public DialogBox()
        {
            InitializeComponent();
        }

        public DialogBox(string message)
        {
            InitializeComponent();
            Message = message;
            this.Show();
        }

        #endregion

        #region [ Properties ]

        public string Message
        {
            set
            {
                lblMessage.Content = value;
            }
        }

        #endregion

        #region [ Events ]

        public static bool Show(string message)
        {
            DialogBox dialogBox = new DialogBox();
            dialogBox.Message = message;
            dialogBox.ShowDialog();
            if (dialogBox.DialogResult == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Show(string message, string title)
        {
            DialogBox dialogBox = new DialogBox();
            dialogBox.Message = message;
            dialogBox.Title = title;
            dialogBox.ShowDialog();
            if (dialogBox.DialogResult == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ShowError(string message)
        {
            DialogBox dialogBox = new DialogBox();
            dialogBox.Message = message;
            dialogBox.Title = AppConstants.MessageTypes.Error;
            dialogBox.btnCancel.Visibility = Visibility.Collapsed;
            dialogBox.ShowDialog();
        }

        public static void ShowInfo(string message)
        {
            DialogBox dialogBox = new DialogBox();
            dialogBox.Message = message;
            dialogBox.Title = AppConstants.MessageTypes.Information;
            dialogBox.btnCancel.Visibility = Visibility.Collapsed;
            dialogBox.ShowDialog();
        }

        public static void ShowWarning(string message)
        {
            DialogBox dialogBox = new DialogBox();
            dialogBox.Message = message;
            dialogBox.Title = AppConstants.MessageTypes.Warning;
            dialogBox.btnCancel.Visibility = Visibility.Collapsed;
            dialogBox.ShowDialog();
        }

        #endregion

        #region [ Private Methods ]

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion
    }
}
