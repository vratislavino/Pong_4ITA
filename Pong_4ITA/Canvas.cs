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
    public partial class Canvas : UserControl
    {
        Ball ball;
        Paddle player1;
        Paddle player2;

        int initPaddleSize = 200;

        public Canvas() {
            InitializeComponent();
        }

        private void Canvas_Load(object sender, EventArgs e) {
            ball = new Ball(40, 10f, new PointF(Width / 2, Height / 2), new PointF(1,0));
            
            player1 = new Paddle(
                initPaddleSize, 
                6f, 
                Color.Blue, 
                new PointF(40, Height/2 - initPaddleSize/2), 
                Keys.W,
                Keys.S,
                Height
                );

            player2 = new Paddle(
                initPaddleSize,
                6f,
                Color.Red,
                new PointF(Width-40-40, Height / 2 - initPaddleSize / 2),
                Keys.O,
                Keys.L,
                Height
                );

            gameTimer.Start();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e) {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            ball.Draw(e.Graphics);
            player1.Draw(e.Graphics);
            player2.Draw(e.Graphics);
        }

        private void gameTimer_Tick(object sender, EventArgs e) {
            player1.Move();
            player2.Move();
            ball.Move();
            Refresh();
        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e) {
            if(player1.IsKeyForThisPaddle(e.KeyCode)) {
                player1.ChangeHoldingKey(e.KeyCode);
            }
            if (player2.IsKeyForThisPaddle(e.KeyCode)) {
                player2.ChangeHoldingKey(e.KeyCode);
            }
        }

        private void Canvas_KeyUp(object sender, KeyEventArgs e) {
            if (player1.IsKeyForThisPaddle(e.KeyCode)) {
                player1.ChangeHoldingKey(null);
            }
            if (player2.IsKeyForThisPaddle(e.KeyCode)) {
                player2.ChangeHoldingKey(null);
            }
        }
    }
}
