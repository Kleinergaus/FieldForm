using FieldForm.API;
using FieldForm.Factory;

namespace TestFieldForm
{
    internal class TestGetField
    {
        [Test]
        public void Test_WithCorrectValues_ReturnsNotNullField()
        {
            IGridView? result = GridFactory.CreateGridView(10, 10);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.GetField(3, 2), Is.Not.Null);
        }

        //TODO what should happen with wrong values?
    }
}
