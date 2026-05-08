using System;

namespace Vector {
    public readonly struct Vector3
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public static Vector3 Zero { get; } = new Vector3(0, 0, 0);

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        //magnitude is the length of the tridimensional vector, calculated using the Pythagorean theorem
        public double Magnitude() => Math.Sqrt(X * X + Y * Y + Z * Z);

        //pure direction vector with no magnitude, useful for normalization
        public Vector3 Normalize()
        {
            var mag = Magnitude();
            return mag == 0 ? Zero : this / mag;
        }

        //operators for vector addition, subtraction, scalar multiplication, and scalar division
        public static Vector3 operator +(Vector3 a, Vector3 b)
            => new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        public static Vector3 operator -(Vector3 a, Vector3 b)
            => new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        public static Vector3 operator *(Vector3 v, double scalar)
            => new Vector3(v.X * scalar, v.Y * scalar, v.Z * scalar);

        public static Vector3 operator *(double scalar, Vector3 v)
            => v * scalar;

        public static Vector3 operator /(Vector3 v, double scalar)
        {
            if (scalar == 0)
                throw new DivideByZeroException();

            return new Vector3(v.X / scalar, v.Y / scalar, v.Z / scalar);
        }
    }
}