using Squarity.Core.Interfaces;

namespace Squarity.Core.DefaultFigures.Triangles;

/// <summary>
/// Базовое представление треугольника
/// </summary>
public partial class Triangle : IFigure2D
{
    private double sideA;
    private double sideB;
    private double sideC;

    /// <param name="a">Сторона A</param>
    /// <param name="b">Сторона B</param>
    /// <param name="c">Сторона C</param>
    /// <exception cref="" />
    public Triangle(double a, double b, double c)
    {
        (sideA, sideB, sideC) = (a, b, c);
        CheckSides();
        Kind = GetTriangleKind();
    }

    /// <summary>
    /// Сторона A
    /// </summary>
    /// <exception cref="ArgumentException" />
    public double SideA
    {
        get => sideA;
        set
        {
            sideA = value;
            CheckSide(value);
            OnSideChanged(TriangleSideName.A);
        }
    }

    /// <summary>
    /// Сторона B
    /// </summary>
    /// <exception cref="ArgumentException" />
    public double SideB
    {
        get => sideB;
        set
        {
            sideB = value;
            CheckSide(value);
            OnSideChanged(TriangleSideName.B);
        }
    }

    /// <summary>
    /// Сторона C
    /// </summary>
    /// <exception cref="ArgumentException" />
    public double SideC
    {
        get => sideC;
        set
        {
            sideC = value;
            CheckSide(value);
            OnSideChanged(TriangleSideName.C);
        }
    }

    /// <summary>
    /// Тип треугольника
    /// </summary>
    public TriangleKind Kind { get; private set; }

    /// <summary>
    /// Возвращает значение стороны по заданному имени
    /// </summary>
    protected double GetSideByName(TriangleSideName sideName) => sideName switch
    {
        TriangleSideName.A => SideA,
        TriangleSideName.B => SideB,
        TriangleSideName.C => SideC,
        _ => throw new ArgumentOutOfRangeException(nameof(sideName), ((int)sideName), null)
    };

    /// <summary>
    /// ВФ, которая вызывается при изменении одной из сторон
    /// </summary>
    /// <param name="sideName">Сторона, которая была изменена</param>
    protected virtual void OnSideChanged(TriangleSideName sideName)
    {
        Kind = GetTriangleKind();
    }

    /// <summary>
    /// Проверить сторону треугольника на валидность
    /// </summary>
    /// <exception cref="ArgumentException" />
    private void CheckSide(double value)
    {
        if (value <= 0)
        {
            throw new ArgumentException(
                message: "Side must be greater than zero"
            );
        }

        CheckSides();
    }

    /// <summary>
    /// Проверить стороны треугольника на валидность
    /// </summary>
    /// <exception cref="InvalidOperationException" />
    private void CheckSides()
    {
        if (SideA + SideB <= SideC ||
            SideA + SideC <= SideB ||
            SideB + SideC <= SideA)
        {
            throw new InvalidOperationException(
                "Invalid triangle: the sum of any two sides must be greater than the third side"
            );
        }
    }
}
