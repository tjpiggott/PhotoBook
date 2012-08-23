using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace PhotoBook.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public SlideManager slideManager { get; private set; }
        public ObservableCollection<Slide> slides { get; private set; }
        public MainViewModel()
        {
            this.slideManager = new SlideManager();
            this.slides = slideManager.Slides;
        }

        public bool isDataLoaded
        {
            get;
            private set;
        }

        public void loadData()
        {
            slideManager.addSlide("title 1", "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", new BitmapImage(new Uri("Images/sampleImages/sampleImage1.jpg", UriKind.RelativeOrAbsolute)));
            slideManager.addSlide("title 2", "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", new BitmapImage(new Uri("Images/sampleImages/sampleImage2.jpg", UriKind.RelativeOrAbsolute)));
            slideManager.addSlide("title 3", "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", new BitmapImage(new Uri("Images/sampleImages/sampleImage3.jpg", UriKind.RelativeOrAbsolute)));
            slideManager.addSlide("title 4", "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", new BitmapImage(new Uri("Images/sampleImages/sampleImage4.jpg", UriKind.RelativeOrAbsolute)));
            slideManager.addSlide("title 5", "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", new BitmapImage(new Uri("Images/sampleImages/sampleImage5.jpg", UriKind.RelativeOrAbsolute)));

            this.isDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void notifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}