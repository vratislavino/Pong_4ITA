using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong_4ITA
{
    internal class Paddle
    {
        private int width;
        private int height;

        private float speed;
        private Brush color;

        private PointF position;

        private Keys upKey; 
        private Keys downKey;

        private Keys? holdingKey;

        private int maxY;

        public Paddle(int height, float speed, Color color, PointF initialPosition, Keys up, Keys down, int maxY) {
            width = 40;
            this.height = height;
            this.speed = speed;
            this.color = new SolidBrush(color);
            position = initialPosition;
            this.maxY = maxY;

            this.upKey = up;
            this.downKey = down;
        }

        public void Draw(Graphics g) {
            g.FillRectangle(color, position.X, position.Y, width, height);
        }

        public bool IsKeyForThisPaddle(Keys k) {
            return k == upKey || k == downKey;
        }

        public void Move() {
            if(holdingKey.HasValue) {
                if (holdingKey.Value == upKey) {
                    TryToMove(-speed);
                } else {
                    TryToMove(speed);
                }
            }
        }

        private void TryToMove(float change) {
            var newY = position.Y + change;
            if(newY > 0 && newY < maxY - height) {
                position.Y = newY;
            }
        }

        public void ChangeHoldingKey(Keys? holdingKey) {
            this.holdingKey = holdingKey;
        }

    }

}
