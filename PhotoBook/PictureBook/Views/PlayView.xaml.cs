using System;
using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.Phone.Controls;
using PhotoBook.ViewModels;

namespace PhotoBook
{
    public partial class PlaySlidesPage : PhoneApplicationPage
    {
        public ObservableCollection<Slide> slides { get; private set; }

        public PlaySlidesPage()
        {
            InitializeComponent();
            loadPlayMode();
        }

        private void loadPlayMode()
        {
            slides = App.ViewModel.slideManager.getAllSlides();
            DataContext = slides;
        }

        private void goToEditMode(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void returnToMyDesk(object sender, EventArgs e)
        {
            MessageBox.Show("Return to myDesk");
        }
        
        private void submitPictureBook(object sender, EventArgs e)
        {
            MessageBox.Show("Submit PictureBook");
        }
    }
}