using Squarity.Core.DefaultFigures.Triangles;
using Squarity.DependencyInjection.Interfaces;

namespace Squarity.DependencyInjection.DefaultFormulas;

public class TriangleAreaFormula : IFormula<double>
{
    private readonly Triangle _triangle;

    public TriangleAreaFormula(Triangle triangle)
    {
        _triangle = triangle;
    }

    public double Calculate()
    {
        return _triangle.CalculateArea();
    }
}
