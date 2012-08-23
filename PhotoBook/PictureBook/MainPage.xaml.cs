using System;
using Microsoft.Phone.Controls;

namespace PhotoBook
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SettingsButtonPress(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/SettingsView.xaml", UriKind.Relative));
        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/EditView.xaml", UriKind.Relative));
        }
    }
}