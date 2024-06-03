namespace LaboratoryWork2
{
    internal class Equation : IEquation
    {
        private readonly double[] _coefficients;
        private readonly ISolver _solver;

        public Equation(double[] coefficients, ISolver solver)
        {
            _coefficients = coefficients;
            _solver = solver;
        }

        public int Degree => _coefficients.Length - 1;

        public double[] GetCoefficients() => (double[])_coefficients.Clone();

        public Complex[] Solve() => _solver.Solve(GetCoefficients());
    }
}
