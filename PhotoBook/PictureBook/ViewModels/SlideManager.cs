using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace PhotoBook.ViewModels
{
    public class SlideManager
    {
        public readonly ObservableCollection<Slide> Slides = new ObservableCollection<Slide>();
        private int SlideIds;

        public SlideManager()
        {
            SlideIds = 0;
            Slides = new ObservableCollection<Slide>();
        }

        public int addSlide(){
            SlideIds++; 
            Slides.Add(new Slide(SlideIds));
            return SlideIds;
        }

        public int addSlide(string title, string description)
        {
            SlideIds++;
            Slides.Add(new Slide(SlideIds, title, description, null));
            return SlideIds;
        }

        public int addSlide(string title, string description, BitmapImage bitmapImage)
        {
            SlideIds++;
            Slides.Add(new Slide(SlideIds, title, description, bitmapImage));
            return SlideIds;
        }

        public Slide getSlide(int id) {
            foreach (Slide slide in Slides) {
                if (slide.id == id)
                    return slide;
            }
            return new Slide(-1);
        }

        public void removeSlide(int id) {
            Slides.Remove(getSlide(id));
        }

        public ObservableCollection<Slide> getAllSlides()
        {
            return Slides;
        }
    }
}
