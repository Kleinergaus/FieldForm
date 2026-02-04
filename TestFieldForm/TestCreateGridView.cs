using FieldForm.API;
using FieldForm.Factory;

namespace TestFieldForm
{
    public class TestCreateGridView
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_WithNegativeWidth_ReturnsNull()
        {
            IGridView? result = GridFactory.CreateGridView(-5, 10);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Test_WithZeroWidth_ReturnsNull()
        {
            IGridView? result = GridFactory.CreateGridView(0, 10);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Test_WithNegativeHeight_ReturnsNull()
        {
            IGridView? result = GridFactory.CreateGridView(10, -12);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Test_WithZeroHeight_ReturnsNull()
        {
            IGridView? result = GridFactory.CreateGridView(10, 0);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Test_WithCorrectValues_ReturnsGridViewWithCorrectWidthAndHeight()
        {
            IGridView? result = GridFactory.CreateGridView(25, 22);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Width, Is.EqualTo(25));
            Assert.That(result.Height, Is.EqualTo(22));
        }
       
    }
}
