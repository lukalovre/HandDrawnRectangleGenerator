using HandDrawn.Algorithm;
using System;
using System.Drawing;
using System.Windows.Forms;
using Random = HandDrawn.Algorithm.Random;

namespace HandDrawn
{
    public partial class Main : Form
    {
        private enum Algorithm
        {
            Straight,
            Random
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Draw(Algorithm algorithm)
        {
            using(Bitmap bitmap = new Bitmap(Parameters.Instance.Width, Parameters.Instance.Height + 2 * DrawTools.MaxDeviation))
            {
                using(Graphics graphics = Graphics.FromImage(bitmap))
                {
                    switch(algorithm)
                    {
                        case Algorithm.Straight:
                            Straight.Draw(graphics, Parameters.Instance.Width, Parameters.Instance.Height);
                            break;
                        case Algorithm.Random:
                            Random.Draw(graphics, Parameters.Instance.Width, Parameters.Instance.Height);
                            break;
                    }
                }

                IO.Save(bitmap, algorithm.ToString());
            }
        }

        private void PictureBox1Click(object sender, EventArgs e)
        {
            Draw(Algorithm.Straight);
            pictureBox1.ImageLocation = Algorithm.Straight.ToString();
        }

        private void PictureBox2Click(object sender, EventArgs e)
        {
            Draw(Algorithm.Random);
            pictureBox2.ImageLocation = Algorithm.Random.ToString();
        }
    }
}
