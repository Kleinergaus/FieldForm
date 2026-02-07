using FieldForm.API;
using FieldForm.Factory;

namespace ExampleGridView
{
    public partial class Sokoban : Form
    {

        private IGridView gridView;


        public Sokoban()
        {            
            InitializeComponent();
            this.Text = "Sokoban";
            IGridView? createdView = GridFactory.CreateGridView(5, 5);
            if (createdView == null)
            {
                throw new ArgumentNullException("Unable to create GridView");
            }
            gridView = createdView;
            int[,] initArray = new int[5,5];
            for (int i = 1; i < 5; i++) { 
                initArray[i,0] = i;
                initArray[i,4] = i;
                initArray[0, i] = i;
                initArray[4, i] = i;
            }
            for (int i = 1; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    initArray[i, j] = 1;
                }
            }
            gridView.SetBackgroundWithArray(initArray);

        }
    }
}
