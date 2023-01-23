using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong_4ITA
{
    internal class Paddle
    {
        private Rectangle rect;
        public Rectangle Rect => rect; 

        //private int width;
        //private int height;
        private int score;
        public int Score => score;

        private float speed;
        private Brush color;

        //private PointF position;

        private Keys upKey; 
        private Keys downKey;

        private List<Keys> holdingKeys;
        //private Keys? holdingKey;

        private int maxY;
        private bool isLeft;
        public bool IsLeft => isLeft;

        public Paddle(bool isLeft, int height, float speed, Color color, Point initialPosition, Keys up, Keys down, int maxY) {
            score = 0;
            this.isLeft = isLeft;
            rect = new Rectangle(initialPosition.X, initialPosition.Y, 40, height);
            this.speed = speed;
            this.color = new SolidBrush(color);
            this.maxY = maxY;

            holdingKeys = new List<Keys>();
            this.upKey = up;
            this.downKey = down;
        }

        public void AddScore() {
            score++;
        }

        public void Draw(Graphics g) {
            g.FillRectangle(color, rect);
        }

        public bool IsKeyForThisPaddle(Keys k) {
            return k == upKey || k == downKey;
        }

        public void Move() {
            if(holdingKeys.Count > 0) {
                var lastPressedKey = holdingKeys.Last();
                if (lastPressedKey == upKey) {
                    TryToMove(-speed);
                } else {
                    TryToMove(speed);
                }
            }
        }

        private void TryToMove(float change) {
            var newY = rect.Y + change;
            if(newY > 0 && newY < maxY - rect.Height) {
                rect.Y = (int)newY;
            }
        }

        public void AddHoldingKey(Keys key) { 
            if(!holdingKeys.Contains(key))
                holdingKeys.Add(key);
        }

        public void RemoveHoldingKey(Keys key) {
            if(holdingKeys.Contains(key))
                holdingKeys.Remove(key);
        }

        public bool CollidesWithBall(Ball ball) {
            return rect.Contains(ball.GetCheckPoint(isLeft));
        }

    }

}
