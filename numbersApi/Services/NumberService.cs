using numbersApi.Logic;
namespace numbersApi.Services
{
// Services/NumberService.cs
public class NumberService
{
    private NumberGenerator _numberGenerator;

    public NumberService(NumberGenerator generator)
    {
        _numberGenerator = generator;
    }

    public List<double> GetR_isByMiddleSquare(int seed)
    {
        return _numberGenerator.GenerateNumbersByMiddleSquare(seed);
    }

    public List<double> GetR_isByLinearCongruence(int x, int k, int c, int g)
    {
        return _numberGenerator.GenerateNumbersByLinearCongruence(x, k, c, g);
    }

    public List<double> GetR_isByMultiplicativeCongruence(int x, int t, int g)
    {
        return _numberGenerator.GenerateNumbersByMultiplicativeCongruence(x, t, g);
    }

    // public List<double> GetValidatedNumbers(int seed, int count)
    // {
    //     var numbers = _numberGenerator.Generate(seed,count);

    //     if (!_validator.AreNumbersValid(numbers))
    //     {
    //         throw new Exception("Los números generados no pasaron las pruebas de calidad.");
    //     }

    //     return numbers;
    // }
}
}
