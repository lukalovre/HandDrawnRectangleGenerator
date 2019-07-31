﻿using System.Windows.Forms;

namespace HandDrawn
{
    public partial class Parameters : UserControl
    {
        public new int Width => (int)numericUpDownWidth.Value;

        public new int Height => (int)numericUpDownHeigth.Value;

        public Parameters()
        {
            InitializeComponent();
        }
    }
}