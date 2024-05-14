namespace stfc.MitigationCalculator.Application.Services;

internal class RatioLogisticFunctionService
{
    public double Calculate(double value)
    {
        return 1 / (1 + Math.Pow(4, 1.1 - value));
    }
}