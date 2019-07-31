using System;
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
            Algorithm1.Draw(Parameters.Instance.Width, Parameters.Instance.Height);
        }
    }
}
