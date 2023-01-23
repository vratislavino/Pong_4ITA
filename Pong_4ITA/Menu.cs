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
    public partial class Menu : Form
    {
        SettingsData settingsData = new SettingsData() { 
            player1 = "Pepa",
            player2 = "Hildegard",
            ballSpeed = 15
        };

        public Menu() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Form1 game = new Form1(settingsData);
            game.Show();
            this.Hide();
            game.FormClosing += (snd, evt) => {
                this.Show();
            };
        }

        private void button2_Click(object sender, EventArgs e) {
            MessageBox.Show("Ovládáním pomocí WS a OL pohybujete plošinkami, abyste neupustili míček...");
        }

        private void button3_Click(object sender, EventArgs e) {
            Settings settings = new Settings();
            settings.ShowDialog();
            settingsData.player1 = settings.Name1;
            settingsData.player2 = settings.Name2;
            settingsData.ballSpeed = settings.BallSpeed;

        }

        private void button4_Click(object sender, EventArgs e) {
            if (DialogResult.Yes == MessageBox.Show("Opravdu?", "Potvrzení", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) {
                Application.Exit();
            }
        }
    }
}
