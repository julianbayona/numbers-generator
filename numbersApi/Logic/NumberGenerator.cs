namespace numbersApi.Logic
{
    // Logic/NumberGenerator.cs
public class NumberGenerator
{
    private readonly int _amount;

    public NumberGenerator(int amount)
    {
        _amount = amount;
    }

    public List<double> GenerateNumbersByMiddleSquare(int seed)
    {
        var numbers = new List<double>();
        int x = seed;

        for (int i = 0; i < _amount; i++)
        {
            // Elevar al cuadrado
            long squared = (long)x * (long)x;

            // Determinar longitud
            int digits = (int)Math.Floor(Math.Log10(Math.Abs(squared)) + 1);

            // Extraer número según la regla (equivalente a extraer_numero en Python)
            int extracted = ExtractNumber(squared, digits);

            // Normalizar dividiendo entre 10000 (como en Python)
            numbers.Add(extracted / 10000.0);

            // Actualizar la semilla
            x = extracted;
        }

        return numbers;
    }

    public List<double> GenerateNumbersByLinearCongruence(int x, int k, int c, int g)
    {
        var numbers = new List<double>();
        int a = 1+2*k; // a debe ser impar
        int m = (int)Math.Pow(2, g); // m es una potencia de 2
        
            for (int i = 0; i < _amount; i++)
            {
                x = (a * x + c) % m; // Fórmula LCG
                numbers.Add((double)x / m); // Normalizar entre 0 y 1
            }

            return numbers;
        }
    public List<double> GenerateNumbersByMultiplicativeCongruence(int x, int t, int g)
    {
        var numbers = new List<double>();
        int a = 8*t+3; // 
        int m = (int)Math.Pow(2, g); // m es una potencia de 2
        
            for (int i = 0; i < _amount; i++)
            {
                x = (a * x) % m; // Fórmula LCG
                numbers.Add((double)x / m); // Normalizar entre 0 y 1
            }

            return numbers;
        }

    private int ExtractNumber(long value, int digits)
    {
        string str = value.ToString();
        int start = 0;
        int length = 0;

        switch (digits)
        {
            case 8: start = 2; length = 4; break;
            case 7: start = 1; length = 4; break;
            case 6: start = 0; length = 4; break;
            case 5: start = 0; length = 3; break;
            case 4: start = 0; length = 2; break;
            case 3: start = 0; length = 1; break;
            default: throw new ArgumentException("Longitud no soportada.");
        }

        return int.Parse(str.Substring(start, length));
    }
}

}
