using Squarity.Core.DefaultFigures.Circles;
using Squarity.DependencyInjection.Interfaces;

namespace Squarity.DependencyInjection.DefaultFormulas;

public class CircleAreaFormula : IFormula<double>
{
    private readonly Circle _circle;

    public CircleAreaFormula(Circle circle)
    {
        _circle = circle;
    }

    public double Calculate()
    {
        return _circle.CalculateArea();
    }
}
