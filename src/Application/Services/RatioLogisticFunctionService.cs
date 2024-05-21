namespace stfc.MitigationCalculator.Application.Services;

internal class RatioLogisticFunctionService
{
    public double CalculateValueByRatio(double ratio)
    {
        return 1 / (1 + Math.Pow(4, 1.1 - ratio));
    }

    public double CalculateRatioByValue(double value)
    {
        return 1.1 - Math.Log(1.0 / value - 1.0, 4.0);
    }
}