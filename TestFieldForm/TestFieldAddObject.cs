using FieldForm.API;
using FieldForm.Factory;

namespace TestFieldForm
{
    internal class TestFieldAddObject
    {

        [Test]
        public void TestAddingAnObject_WithCorrectValues_ItIsPresent()
        {
            // Arrange
            IGridView? result = GridFactory.CreateGridView(10, 10);
            Assert.That(result, Is.Not.Null);
            IField? field = result.GetField(3, 3);
            Assert.That(field, Is.Not.Null);

            // Act
            field.AddObject(2);

            // Assert
            IList<int> resultObjects = field.GetObjects();

            Assert.That(resultObjects.Count, Is.EqualTo(1));
            Assert.That(resultObjects[0], Is.EqualTo(2));            
        }

        [Test]
        public void TestAddingAnObject_WithNegativeValue_NothingIsAdded()
        {
            // Arrange
            IGridView? result = GridFactory.CreateGridView(10, 10);
            Assert.That(result, Is.Not.Null);
            IField? field = result.GetField(3, 3);
            Assert.That(field, Is.Not.Null);

            // Act
            field.AddObject(-2);

            // Assert
            IList<int> resultObjects = field.GetObjects();

            Assert.That(resultObjects.Count, Is.EqualTo(0));            
        }

        [Test]
        public void TestAddingAnObject_WithZeroValue_NothingIsAdded()
        {
            // Arrange
            IGridView? result = GridFactory.CreateGridView(10, 10);
            Assert.That(result, Is.Not.Null);
            IField? field = result.GetField(3, 3);
            Assert.That(field, Is.Not.Null);

            // Act
            field.AddObject(0);

            // Assert
            IList<int> resultObjects = field.GetObjects();

            Assert.That(resultObjects.Count, Is.EqualTo(0));            
        }

        
    }
}
