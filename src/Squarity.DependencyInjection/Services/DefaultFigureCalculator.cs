using Squarity.Core.Interfaces;
using Squarity.DependencyInjection.Interfaces;

namespace Squarity.DependencyInjection.Services;

/// <summary>
/// Стандартная реализация <see cref="IFigureCalculator" />
/// </summary>
public class DefaultFigureCalculator : IFigureCalculator
{
    public virtual double CalculateArea(IFigure2D figure)
    {
        ArgumentNullException.ThrowIfNull(figure);
        return figure.CalculateArea();
    }
}
