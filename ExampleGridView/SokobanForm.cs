using FieldForm.API;
using FieldForm.Factory;

namespace ExampleGridView
{
    public partial class SokobanForm : Form
    {

        private IGridView gridView;
        private Sokoban.Game game = new Sokoban.Game();

        public SokobanForm()
        {            
            InitializeComponent();
            this.Text = "Sokoban";
            IGridView? createdView = GridFactory.CreateGridView(5, 5);
            if (createdView == null)
            {
                throw new ArgumentNullException("Unable to create GridView");
            }
            gridView = createdView;
            int[,] initArray = game.GetBackground();
            gridView.SetBackgroundWithArray(initArray);
            bool result = gridView.AddBitmapsFromFolder("graphics");
            if (!result)
            {
                MessageBox.Show("Error Reading Bitmaps!");
                Close();
                return;
            }

            gridView.RegisterObjects(game.DisplayObjects);            

            gridView.SetMarginLeftTop(50, 50);
            gridView.Init(this);
            gridView.Refresh();            
        }
    }
}
