using ProjectCleaner.CommonUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    { 
        #region [ Ctor ]
        public DialogWindow()
        {
            InitializeComponent();
        }
        public DialogWindow(string caption, string message)
        {
            InitializeComponent();
            txtCaption.Text = caption;
            txtMessage.Content = message;
        } 
        #endregion

        #region [ Events ]
        private void WindowCloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (Log.ExceptionOccured && chkShowErrors.IsChecked == true)
            {
                string file = System.IO.Path.Combine(Log.LogPath, AppConstants.LOGFILENAME);
                Process.Start(file);
                Log.ExceptionOccured = false;
            }
            Close();
        }

        private void OnDragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        } 
        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Log.ExceptionOccured)
            {
                chkShowErrors.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}
