namespace UcommerceCsvImporterTests.TestModels;

public record PriceData
{
    public required int Id { get; init; }
    public required decimal Amount { get; init; }
    public required string ExternalIdentifier { get; init; }
    public required PriceGroupData PriceGroup { get; init; }
}