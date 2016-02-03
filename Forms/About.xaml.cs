using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace ProjectCleaner.Forms
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // TODO: Add the email address and subject
            Process.Start("mailto:sudhakarreddy.pr@hotmail.com;tarunsingh20@gmail.com;zubair.m.ahmed@hotmail.com?Subject=Feedback on Project Cleaner version 1.0");
            this.Close();
        }

        private void CloseForm(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
