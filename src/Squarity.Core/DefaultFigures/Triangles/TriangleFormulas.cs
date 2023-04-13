namespace Squarity.Core.DefaultFigures.Triangles;

public partial class Triangle
{
    /// <summary>
    /// Возвращает тип треугольника на основе его сторон
    /// </summary>
    protected TriangleKind GetTriangleKind()
    {
        if (SideA == SideB && SideB == SideC)
        {
            return TriangleKind.Equilateral;
        }

        if (SideA == SideB || SideB == SideC || SideC == SideA)
        {
            return TriangleKind.Isosceles;
        }

        // Подготовка данных для теоремы пифагора
        var squaredValues = new[]
        {
            Math.Pow(SideA, 2),
            Math.Pow(SideB, 2),
            Math.Pow(SideC, 2)
        };

        Array.Sort(squaredValues);

        if (squaredValues[2] < squaredValues[0] + squaredValues[1])
        {
            return TriangleKind.Acute;
        }

        if (squaredValues[2] > squaredValues[0] + squaredValues[1])
        {
            return TriangleKind.Obtuse;
        }

        return TriangleKind.Right;
    }

    public double CalculateArea() => Kind switch
    {
        TriangleKind.Equilateral => Math.Pow(SideA, 2) * Math.Sqrt(3) / 4,
        TriangleKind.Right => SideA * SideB / 2,
        _ => HeronFormula(this),
    };

    /// <summary>
    /// Высчитывает площадь по формуле Герона
    /// </summary>
    public static double HeronFormula(Triangle triangle)
    {
        var halfPerimeter = (triangle.SideA + triangle.SideB + triangle.SideC) / 2;
        return Math.Sqrt(
            halfPerimeter *
            (halfPerimeter - triangle.SideA) *
            (halfPerimeter - triangle.SideB) *
            (halfPerimeter - triangle.SideC)
        );
    }
}
