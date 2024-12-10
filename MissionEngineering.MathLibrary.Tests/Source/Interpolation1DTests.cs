using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionEngineering.MathLibrary.Tests;

[TestClass]
public sealed class Interpolation1DTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Create_WithEmptyArray_ExpectException()
    {
        // Arrange:
        var x = new double[0];
        var y = new double[1];

        // Act:
        var interpolation = new Interpolation1D(x, y);

        // Assert:
        Assert.Fail();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Create_WithDifferentSizedArrays_ExpectException()
    {
        // Arrange:
        var x = new double[3];
        var y = new double[4];

        // Act:
        var interpolation = new Interpolation1D(x, y);

        // Assert:
        Assert.Fail();
    }

    [TestMethod]
    public void Create_WithValidSizes_ExpectSuccess()
    {
        // Arrange:
        var x = new double[4];
        var y = new double[4];

        // Act:
        var interpolation = new Interpolation1D(x, y);

        // Assert:
        Assert.IsTrue(true);
    }
}
