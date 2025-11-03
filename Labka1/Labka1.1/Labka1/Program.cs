
using System;
using System.Globalization;

class Program
{

    const double koma = 1e-9;

    static void Main()
    {
        Console.WriteLine("Перевірка попадання точки у заштриховану область");

        double x = ReadDouble("Введіть x: ");
        double y = ReadDouble("Введіть y: ");
        double R = ReadPositiveDouble("Введіть R: ");

        string result = CheckPoint(x, y, R);
        Console.WriteLine("Результат: " + result);
    }

    static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string s = Console.ReadLine();
            if (string.IsNullOrEmpty(s))
            {
                Console.WriteLine("Порожній ввід");
                continue;
            }


            if (double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out double v))
                return v;


            if (double.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out v))
                return v;

            Console.WriteLine("Некоректне число — введіть, будь ласка, ще раз.");
        }
    }

    static double ReadPositiveDouble(string prompt)
    {
        while (true)
        {
            double val = ReadDouble(prompt);
            if (val > 0.0)
                return val;
            Console.WriteLine("R має бути додатним числом");
        }
    }
    static string CheckPoint(double x, double y, double R)
    {
        double r2 = R * R;
        double leftCircle = (x + R) * (x + R) + y * y;
        double rightCircle = (x - R) * (x - R) + y * y;

        if (y >= 0)
        {
            if (leftCircle < r2)
                return "Так";
            else if (Math.Abs(leftCircle - r2) < koma)
                return "На межі";
        }

        if (y <= 0)
        {
            if (rightCircle < r2)
                return "Так";
            else if (Math.Abs(rightCircle - r2) < koma)
                return "На межі";
        }


        return "Ні";
    }
}
    


