using Squarity.Core.DefaultFigures.Triangles;

namespace Squarity.Core.Tests;

public class TriangleTests
{
    public static object[][] GetValidData() => new[]
    {
        new object[] { new Triangle(25, 15, 15), 103.64 },
        new object[] { new Triangle(15, 15, 15), 97.43 },
        new object[] { new Triangle(6, 7, 5), 14.7 },
        new object[] { new Triangle(8, 10, 15), 36.98 },
        new object[] { new Triangle(6, 8, 10), 24 }
    };

    public static object[][] GetValidDataWithKind() => new[]
    {
        new object[] { 25, 15, 15, TriangleKind.Isosceles },
        new object[] { 15, 15, 15, TriangleKind.Equilateral},
        new object[] { 6, 7, 5, TriangleKind.Acute },
        new object[] { 8, 10, 15, TriangleKind.Obtuse },
        new object[] { 6, 8, 10, TriangleKind.Right }
    };

    public static object[][] GetInvalidConstructorData() => new[]
    {
        new object[] { 0d, 15d, 20d },
        new object[] { -1d, 15d, 20d },
        new object[] { 3d, 3d, 100d },
    };

    public static object[][] GetInvalidSideValue() => new[]
    {
        new object[] { 0d },
        new object[] { -1d },
    };

    [Theory]
    [MemberData(nameof(GetValidData))]
    public void CalculateArea_ValidTriangle_SuccessPath(Triangle triangle, double expectedResult)
    {
        //Arrange
        var precision = 2;

        //Act
        var actualResult = triangle.CalculateArea();

        //Assert
        Assert.Equal(expectedResult, actualResult, precision);
    }

    [Theory]
    [MemberData(nameof(GetInvalidConstructorData))]
    public void Constructor_InvalidData_ThrowArgumentException(
        double sideA,
        double sideB,
        double sideC)
    {
        //Arrange
        var action = () => { new Triangle(sideA, sideB, sideC); };

        //Assert
        Assert.ThrowsAny<Exception>(action);
    }

    [Theory]
    [MemberData(nameof(GetInvalidSideValue))]
    public void SideSetter_InvalidValue_ThrowArgumentException(double invalidValue)
    {
        //Arrange
        var validValues = new[] { 25, 15, 15 };
        var triangle = new Triangle(validValues[0], validValues[1], validValues[2]);
        var setSideA = () => { triangle.SideA = invalidValue; };
        var setSideB = () => { triangle.SideB = invalidValue; };
        var setSideC = () => { triangle.SideC = invalidValue; };

        //Assert
        Assert.ThrowsAny<Exception>(setSideA);
        Assert.ThrowsAny<Exception>(setSideB);
        Assert.ThrowsAny<Exception>(setSideC);
    }

    [Theory]
    [MemberData(nameof(GetValidDataWithKind))]
    public void GetTriangleKind_ValidData_SuccessPath(
        double sideA,
        double sideB,
        double sideC,
        TriangleKind expectedKind)
    {
        //Act
        var triangle = new Triangle(sideA, sideB, sideC);

        //Assert
        Assert.Equal(expectedKind, triangle.Kind);
    }
}
