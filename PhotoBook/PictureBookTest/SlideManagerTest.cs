using NUnit.Framework;
using PhotoBook.Models;
using PhotoBook.ViewModels;

namespace PictureBookTest
{
    [TestFixture]
    public class SlideManagerTest
    {
        [Test]
        public void testAddSlide()
        {
            SlideManager manager = new SlideManager();
            manager.addSlide();
            
            Assert.AreEqual(1, manager.Slides.Count);

            manager.addSlide();
            Assert.AreEqual(2, manager.Slides.Count);

            manager.addSlide();
            Assert.AreEqual(3, manager.Slides.Count);
        }

        [Test]
        public void testGetSlide()
        {
            SlideManager manager = new SlideManager();
            int slideId = manager.addSlide();

            Assert.AreEqual(1, manager.Slides.Count);

            Slide slide = manager.getSlide(slideId);

            Assert.AreEqual(slideId, slide.id);
        }

        [Test]
        public void testRemoveSlide()
        {
            SlideManager manager = new SlideManager();
            int slideId = manager.addSlide();

            Assert.AreEqual(1, manager.Slides.Count);

            manager.removeSlide(slideId);

            Assert.AreEqual(0, manager.Slides.Count);
        }

    }
}
