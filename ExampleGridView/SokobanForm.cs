using FieldForm.API;
using FieldForm.Factory;

namespace ExampleGridView
{
    public partial class SokobanForm : Form
    {

        private IGridView gridView;
        private Sokoban.Game game = new Sokoban.Game();

        Button buttonUp;
        Button buttonDown;
        Button buttonLeft;
        Button buttonRight;

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

            Button buttonUp = new Button();
            buttonUp.Text = "Up";
            buttonUp.Top = 50;
            buttonUp.Left = 500;
            buttonUp.Parent = this;
            buttonUp.Show();
            buttonUp.Click += ButtonUp_Click;


            Button buttonDown = new Button();
            buttonDown.Text = "Down";
            buttonDown.Top = 150;
            buttonDown.Left = 500;
            buttonDown.Parent = this;
            buttonDown.Show();
            buttonDown.Click += ButtonDown_Click;

            Button buttonLeft = new Button();
            buttonLeft.Text = "Left";
            buttonLeft.Top = 100;
            buttonLeft.Left = 400;
            buttonLeft.Parent = this;
            buttonLeft.Show();
            buttonLeft.Click += ButtonLeft_Click;


            Button buttonRight = new Button();
            buttonRight.Text = "Right";
            buttonRight.Top = 100;
            buttonRight.Left = 600;
            buttonRight.Parent = this;
            buttonRight.Show();
            buttonRight.Click += ButtonRight_Click;

            gridView.SetMarginLeftTop(50, 50);
            gridView.Init(this);
            gridView.Refresh();
        }

        private void ButtonUp_Click(object? sender, EventArgs e)
        {
            game.Move(1);
            gridView.Refresh();            
        }

        private void ButtonDown_Click(object? sender, EventArgs e)
        {
            game.Move(3);
            gridView.Refresh();
        }


        private void ButtonRight_Click(object? sender, EventArgs e)
        {
            game.Move(2);
            gridView.Refresh();
        }


        private void ButtonLeft_Click(object? sender, EventArgs e)
        {
            game.Move(4);
            gridView.Refresh();
        }


    }
}
