using FieldForm.API;
using System.Drawing;
using System.Windows.Forms;


namespace FieldForm
{
    public class GridView : IGridView
    {

        private int marginPictureBoxX = 0;
        private int increasePictureBox = 64;
        private int marginPictureBoxY = 0;                

        public int Height { get; private set; }
        public int Width { get; private set; }

        private Field[,] Fields { get; set; }
        private PictureBox[,] boxes;


        private Dictionary<int, Bitmap> bitmaps = new Dictionary<int, Bitmap>();



        internal GridView(int width, int height)
        {
            Height = height;
            Width = width;
            Fields = new Field[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Fields[x, y] = new Field();
                }
            }

            boxes = new PictureBox[Width, Height];
            
        }

        public IField? GetField(int x, int y)
        {
            if (x < 0 || x >= Width)
            {
                return null;
            }
            if (y < 0 || y >= Height)
            {
                return null;
            }
            return Fields[x, y];
        }

        public void SetBackgroundWithArray(int[,] fields)
        {
            for (int x = 0;x < Width; x++)
            {
                for (int y = 0;y < Height; y++)
                {
                    Field field = Fields[x, y];
                    field.Background = fields[x, y];      
                }
            }            
        }

        public void AddBitmap(int index, Bitmap bitmap)
        {
            if (index <= 0 )
            {
                return;
            }
            if (bitmaps.ContainsKey(index))
            {
                bitmaps[index].Dispose();
                bitmaps[index] = bitmap;                
                return;
            }
            bitmaps.Add(index, bitmap);
        }

        public Bitmap? GetBitmap(int index)
        {
            if (bitmaps.ContainsKey(index))
            {
                return bitmaps[index];
            }
            return null;
        }

        public bool AddBitmapsFromFolder(string folder)
        {            
            string currentDir = Directory.GetCurrentDirectory();
            string folderDir = Path.Combine(currentDir, folder);
            bool exists = Path.Exists(folderDir);

            if (!exists)
            {
                return false;
            }

            var files = Directory.EnumerateFiles(folderDir);

            bool oneFileRead = false;
            int index = 1;
            foreach (string file in files)
            {
                if (file.EndsWith(".bmp")) {
                    try
                    {
                        Bitmap bitmap = new Bitmap(file);
                        AddBitmap(index, bitmap);
                        index++;
                        oneFileRead = true;
                    } catch
                    {
                        return false;
                    }
                }
            }

            return oneFileRead; 
        }
        
        public bool Init(Form form)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    boxes[x, y] = new PictureBox();
                    PictureBox box = new PictureBox();
                    box.Parent = form;
                    box.Location = new Point(marginPictureBoxX + x * increasePictureBox, marginPictureBoxY + y * increasePictureBox);
                    box.Size = new Size(increasePictureBox, increasePictureBox);
                    boxes[x, y] = box;
                    box.SizeMode = PictureBoxSizeMode.StretchImage;                    
                    box.Show();
                    form.Controls.Add(box);
                }
            }
            return true;
        }
        
        public bool Refresh()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int ii = 0; ii < Height; ii++)
                {
                    PictureBox box = boxes[i, ii];
                    Bitmap? bitmap = GetBitmap(Fields[i,ii].Background);
                    if (bitmap == null)
                    {
                        return false;
                    }
                    
                    box.Image = bitmap;

                    var objectsOnFiled = Fields[i, ii].GetObjects();
                    if (objectsOnFiled.Count>0)
                    {

                        Bitmap map = new Bitmap(64, 64);
                        Graphics g = Graphics.FromImage(map);

                        Bitmap bitmap2 = (Bitmap)bitmap.Clone();
                        g.DrawImage(bitmap2, 0, 0);

                        int first = objectsOnFiled[0];

                        Bitmap? map2 = GetBitmap(first);
                        if (map2 == null)
                        {
                            return false;
                        }
                        Bitmap map2Clone = (Bitmap)map2.Clone();
                        map2Clone.MakeTransparent(Color.White);
                        g.DrawImage(map2Clone, 0, 0);

                        box.Image = map;
                    }
                }
            }
            return true;
        }
    }
}
