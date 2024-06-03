namespace LaboratoryWork2
{
    internal interface IEquation
    {
        int Degree {  get; }

        double[] GetCoefficients();

        Complex[] Solve();
    }
}
