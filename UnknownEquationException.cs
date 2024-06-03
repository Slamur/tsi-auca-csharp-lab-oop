namespace LaboratoryWork2
{
    internal class UnknownEquationException : Exception
    {
        public UnknownEquationException(int coefficientsLength)
            : base($"Unknown equation degree: {coefficientsLength - 1}")
        { }
    }
}
