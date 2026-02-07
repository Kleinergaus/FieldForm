using FieldForm.API;
using FieldForm.Factory;

namespace TestFieldForm
{
    internal class TestGetField
    {
        [Test]
        public void Test_WithCorrectValues_ReturnsNotNullField()
        {
            // Arrange
            IGridView? result = GridFactory.CreateGridView(10, 10);
            Assert.That(result, Is.Not.Null);

            // Act and Assert
            Assert.That(result.GetField(3, 2), Is.Not.Null);
        }

        [Test]
        public void Test_XNegative_ReturnsNullField()
        {
            // Arrange
            IGridView? result = GridFactory.CreateGridView(10, 10);
            Assert.That(result, Is.Not.Null);

            // Act and Assert
            Assert.That(result.GetField(-1, 2), Is.Null);
        }

        [Test]
        public void Test_YNegative_ReturnsNullField()
        {
            // Arrange
            IGridView? result = GridFactory.CreateGridView(10, 10);
            Assert.That(result, Is.Not.Null);

            // Act and Assert
            Assert.That(result.GetField(3, -2), Is.Null);
        }

        [Test]
        public void Test_XTooBig_ReturnsNullField()
        {
            // Arrange
            IGridView? result = GridFactory.CreateGridView(10, 10);
            Assert.That(result, Is.Not.Null);

            // Act and Assert
            Assert.That(result.GetField(10, 2), Is.Null);
        }

        [Test]
        public void Test_YTooBig_ReturnsNullField()
        {
            // Arrange
            IGridView? result = GridFactory.CreateGridView(10, 10);
            Assert.That(result, Is.Not.Null);

            // Act and Assert
            Assert.That(result.GetField(3, 10), Is.Null);
        }
    }
}
