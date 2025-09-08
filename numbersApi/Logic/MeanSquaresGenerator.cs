namespace numbersApi.Logic
{
    using System;
using System.Collections.Generic;

public class MeanSquaresGenerator
{
    // Método que genera una iteración a partir de xi
    public static List<object> MakeIteration(int xi)
    {
        long square = (long)Math.Pow(xi, 2); // Calculamos el cuadrado
        int extension = square.ToString().Length; // Longitud del cuadrado
        int? extraction = null;

        // Selección de dígitos según la longitud
        string squareStr = square.ToString();
        if (extension == 8)
            extraction = int.Parse(squareStr.Substring(2, 4));
        else if (extension == 7)
            extraction = int.Parse(squareStr.Substring(1, 4));
        else if (extension == 6)
            extraction = int.Parse(squareStr.Substring(0, 4));
        else if (extension == 5)
            extraction = int.Parse(squareStr.Substring(0, 3));
        else if (extension == 4)
            extraction = int.Parse(squareStr.Substring(0, 2));
        else if (extension == 3)
            extraction = int.Parse(squareStr.Substring(0, 1));

        // Retorno de valores
        if (extraction.HasValue)
        {
            double ri = Math.Round(extraction.Value * 0.0001, 4);
            return new List<object> { xi, square, extension, extraction.Value, ri };
        }
        else
        {
            return new List<object> { xi, square, extension, 0, 0.0 };
        }
    }

    // Método para calcular la lista de ni
    public static List<double> CalculateNi(List<double> riValues, double minValue, double maxValue)
    {
        List<double> niValues = new List<double>();
        foreach (var ri in riValues)
        {
            double ni = Math.Round(minValue + (maxValue - minValue) * ri, 4);
            niValues.Add(ni);
        }
        return niValues;
    }
}
}

