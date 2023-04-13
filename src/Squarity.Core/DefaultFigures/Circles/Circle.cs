using Squarity.Core.Interfaces;

namespace Squarity.Core.DefaultFigures.Circles;

/// <summary>
/// Базовое представление круга
/// </summary>
public partial class Circle : IFigure2D
{
    private double radius;

    /// <param name="radius">Радиус</param>
    /// <exception cref="ArgumentException" />
    public Circle(double radius)
    {
        Radius = radius;
    }

    /// <summary>
    /// Радиус
    /// </summary>
    /// <exception cref="ArgumentException" />
    public double Radius
    {
        get => radius;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException(
                    paramName: nameof(value),
                    message: "Radius must be greater than zero"
                );
            }
            radius = value;
        }
    }
}
