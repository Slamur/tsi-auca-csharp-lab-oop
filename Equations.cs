namespace LaboratoryWork2
{
    internal static class Equations
    {
        static double[] Truncate(double[] coefficients)
        {
            int largestNonZero = -1;
            for (int i = coefficients.Length - 1; i >= 0; --i)
            {
                if (coefficients[i] != 0)
                {
                    largestNonZero = i;
                    break;
                }
            }

            double[] truncated = new double[largestNonZero + 1];
            Array.Copy(coefficients, truncated, truncated.Length);

            return truncated;
        }

        public static IEquation Create(double[] coefficients)
        {
            var truncated = Truncate(coefficients);
            var solver = Solvers.Select(truncated.Length);
            return new Equation(truncated, solver);
        }
    }
}
