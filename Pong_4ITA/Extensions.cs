using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong_4ITA
{
    internal static class Extensions
    {
        public static PointF Normalize(this PointF vector) {
            var a = vector.X * vector.X;
            var b = vector.Y * vector.Y;

            var len = Math.Sqrt(a + b);

            return new PointF((float)(vector.X / len), (float)(vector.Y / len));
        }
    }
}
