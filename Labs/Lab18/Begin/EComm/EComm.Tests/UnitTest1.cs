using EComm.Core.Entities;
using EComm.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EComm.Tests;

public class UnitTest1
{
    [Fact]
    public void TwoPlusTwo()
    {
        Assert.Equal(4, (2 + 2));
    }

    [Fact]
    public async Task ProductDetails()
    {
        // Arrange
        var repository = new StubRepository();
        var pc = new ProductController(repository, null);

        // Act
        var result = await pc.Details(1);

        // Assert
        Assert.IsAssignableFrom<ViewResult>(result);
        var vr = result as ViewResult;
        Assert.IsAssignableFrom<Product>(vr!.Model);
        var model = vr.Model as Product;
        Assert.Equal("Bread", model!.ProductName);
    }
}