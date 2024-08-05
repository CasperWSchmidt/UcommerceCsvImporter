namespace UcommerceCsvImporterTests.TestModels;

public record PriceGroupData
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required CurrencyData Currency { get; init; }
    public required decimal VatRate { get; init; }
    public string? Description { get; init; }
    public PriceGroupData? BasePriceGroup { get; init; }
    public List<PriceGroupData>? DerivedPriceGroups { get; init; }
    public string? ExternalIdentifier { get; init; }
}