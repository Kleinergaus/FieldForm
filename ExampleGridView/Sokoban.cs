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
            for (int i = 0; i < 5; i++) { 
                initArray[i,0] = 2;
                initArray[i,4] = 2;
                initArray[0, i] = 2;
                initArray[4, i] = 2;
            }
            for (int i = 1; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    initArray[i, j] = 1;
                }
            }            
            gridView.SetBackgroundWithArray(initArray);
            bool result = gridView.AddBitmapsFromFolder("graphics");
            if (!result)
            {
                MessageBox.Show("Error Reading Bitmaps!");
                Close();
                return;
            }

            IField? field = gridView.GetField(1, 3);
            if (field == null)
            {
                MessageBox.Show("Error getting Field!");
                Close();
                return;
            }                   
            field.AddObject(4);


            field = gridView.GetField(1, 2);
            if (field == null)
            {
                MessageBox.Show("Error getting Field!");
                Close();
                return;
            }
            field.AddObject(5);

            field = gridView.GetField(2, 3);
            if (field == null)
            {
                MessageBox.Show("Error getting Field!");
                Close();
                return;
            }
            field.AddObject(5);

            field = gridView.GetField(3, 3);
            if (field == null)
            {
                MessageBox.Show("Error getting Field!");
                Close();
                return;
            }
            field.AddObject(3);

            gridView.SetMarginLeftTop(50, 50);
            gridView.Init(this);
            gridView.Refresh();
            
        }
    }
}
