using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UcommerceCsvImporterTests.Helpers;
using Xunit;

namespace UcommerceCsvImporterTests;

[Collection("TestCollection")]
public sealed class PriceGroupDataTests(TestFixture testFixture) : IDisposable, IAsyncDisposable
{
    private readonly AsyncServiceScope _scope = testFixture.CreateScope();
    private TestDbContext DbContext => _scope.ServiceProvider.GetRequiredService<TestDbContext>();

    [Fact]
    public async Task PriceGroupTableShouldContain25Rows()
    {
        var count = await DbContext.PriceGroups.CountAsync();
        count.Should().Be(25);
    }

    [Fact]
    public async Task PriceGroupPg1ShouldHaveDkkCurrencyAnd10PercentVat()
    {
        var priceGroup = await DbContext.PriceGroups
            .Where(x => x.ExternalIdentifier == "PG1")
            .Include(x => x.Currency)
            .FirstOrDefaultAsync();
        Assert.NotNull(priceGroup);
        priceGroup.VatRate.Should().Be(0.10m);
        priceGroup.Name.Should().Be("dkk");
        priceGroup.ExternalIdentifier.Should().Be("PG1");
        priceGroup.Currency.Should().NotBeNull();
        priceGroup.Currency.ISOCode.Should().Be("DKK");
    }

    [Fact]
    public async Task PriceGroupPg18ShouldHavePg1AsBasePriceGroup()
    {
        var priceGroup = await DbContext.PriceGroups
            .Where(x => x.ExternalIdentifier == "PG18")
            .Include(x => x.Currency)
            .Include(x => x.BasePriceGroup)
            .ThenInclude(x => x!.DerivedPriceGroups)
            .FirstOrDefaultAsync();
        Assert.NotNull(priceGroup);
        priceGroup.ExternalIdentifier.Should().Be("PG18");
        priceGroup.Name.Should().Be("dkk-child");
        Assert.NotNull(priceGroup.BasePriceGroup);
        priceGroup.BasePriceGroup.ExternalIdentifier.Should().Be("PG1");
        priceGroup.BasePriceGroup.DerivedPriceGroups.Should().ContainSingle(x => x.ExternalIdentifier == "PG18");
    }

    public void Dispose() => _scope.Dispose();

    public async ValueTask DisposeAsync() => await _scope.DisposeAsync();
}