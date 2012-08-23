using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using PhotoBook.Models;

namespace PhotoBook.ViewModels
{
    public class EditViewModel : INotifyPropertyChanged
    {
        public SlideManager slideManager { get; private set; }
        public ObservableCollection<Slide> slides { get; private set; }
        public EditViewModel()
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
            slideManager.addSlide("title 1", "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", new BitmapImage(new Uri("../Images/SampleImages/sampleImage1.jpg", UriKind.RelativeOrAbsolute)));
            slideManager.addSlide("title 2", "Ultrices vehicula volutpat maecenas praesent accumsan bibendum", new BitmapImage(new Uri("../Images/SampleImages/sampleImage2.jpg", UriKind.RelativeOrAbsolute)));
            slideManager.addSlide("title 3", "Volutpat maecenas praesent accumsan bibendum pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula", new BitmapImage(new Uri("../Images/SampleImages/sampleImage3.jpg", UriKind.RelativeOrAbsolute)));
            slideManager.addSlide("title 4", "Sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum", new BitmapImage(new Uri("../Images/SampleImages/sampleImage4.jpg", UriKind.RelativeOrAbsolute)));
            slideManager.addSlide("title 5", "Maecenas praesent accumsan bibendum", new BitmapImage(new Uri("../Images/SampleImages/sampleImage5.jpg", UriKind.RelativeOrAbsolute)));

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