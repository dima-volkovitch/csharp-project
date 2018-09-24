using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Сводное описание для Calculator
/// </summary>
public class Calculator
{
    public static double GetDiscriminant(double a, double b, double c)
    {
        return b * b - 4 * a * c;
    }

    public static double GetFirstSolution(double a, double b, double discriminant)
    {
        return ((-b) + Math.Sqrt(discriminant)) / (2 * a);
    }

    public static double GetSecondSolution(double a, double b, double discriminant)
    {
        return ((-b) - Math.Sqrt(discriminant)) / (2 * a);
    }

    public static string[] GetAnswer(double a, double b, double c)
    {
        double discriminant = GetDiscriminant(a, b, c);
        if (discriminant >= 0)
        {
            return new string[] { GetFirstSolution(a, b, discriminant).ToString(),
                GetSecondSolution(a, b, discriminant).ToString() };
        }
        string str = Math.Sqrt(-discriminant) + "i";
        //string firstSolution = string.Format("({0} + {1}))/(2 * {2})", a, str, b);
        //string secondSolution = firstSolution.Replace('+', '-');
        //return new string[] { firstSolution, secondSolution };
        return new string[] { "d", "d" };
    }
}