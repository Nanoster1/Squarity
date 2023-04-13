using Squarity.Core.Interfaces;

namespace Squarity.DependencyInjection.Interfaces;

/// <summary>
/// Интерфейс сервиса для операций с фигурами
/// </summary>
public interface IFigureCalculator
{
    /// <summary>
    /// Высчитать площадь 2D фигуры
    /// </summary>
    /// <param name="figure">2D фигура</param>
    double CalculateArea(IFigure2D figure);
}
