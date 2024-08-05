using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UcommerceCsvImporterTests.Helpers;
using Xunit;

namespace UcommerceCsvImporterTests;

[Collection("TestCollection")]
public sealed class CurrencyDataTests(TestFixture testFixture) : IDisposable, IAsyncDisposable
{
    private readonly AsyncServiceScope _scope = testFixture.CreateScope();
    private TestDbContext DbContext => _scope.ServiceProvider.GetRequiredService<TestDbContext>();

    [Fact]
    public async Task CurrencyTableShouldContain44Rows()
    {
        var count = await DbContext.Currencies.CountAsync();
        count.Should().Be(44);
    }

    [Fact]
    public async Task NgnCurrencyShouldBeDeleted()
    {
        var currency = await DbContext.Currencies
            .Where(x => x.ISOCode == "NGN")
            .FirstOrDefaultAsync();
        Assert.NotNull(currency);
        currency.Deleted.Should().BeTrue();
        currency.ISOCode.Should().Be("NGN");
        currency.ExternalIdentifier.Should().Be("C31");
    }

    [Fact]
    public async Task HufCurrencyShouldNotBeDeleted()
    {
        var currency =
            await DbContext.Currencies
                .Where(x => x.ISOCode == "HUF")
                .FirstOrDefaultAsync();
        Assert.NotNull(currency);
        currency.Deleted.Should().BeFalse();
        currency.ISOCode.Should().Be("HUF");
        currency.ExternalIdentifier.Should().Be("C43");
    }

    public void Dispose() => _scope.Dispose();

    public async ValueTask DisposeAsync() => await _scope.DisposeAsync();
}