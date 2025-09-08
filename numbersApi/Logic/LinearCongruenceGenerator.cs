namespace numbersApi.Logic
{
    using System;
using System.Collections.Generic;

public class LinearCongruenceGenerator
{
    // Método principal que genera la tabla
    public static List<List<object>> CalculateTable(int x0, int a, int c, int m, int iteraciones, double minValue, double maxValue)
    {
        var table = new List<List<object>>();
        int xi = x0;
        var NiArray = new List<double>();

        for (int i = 0; i < iteraciones; i++)
        {
            xi = CalculateXi(xi, a, c, m);
            double ri = CalculateRi(xi, m);
            double ni = CalculateNi(minValue, maxValue, ri);
            NiArray.Add(ni);
            table.Add(new List<object> { i + 1, xi, ri, ni });
        }

        return table;
    }

    // (a * xi + c) % m
    public static int CalculateXi(int xi, int a, int c, int m)
    {
        return (a * xi + c) % m;
    }

    // xi / (m - 1)
    public static double CalculateRi(int xi, int m)
    {
        return (double)xi / (m - 1);
    }

    // minValue + (maxValue - minValue) * ri
    public static double CalculateNi(double minValue, double maxValue, double ri)
    {
        return minValue + (maxValue - minValue) * ri;
    }
}
}
