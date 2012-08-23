using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace PhotoBook.ViewModels
{
    public class Slide : INotifyPropertyChanged
    {
        
        public Slide(int id, string title, string description, BitmapImage image) {
            idProperty = id;
            titleProperty = title;
            descriptionProperty = description;
            imageProperty = image;
        }

        public Slide(int id) {
            idProperty = id;
            titleProperty = "Slide Title";
            descriptionProperty = "Slide Description";
            imageProperty = null;
        }

        private int idProperty;
        public int id
        {
            get
            {
                return idProperty;
            }
            set
            {
                if (value != idProperty)
                {
                    idProperty = value;
                    notifyPropertyChanged("id");
                }
            }
        }

        private string titleProperty;
        public string title
        {
            get
            {
                return titleProperty;
            }
            set
            {
                if (value != titleProperty)
                {
                    titleProperty = value;
                    notifyPropertyChanged("title");
                }
            }
        }

        private string descriptionProperty;
        public string description
        {
            get
            {
                return descriptionProperty;
            }
            set
            {
                if (value != descriptionProperty)
                {
                    descriptionProperty = value;
                    notifyPropertyChanged("description");
                }
            }
        }

        private BitmapImage imageProperty;
        public BitmapImage image
        {
            get
            {
                return imageProperty;
            }
            set
            {
                if (value != imageProperty)
                {
                    imageProperty = value;
                    notifyPropertyChanged("description");
                }
            }
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
