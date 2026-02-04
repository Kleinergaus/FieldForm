using FieldForm.API;
using FieldForm.Factory;

namespace TestFieldForm
{
    internal class TestGridViewSetBackgroundArray
    {

        [Test]
        public void TestGridView_SetBackgroundWithArray_BackgroundTilesAreSet()
        {
            IGridView? result = GridFactory.CreateGridView(3, 3);
            int[,] tileArray = new int[3,3];
            tileArray[0,0] = 1;
            tileArray[0,1] = 2;
            tileArray[0,2] = 3;
            tileArray[1,0] = 4;
            tileArray[1,1] = 5;
            tileArray[1,2] = 6;
            tileArray[2,0] = 7;
            tileArray[2,1] = 8;
            tileArray[2,2] = 9;

            Assert.That(result, Is.Not.Null);
            
            result.SetBackgroundWithArray(tileArray);
            int expected = 1;
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    IField? field = result.GetField(i, j);
                    Assert.That(field, Is.Not.Null) ;
                    Assert.That(field.Background, Is.EqualTo(expected));
                    expected++;
                }
            }            
        }
    }
}
