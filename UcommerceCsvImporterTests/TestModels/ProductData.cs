namespace UcommerceCsvImporterTests.TestModels;

public record ProductData
{
    public required int Id { get; init; }
    public string? ExternalIdentifier { get; init; }
    public required string Sku { get; init; }
    public string? VariantSku { get; init; }
    public required string Name { get; init; }
    public required bool DisplayOnSite { get; init; }
    public ProductData? Parent { get; init; }
    public List<ProductData>? Variants { get; init; }
    public required List<ProductPriceData> Prices { get; init; }
}