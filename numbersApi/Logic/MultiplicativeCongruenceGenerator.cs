namespace numbersApi.Logic
{
    using System;
using System.Collections.Generic;

public class MultiplicativeCongruenceGenerator
{
    // Método principal que genera la tabla
    public static List<List<object>> CalculateMethod(int x0, int t, int g, int iteraciones, double minValue, double maxValue)
    {
        var table = new List<List<object>>();
        int xi = x0;
        var riOutput = new List<double>();
        var niOutput = new List<double>();

        for (int i = 0; i < iteraciones; i++)
        {
            xi = CalculateXi(xi, t, g);
            double ri = CalculateRi(xi, g);
            double ni = CalculateNi(minValue, maxValue, ri);
            riOutput.Add(ri);
            niOutput.Add(ni);
            table.Add(new List<object> { i + 1, xi, ri, ni });
        }

        return table;
    }

    // (t * xi) % g
    public static int CalculateXi(int xi, int t, int g)
    {
        return (t * xi) % g;
    }

    // xi / (g - 1)
    public static double CalculateRi(int xi, int g)
    {
        return (double)xi / (g - 1);
    }

    // minValue + (maxValue - minValue) * ri
    public static double CalculateNi(double minValue, double maxValue, double ri)
    {
        return minValue + (maxValue - minValue) * ri;
    }
}

}