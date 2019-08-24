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

            PictureBox1Click(null, null);
            PictureBox2Click(null, null);
            PictureBox3Click(null, null);
            PictureBox4Click(null, null);
            PictureBox5Click(null, null);
            PictureBox6Click(null, null);
            PictureBox7Click(null, null);
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

        private void PictureBox1Click(object sender, EventArgs e)
        {
            Draw(Algorithm.Straight);
            pictureBox1.ImageLocation = Algorithm.Straight.ToString() + 1 + IO.ImageFormatString;
        }

        private void PictureBox2Click(object sender, EventArgs e)
        {
            Draw(Algorithm.RandomWithPause, 1);
            pictureBox2.ImageLocation = Algorithm.RandomWithPause.ToString() + 1 + IO.ImageFormatString;
        }

        private void PictureBox3Click(object sender, EventArgs e)
        {
            Draw(Algorithm.RandomWithPause, 2);
            pictureBox3.ImageLocation = Algorithm.RandomWithPause.ToString() + 2 + IO.ImageFormatString;
        }

        private void PictureBox4Click(object sender, EventArgs e)
        {
            Draw(Algorithm.RandomWithPause, 5);
            pictureBox4.ImageLocation = Algorithm.RandomWithPause.ToString() + 5 + IO.ImageFormatString;
        }

        private void PictureBox5Click(object sender, EventArgs e)
        {
            Draw(Algorithm.RandomWithPause, 10);
            pictureBox5.ImageLocation = Algorithm.RandomWithPause.ToString() + 10 + IO.ImageFormatString;
        }

        private void PictureBox6Click(object sender, EventArgs e)
        {
            Draw(Algorithm.RandomWithPause, 25);
            pictureBox6.ImageLocation = Algorithm.RandomWithPause.ToString() + 25 + IO.ImageFormatString;
        }

        private void PictureBox7Click(object sender, EventArgs e)
        {
            Draw(Algorithm.RandomWithPause, 50);
            pictureBox7.ImageLocation = Algorithm.RandomWithPause.ToString() + 50 + IO.ImageFormatString;
        }

        private void ButtonGenerateClick(object sender, EventArgs e)
        {
            PictureBox1Click(null, null);
            PictureBox2Click(null, null);
            PictureBox3Click(null, null);
            PictureBox4Click(null, null);
            PictureBox5Click(null, null);
            PictureBox6Click(null, null);
            PictureBox7Click(null, null);
        }
    }
}
