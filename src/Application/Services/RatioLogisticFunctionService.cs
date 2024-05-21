namespace stfc.MitigationCalculator.Application.Services;

internal class RatioLogisticFunctionService
{
    public double CalculateValueByRatio(double ratio)
    {
        return 1 / (1 + Math.Pow(4, 1.1 - ratio));
    }
}