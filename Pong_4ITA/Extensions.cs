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

        public static float Remap(this float value, float from1, float to1, float from2, float to2) {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        public static float ConvertDegreesToRadians(this float degrees) {
            float radians = (float)(Math.PI / 180) * degrees;
            return radians;
        }
    }
}
