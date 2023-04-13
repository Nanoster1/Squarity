namespace Squarity.Core.DefaultFigures.Circles;

public partial class Circle
{
    public double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}
