using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UcommerceCsvImporterTests.Helpers;
using Xunit;

namespace UcommerceCsvImporterTests;

[Collection("TestCollection")]
public class ProductDataTests(TestFixture testFixture) : IDisposable, IAsyncDisposable
{
    private readonly AsyncServiceScope _scope = testFixture.CreateScope();
    private TestDbContext DbContext => _scope.ServiceProvider.GetRequiredService<TestDbContext>();

    [Fact]
    public async Task ProductTableShouldContain50Rows()
    {
        var count = await DbContext.Products.CountAsync();
        count.Should().Be(50);
    }

    [Fact]
    public async Task ProductP1ShouldBeHaveSku0001()
    {
        var product = await DbContext.Products
            .Where(x => x.ExternalIdentifier == "P1")
            .Include(productData => productData.Variants)
            .FirstOrDefaultAsync();
        Assert.NotNull(product);
        product.Sku.Should().Be("0001");
        product.Name.Should().Be("Product1");
        Assert.NotNull(product.Variants);
        product.Variants.Should().HaveCount(2);
        var firstVariant = product.Variants.Single(v => v.ExternalIdentifier == "P3");
        firstVariant.Sku.Should().Be("0001");
        firstVariant.VariantSku.Should().Be("0001-0001");
    }

    public void Dispose() => _scope.Dispose();

    public async ValueTask DisposeAsync() => await _scope.DisposeAsync();
}