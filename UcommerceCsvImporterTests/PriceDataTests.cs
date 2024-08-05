using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UcommerceCsvImporterTests.Helpers;
using Xunit;

namespace UcommerceCsvImporterTests;

[Collection("TestCollection")]
public sealed class PriceDataTests(TestFixture testFixture) : IDisposable, IAsyncDisposable
{
    private readonly AsyncServiceScope _scope = testFixture.CreateScope();
    private TestDbContext DbContext => _scope.ServiceProvider.GetRequiredService<TestDbContext>();

    [Fact]
    public async Task PriceTableShouldContain50Rows()
    {
        var count = await DbContext.Prices.CountAsync();
        count.Should().Be(50);
    }

    [Fact]
    public async Task PricePr1ShouldHaveAmount20AndPriceGroup1()
    {
        var price = await DbContext.Prices
            .Where(x => x.ExternalIdentifier == "PR1")
            .Include(x => x.PriceGroup)
            .FirstOrDefaultAsync();
        Assert.NotNull(price);
        price.Amount.Should().Be(20);
        price.ExternalIdentifier.Should().Be("PR1");
        price.PriceGroup.Should().NotBeNull();
        price.PriceGroup.ExternalIdentifier.Should().Be("PG1");
    }

    public void Dispose() => _scope.Dispose();

    public async ValueTask DisposeAsync() => await _scope.DisposeAsync();
}