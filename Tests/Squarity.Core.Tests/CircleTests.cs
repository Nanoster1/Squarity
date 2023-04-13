using Squarity.Core.DefaultFigures.Circles;

namespace Squarity.Core.Tests;

public class CircleTests
{
    public static object[][] GetValidData() => new[]
    {
        new object[] { new Circle(1), Math.PI },
        new object[] { new Circle(2), 12.566371 },
        new object[] { new Circle(12), 452.389342 }
    };

    public static object[][] GetInvalidConstructorData() => new[]
    {
        new object[] { 0d },
        new object[] { -1d }
    };

    [Theory]
    [MemberData(nameof(GetValidData))]
    public void CalculateArea_ValidCircle_SuccessPath(Circle circle, double expectedResult)
    {
        //Arrange
        var precision = 6;

        //Act
        var actualResult = circle.CalculateArea();

        //Assert
        Assert.Equal(expectedResult, actualResult, precision);
    }

    [Theory]
    [MemberData(nameof(GetInvalidConstructorData))]
    public void Constructor_InvalidData_ThrowArgumentException(double invalidRadius)
    {
        //Arrange
        var action = () => { new Circle(invalidRadius); };

        //Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Theory]
    [MemberData(nameof(GetInvalidConstructorData))]
    public void RadiusSetter_InvalidValue_ThrowArgumentException(double invalidValue)
    {
        //Arrange
        var validValue = 1;
        var circle = new Circle(validValue);
        var action = () => { circle.Radius = invalidValue; };

        //Assert
        Assert.Throws<ArgumentException>(action);
    }
}
