using System;
using System.Drawing;
using System.Windows.Forms;

namespace HandDrawn
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void ButtonGenerateClick(object sender, EventArgs e)
        {
            Draw();

            pictureBoxResult.ImageLocation = IO.FileName;
        }

        private void Draw()
        {
            using(Bitmap bitmap = new Bitmap(Parameters.Instance.Width, Parameters.Instance.Height + 2 * DrawTools.MaxDeviation))
            {
                using(Graphics graphics = Graphics.FromImage(bitmap))
                {
                    Algorithm1.Draw(graphics, Parameters.Instance.Width, Parameters.Instance.Height);
                }

                IO.Save(bitmap);
            }
        }
    }
}
