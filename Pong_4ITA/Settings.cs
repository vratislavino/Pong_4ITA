using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong_4ITA
{
    public partial class Settings : Form
    {
        public string Name1 { get { return textBox1.Text; } }
        public string Name2 { get { return textBox2.Text; } }

        public int BallSpeed => hScrollBar1.Value;

        public Settings() {
            InitializeComponent();
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e) {
            label4.Text = hScrollBar1.Value.ToString();
        }
    }
}
