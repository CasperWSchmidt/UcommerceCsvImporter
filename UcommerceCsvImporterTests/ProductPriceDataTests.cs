using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UcommerceCsvImporterTests.Helpers;
using Xunit;

namespace UcommerceCsvImporterTests;

[Collection("TestCollection")]
public class ProductPriceDataTests(TestFixture testFixture) : IDisposable, IAsyncDisposable
{
    private readonly AsyncServiceScope _scope = testFixture.CreateScope();
    private TestDbContext DbContext => _scope.ServiceProvider.GetRequiredService<TestDbContext>();

    [Fact]
    public async Task ProductPriceTableShouldContain50Rows()
    {
        var count = await DbContext.ProductPrices.CountAsync();
        count.Should().Be(50);
    }

    [Fact]
    public async Task ProductP1ShouldHavePriceAmount20()
    {
        var productPrice = await DbContext.ProductPrices
            .Where(x => x.Product.ExternalIdentifier == "P1")
            .Include(x => x.Product)
            .Include(x => x.Price)
            .FirstOrDefaultAsync();
        Assert.NotNull(productPrice);
        productPrice.MinimumQuantity.Should().Be(1);
        productPrice.Product.Sku.Should().Be("0001");
        productPrice.Price.Amount.Should().Be(20);
        productPrice.Price.ExternalIdentifier.Should().Be("PR1");
    }

    public void Dispose() => _scope.Dispose();

    public async ValueTask DisposeAsync() => await _scope.DisposeAsync();
}