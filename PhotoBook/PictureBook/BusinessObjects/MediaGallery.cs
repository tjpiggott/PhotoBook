using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Xna.Framework.Media;

namespace PhotoBook.BusinessObjects
{
    public class MediaGallery
    {
        private readonly Canvas mediaGalleryCanvas;
        private int picturesInCurrentRow;
        private int numberOfCompleteRows;
        private int numberOfImages;
        private readonly Dictionary<Storyboard, string> animationDictionary;
        private const double WIDTH_OF_MEDIA_GALLERY_IMAGE = 170d;
        private const int SPACE_FROM_BOTTOM = 75;

        public MediaGallery(Canvas mediaGalleryCanvas)
        {
            this.mediaGalleryCanvas = mediaGalleryCanvas;
            buildGalleryFromPhoneMediaLibrary();
            animationDictionary = new Dictionary<Storyboard, string>();
        }

        private void buildGalleryFromPhoneMediaLibrary()
        {
            mediaGalleryCanvas.Width = WIDTH_OF_MEDIA_GALLERY_IMAGE * 3;

            MediaLibrary mediaLibrary = new MediaLibrary();
            PictureCollection pictureCollection = mediaLibrary.Pictures;
            picturesInCurrentRow = 0;
            numberOfCompleteRows = 0;
            numberOfImages = 0;
            List<Picture> picturesList = pictureCollection.ToList();
            picturesList.Reverse();

            foreach (Picture picture in picturesList)
            {
                BitmapImage image = new BitmapImage();
                image.SetSource(picture.GetImage());

                if (picturesInCurrentRow == 3)
                {
                    picturesInCurrentRow = 0;
                    numberOfCompleteRows++;
                    mediaGalleryCanvas.Height = (numberOfCompleteRows + 1) * WIDTH_OF_MEDIA_GALLERY_IMAGE + SPACE_FROM_BOTTOM;
                }
                addImageToGalleryCanvas(image, picturesInCurrentRow * WIDTH_OF_MEDIA_GALLERY_IMAGE, numberOfCompleteRows * WIDTH_OF_MEDIA_GALLERY_IMAGE);
            }
        }

        private void addImageToGalleryCanvas(BitmapImage bitmapImage, double positionFromLeft, double positionFromTop)
        {
            Image mediaGalleryItem = new Image
                                         {
                                             Source = bitmapImage,
                                             Width = 150,
                                             Height = 150,
                                             Name = "image" + numberOfImages
                                         };
            mediaGalleryItem.SetValue(Canvas.LeftProperty, positionFromLeft);
            mediaGalleryItem.SetValue(Canvas.TopProperty, positionFromTop);
            mediaGalleryItem.Tap += mediaGalleryPictureTapped;
            mediaGalleryCanvas.Children.Add(mediaGalleryItem);
            picturesInCurrentRow++;
            numberOfImages++;
        }


        private void mediaGalleryPictureTapped(object sender, GestureEventArgs gestureEventArgs)
        {
            if (sender is Image)
            {
                Image slideImage = (Image) sender;
                BitmapImage bitmapImage = (BitmapImage) slideImage.Source;
                App.ViewModel.slideManager.addSlide("slide title", "slide description", bitmapImage);
            }
        }

        public void addImageToGallery(BitmapImage imageToAdd)
        {
            foreach (var child in mediaGalleryCanvas.Children)
            {
                animateMove(child);
            }

            if (picturesInCurrentRow == 3)
            {
                picturesInCurrentRow = 0;
                numberOfCompleteRows++;
                mediaGalleryCanvas.Height = (numberOfCompleteRows + 1) * WIDTH_OF_MEDIA_GALLERY_IMAGE + SPACE_FROM_BOTTOM;
            }

            addImageToGalleryCanvas(imageToAdd, 0, 0);
        }

        private void animateMove(UIElement uiElement)
        {
            Duration duration = new Duration(TimeSpan.FromMilliseconds(2000));

            DoubleAnimation myDoubleAnimation1 = new DoubleAnimation();
            DoubleAnimation myDoubleAnimation2 = new DoubleAnimation();
            CubicEase easingFunction = new CubicEase {EasingMode = EasingMode.EaseInOut};
            myDoubleAnimation1.EasingFunction = easingFunction;
            myDoubleAnimation2.EasingFunction = easingFunction;

            myDoubleAnimation1.Duration = duration;
            myDoubleAnimation2.Duration = duration;

            Storyboard storyboard = new Storyboard();
            storyboard.Completed += removeStoryboard;
            storyboard.Duration = duration;

            storyboard.Children.Add(myDoubleAnimation1);
            storyboard.Children.Add(myDoubleAnimation2);

            Storyboard.SetTarget(myDoubleAnimation1, uiElement);
            Storyboard.SetTarget(myDoubleAnimation2, uiElement);

            Storyboard.SetTargetProperty(myDoubleAnimation1, new PropertyPath("(Canvas.Left)"));
            Storyboard.SetTargetProperty(myDoubleAnimation2, new PropertyPath("(Canvas.Top)"));

            double top = (double)uiElement.GetValue(Canvas.TopProperty);
            double left = (double)uiElement.GetValue(Canvas.LeftProperty);

            if (left.Equals(WIDTH_OF_MEDIA_GALLERY_IMAGE * 2))
            {
                left = 0;
                top += WIDTH_OF_MEDIA_GALLERY_IMAGE;
            }
            else
            {
                left += WIDTH_OF_MEDIA_GALLERY_IMAGE;
            }

            myDoubleAnimation1.To = left;
            myDoubleAnimation2.To = top;

            string animationName = "animation_" + uiElement.GetValue(Image.NameProperty);
            mediaGalleryCanvas.Resources.Add(animationName, storyboard);
            animationDictionary.Add(storyboard, animationName);

            storyboard.Begin();
        }

        private void removeStoryboard(object sender, EventArgs e)
        {
            Storyboard storyboard = (Storyboard) sender;
            string storyboardName = animationDictionary[storyboard];
            mediaGalleryCanvas.Resources.Remove(storyboardName);
        }
    }
}
