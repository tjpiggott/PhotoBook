using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;
using Microsoft.Phone.Tasks;
using PhotoBook.BusinessObjects;

namespace PhotoBook.Views
{
    public partial class EditView : PhoneApplicationPage
    {
        private readonly MediaGallery mediaGallery;
        private readonly CameraCaptureTask takePic;
        private int numberOfAddedImages;

        public EditView()
        {
            InitializeComponent();
            mediaGallery = new MediaGallery(MediaGalleryCanvas);
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

            takePic = new CameraCaptureTask();
            takePic.Completed += TakePictureFromCameraCompleted;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.isDataLoaded)
            {
                App.ViewModel.loadData();
            }
        }

        void TakePictureFromCameraCompleted(object sender, PhotoResult photoResult)
        {
            if (photoResult.TaskResult == TaskResult.OK && photoResult.ChosenPhoto != null)
            {
                Stream photoStream = photoResult.ChosenPhoto;
                BitmapImage imageFromCamera = new BitmapImage();
                imageFromCamera.SetSource(photoStream);
                mediaGallery.addImageToGallery(imageFromCamera);

                var mediaLibrary = new MediaLibrary();
                photoStream.Position = 0;
                mediaLibrary.SavePicture("photoBookImage" + numberOfAddedImages, photoStream);
                numberOfAddedImages++;
            }
        }

        private void AddButtonPress(object sender, EventArgs e)
        {
            App.ViewModel.slideManager.addSlide();
        }

        private void CameraButtonPress(object sender, EventArgs e)
        {
            takePic.Show();
        }

        private void PlayButtonPress(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/PlayView.xaml", UriKind.Relative));
        }

        private void SettingsButtonPress(object sender, EventArgs e)
        {
            MessageBox.Show("Settings");
        }
    }
}