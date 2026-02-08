using FieldForm.API;
using FieldForm.Factory;


namespace TestFieldForm
{
    internal class TestCreateBitmapFromFolder
    {        

        [Test]
        public void FolderNotExisting_ReturnsFalse()
        {
            // Arrange
            IGridView? gridView = GridFactory.CreateGridView(5, 5);
            Assert.That(gridView, Is.Not.Null);

            // Act
            bool result = gridView.AddBitmapsFromFolder("TestInputData\\Bitmaps\\NotExisting");

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void FolderExistingButNoBitmaps_ReturnsFalse()
        {
            // Arrange
            IGridView? gridView = GridFactory.CreateGridView(5, 5);
            Assert.That(gridView, Is.Not.Null);

            // Act
            bool result = gridView.AddBitmapsFromFolder("TestInputData\\Bitmaps\\Empty");

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void FolderExisting_ReturnsTrueAndBitmapsAreCreated()
        {
            // Arrange
            IGridView? gridView = GridFactory.CreateGridView(5, 5);
            Assert.That(gridView, Is.Not.Null);

            // Act
            bool result = gridView.AddBitmapsFromFolder("TestInputData\\Bitmaps\\FolderWithBitmaps");

            // Assert
            Assert.That(result, Is.True);
            Assert.That(gridView.GetBitmap(1), Is.Not.Null);
            Assert.That(gridView.GetBitmap(2), Is.Not.Null);
            Assert.That(gridView.GetBitmap(3), Is.Not.Null);
            Assert.That(gridView.GetBitmap(4), Is.Not.Null);
            Assert.That(gridView.GetBitmap(5), Is.Not.Null);

        }
    }
}
