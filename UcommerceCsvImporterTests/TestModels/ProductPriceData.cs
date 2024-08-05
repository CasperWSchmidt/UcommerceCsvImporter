namespace UcommerceCsvImporterTests.TestModels;

public record ProductPriceData
{
    public required int Id { get; init; }
    public required ProductData Product { get; init; }
    public required int MinimumQuantity { get; init; }
    public required PriceData Price { get; init; }
}