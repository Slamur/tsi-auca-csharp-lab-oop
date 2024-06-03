namespace LaboratoryWork2
{
    internal class Complex
    {

        public static readonly Complex ZERO = new Complex();
        
        public static readonly Complex ONE = new Complex(1);

        public static readonly Complex IMAGINARY_ONE = new Complex(0, 1);

        public static Complex Re(double x) => new Complex(x);

        public static Complex Im(double y) => new Complex(0, y);

        public static Complex Sqrt(double square)
        {
            double root = Math.Sqrt(Math.Abs(square));
            return square >= 0 ? Re(root) : Im(root);
        }

        public Complex(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Complex(double x) : this(x, 0) { }

        public Complex() : this(0) { }
        public double X { get; }
        public double Y { get; }

        public double Length
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y);
            }
        }

        public static Complex operator +(Complex left, Complex right)
            => new Complex(left.X + right.X, left.Y + right.Y);
        public static Complex operator -(Complex left, Complex right)
            => new Complex(left.X - right.X, left.Y - right.Y);
        public static Complex operator *(Complex left, Complex right)
        {
            double x = left.X * right.X - left.Y * right.Y;
            double y = left.Y * right.X + left.X * right.Y;
            return new Complex(x, y);
        }

        public static Complex operator /(Complex left, Complex right)
        {
            double rightLength = right.Length;
            if (rightLength == 0)
            {
                throw new DivideByZeroException(
                    $"Expected right with non-zero length, but found {right} with length {rightLength}"
                );
            }

            double rightLengthSquare = rightLength * rightLength;

            double x = left.X * right.X + left.Y * right.Y;
            double y = left.Y * right.X - left.X * right.Y;
            return new Complex(x / rightLengthSquare, y / rightLengthSquare);
        }

        public static Complex operator +(Complex c) => c;

        public static Complex operator -(Complex c) => new Complex(-c.X, -c.Y);

        public override string ToString()
        {
            return $"({X} + i * {Y})";
        }

        public override int GetHashCode()
        {
            int xh = X.GetHashCode(), yh = Y.GetHashCode();
            return (xh * yh) + (xh ^ yh);
        }

        public override bool Equals(object? obj)
        {
            var other = obj as Complex;
            if (null == other) { return false; }

            if (this == other) { return true; }

            if (this.GetHashCode() != other.GetHashCode()) { return false; }

            return this.X == other.X && this.Y == other.Y;
        }
    }
}
