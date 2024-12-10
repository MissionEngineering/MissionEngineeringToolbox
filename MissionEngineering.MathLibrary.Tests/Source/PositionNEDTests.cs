namespace MissionEngineering.MathLibrary.Tests;

[TestClass]
public sealed class PositionNEDTests
{
    [TestMethod]
    public void Add_WithValidValues_ExpectSuccess()
    {
        // Arrange:
        var x = new PositionNED(100.0, 200.0, -150.0);
        var y = new PositionNED(400.0, 123.0, -250.0);

        var expectedResult = new PositionNED(500.0, 323.0, -400.0);

        // Act:
        var result = x + y;

        // Assert:
        Assert.AreEqual(expectedResult, result);
    }
}