using LaboratoryWork2;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        int coefficientsCount = (int)ReadDouble("количество коэффициентов");

        Console.WriteLine("Вводите коэффициенты по одному в строке, в порядке от младшего к старшему");

        double[] coefficients = new double[coefficientsCount];
        for (int i = 0; i < coefficients.Length; i++)
        {
            coefficients[i] = ReadDouble($"коэффициент[{i}]");
        }

        try
        {

            var equation = Equations.Create(coefficients);

            var roots = equation.Solve();

            Console.WriteLine($"Найдено {roots.Length} корней уравнения");
            foreach (var root in roots) Console.WriteLine(root);
        } 
        catch (InfiniteRootsException ex)
        {
            Console.WriteLine("Введённое уравнение имеет бесконечное число решений");
        }
        catch (NoRootsException ex)
        {
            Console.WriteLine("Введённое уравнение не имеет комплексных корней");
        }
        catch (UnknownEquationException ex)
        {
            Console.WriteLine($"Уравнение решить не получилось: {ex.Message}");
        }
    }

    private static double ReadDouble(string name)
    {
        while (true)
        {
            Console.WriteLine($"Введите {name}: "); ;

            string input = Console.ReadLine();

            double value;
            if (Double.TryParse(input, out value)) return value;

            Console.WriteLine("Повторите попытку ввода");
        }
    }
}