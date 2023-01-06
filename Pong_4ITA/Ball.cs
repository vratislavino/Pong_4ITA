using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong_4ITA
{
    internal class Ball
    {
        private int size;
        private Brush color;
        float speed;

        PointF position;
        PointF direction; // normalized direction

        public Ball(int size, float speed, PointF initialPosition, PointF initialDirection) {
            color = new SolidBrush(Color.RebeccaPurple);
            this.size = size;
            this.speed = speed;
            position = initialPosition;
            direction = initialDirection;
        }

        public void Draw(Graphics g) {
            g.FillEllipse(color, position.X - size / 2, position.Y - size / 2, size, size);
        }

        public void Move() {
            position.X += direction.X * speed;
            position.Y += direction.Y * speed;
        }

        public void ChangeDirection(PointF newDir) {

        }
    }
}
