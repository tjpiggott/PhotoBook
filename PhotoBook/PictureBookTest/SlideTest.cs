using NUnit.Framework;
using PhotoBook.ViewModels;

namespace PictureBookTest
{
    [TestFixture]
    public class SlideTest
    {

        [Test]
        public void testSlideConstructors()
        {
            int expectedId = 1;
            Slide slide = new Slide(expectedId);
            Assert.AreEqual(expectedId, slide.id);

            expectedId = 72;
            string expectedTitle = "Awesome-o title";
            string expectedDescription = "Totally rockin' description";
            slide = new Slide(expectedId, expectedTitle, expectedDescription, null);
            Assert.AreEqual(expectedId, slide.id);
            Assert.AreEqual(expectedTitle, slide.title);
            Assert.AreEqual(expectedDescription, slide.description);
        }
    }
}
