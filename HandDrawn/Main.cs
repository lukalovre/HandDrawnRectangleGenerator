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
            Random,
            RandomWithPause
        }

        public Main()
        {
            InitializeComponent();

            PictureBoxClick(null, null);
        }

        private void Draw(Algorithm algorithm, int amount = 1)
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
                        case Algorithm.RandomWithPause:
                            RandomWithPause.Draw(graphics, Parameters.Instance.Width, Parameters.Instance.Height, amount);
                            break;
                    }
                }

                IO.Save(bitmap, algorithm.ToString() + amount);
            }
        }

        private void PictureBoxClick(object sender, EventArgs e)
        {
            int amount = 1;
            Draw(Algorithm.RandomWithPause, amount);
            pictureBox.ImageLocation = Algorithm.RandomWithPause.ToString() + amount + IO.ImageFormatString;
        }

        private void ButtonGenerateClick(object sender, EventArgs e)
        {
            PictureBoxClick(null, null);
        }
    }
}
