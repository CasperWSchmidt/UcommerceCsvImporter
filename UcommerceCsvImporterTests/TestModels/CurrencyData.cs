namespace UcommerceCsvImporterTests.TestModels;

public record CurrencyData
{
    public required int Id { get; init; }
    public required string ISOCode { get; init; }
    public required bool Deleted { get; init; }
    public string? ExternalIdentifier { get; init; }
}