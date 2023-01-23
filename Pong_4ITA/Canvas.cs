using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        int ballSpeed;

        public event Action<int, int> ScoreChanged;

        bool gameStarted = false;

        public Canvas() {
            InitializeComponent();
        }

        public void StopGame() {
            gameTimer.Stop();
        }

        private void Canvas_Load(object sender, EventArgs e) {
            ball = new Ball(40, ballSpeed, new PointF(Width / 2, Height / 2), GetRandomVector());
            
            player1 = new Paddle(
                true,
                initPaddleSize, 
                16f, 
                Color.Blue, 
                new Point(40, Height/2 - initPaddleSize/2), 
                Keys.W,
                Keys.S,
                Height
                );

            player2 = new Paddle(
                false,
                initPaddleSize,
                16f,
                Color.Red,
                new Point(Width-40-40, Height / 2 - initPaddleSize / 2),
                Keys.O,
                Keys.L,
                Height
                );

            //gameTimer.Start();
        }

        private void AddScore(Paddle losingPaddle) {
            var winning = losingPaddle == player1 ? player2 : player1;
            winning.AddScore();
            ScoreChanged?.Invoke(player1.Score, player2.Score);
        }

        private PointF GetRandomVector() {
            Random r = new Random();
            int yMove = r.Next(-3, 3);
            //yMove = -40;
            if (r.Next(2) == 0) {
                return new PointF(-5, yMove);
            } else {
                return new PointF(5, yMove);
            }
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

            ball.CheckCollisionsWithWall(Height);
            if(player1.CollidesWithBall(ball)) {
                ball.ChangeDirection(player1);
            }
            if (player2.CollidesWithBall(ball)) {
                ball.ChangeDirection(player2);
            }
            var losing = ball.CheckLosing(Width);
            if (losing.HasValue) {
                bool leftPaddleLostBall = losing.Value;
                //gameTimer.Stop();
                //MessageBox.Show(leftPaddleLostBall + "");
                
                if (leftPaddleLostBall) { 
                    AddScore(player1);
                } else {
                    AddScore(player2);
                }
                ball.Reset(new PointF(Width / 2, Height / 2), GetRandomVector());
                gameTimer.Stop();
                gameStarted = false;
            }
            Refresh();
        }



        private void Canvas_KeyDown(object sender, KeyEventArgs e) {

            if(e.KeyCode == Keys.Space) {
                gameTimer.Start();
                gameStarted = true;
            }

            if (!gameStarted)
                return;

            if(player1.IsKeyForThisPaddle(e.KeyCode)) {
                player1.AddHoldingKey(e.KeyCode);
            }
            if (player2.IsKeyForThisPaddle(e.KeyCode)) {
                player2.AddHoldingKey(e.KeyCode);
            }
        }

        private void Canvas_KeyUp(object sender, KeyEventArgs e) {
            if (player1.IsKeyForThisPaddle(e.KeyCode)) {
                player1.RemoveHoldingKey(e.KeyCode);
            }
            if (player2.IsKeyForThisPaddle(e.KeyCode)) {
                player2.RemoveHoldingKey(e.KeyCode);
            }
        }

        internal void SetBallSpeed(int ballSpeed) {
            this.ballSpeed = ballSpeed;
        }
    }
}
