using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Pong_4ITA
{
    internal class Ball
    {
        private int size;
        private Brush color;
        float speed;
        public float Speed { set { speed = value; } }

        PointF position;
        PointF direction; // normalized direction

        public Ball(int size, float speed, PointF initialPosition, PointF initialDirection) {
            color = new SolidBrush(Color.RebeccaPurple);
            this.size = size;
            this.speed = speed;
            position = initialPosition;
            direction = initialDirection.Normalize();
        }

        public void Draw(Graphics g) {
            g.FillEllipse(color, position.X - size / 2, position.Y - size / 2, size, size);
        }

        public void Move() {
            position.X += direction.X * speed;
            position.Y += direction.Y * speed;
        }

        public void ChangeDirection() {
            //direction = newDir.Normalize();
            direction.X *= -1;
        }
        
        public void CheckCollisionsWithWall(int height) {
            if(position.Y - size/2 <= 0) {
                // změna úhlu, náraz na horní stěnu
                direction.Y *= -1;

            }

            if(position.Y + size/2 >= height) {
                // změna úhlu, náraz na spodní stěnu
                direction.Y *= -1;
            }
        }

        public Point GetCheckPoint(bool isLeft) {
            return isLeft ? 
                new Point((int)position.X - size/2, (int) position.Y) : 
                new Point((int)position.X + size / 2, (int) position.Y);
        }

        internal bool? CheckLosing(int width) {
            var checkPoint = GetCheckPoint(position.X < width / 2);

            if (checkPoint.X < 0) return true; 
            if (checkPoint.X > width) return false;
            return null;
        }
    }
}
