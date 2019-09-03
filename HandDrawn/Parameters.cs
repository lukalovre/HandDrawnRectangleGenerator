using System.Windows.Forms;

namespace HandDrawn
{
    public partial class Parameters : UserControl
    {
        public new int Width
        {
            get
            {
                return (int)numericUpDownWidth.Value;
            }
            set
            {
                numericUpDownWidth.Value = value;
            }
        }

        public new int Height
        {
            get
            {
                return (int)numericUpDownHeigth.Value;
            }
            set
            {
                numericUpDownHeigth.Value = value;
            }
        }
        public static Parameters Instance;

        public Parameters()
        {
            InitializeComponent();

            Instance = this;
        }
    }
}
