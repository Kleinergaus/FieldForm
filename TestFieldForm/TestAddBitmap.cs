using FieldForm.API;
using FieldForm.Factory;
using System.Drawing;

namespace TestFieldForm
{
    internal class TestAddBitmap
    {
        [Test]
        public void Test_AddBitmapWithIndex_ReturnsTheBitmap()
        {
            // Arrange
            IGridView? result = GridFactory.CreateGridView(10, 10);
            Assert.That(result, Is.Not.Null);
            Bitmap bitmap = new(10, 10);

            // Act
            result.AddBitmap(1, bitmap);

            // Assert
            Assert.That(result.GetBitmap(1), Is.EqualTo(bitmap));            
        }

        [Test]
        public void Test_AddBitmapWithNegativeIndex_ReturnsNull()
        {
            // Arrange
            IGridView? result = GridFactory.CreateGridView(10, 10);
            Assert.That(result, Is.Not.Null);
            Bitmap bitmap = new(10, 10);

            // Act
            result.AddBitmap(-1, bitmap);

            // Assert
            Assert.That(result.GetBitmap(-1), Is.Null);
        }

        [Test]
        public void Test_AddBitmapWitZeroIndex_ReturnsNull()
        {
            // Arrange
            IGridView? result = GridFactory.CreateGridView(10, 10);
            Assert.That(result, Is.Not.Null);
            Bitmap bitmap = new(10, 10);

            // Act
            result.AddBitmap(-1, bitmap);

            // Assert
            Assert.That(result.GetBitmap(-1), Is.Null);
        }

        [Test]
        public void Test_AddBitmap_GettingNotAddedOne_ReturnsNull()
        {
            // Arrange
            IGridView? result = GridFactory.CreateGridView(10, 10);
            Assert.That(result, Is.Not.Null);
            Bitmap bitmap = new(10, 10);

            // Act
            result.AddBitmap(1, bitmap);

            // Assert
            Assert.That(result.GetBitmap(2), Is.Null);
        }


        [Test]
        public void Test_AddBitmap_AddSameIndex_ReturnsSecondBitmap()
        {
            // Arrange
            IGridView? result = GridFactory.CreateGridView(10, 10);
            Assert.That(result, Is.Not.Null);
            Bitmap bitmap1 = new(10, 10);
            Bitmap bitmap2 = new(20, 20);

            // Act
            result.AddBitmap(1, bitmap1);
            result.AddBitmap(1, bitmap2);

            // Assert
            Assert.That(result.GetBitmap(1), Is.EqualTo(bitmap2));
        }
    }
}
