namespace UcommerceCsvImporter.Configuration;

/// <summary>
/// Configuration for price data.
/// </summary>
public record PriceDataConfiguration : DataConfigurationBase
{
    /// <summary>
    /// The index of the column containing the amount of the price.
    /// </summary>
    public required int AmountIndex { get; init; }

    /// <summary>
    /// The index of the column containing the minimum quantity needed to trigger the price.
    /// </summary>
    public required int MinimumQuantityIndex { get; init; }

    /// <summary>
    /// The index of the column containing external identifier for the price.
    /// </summary>
    public required int ExternalIdentifierIndex { get; init; }

    /// <summary>
    /// The index of the column containing the external identifier for the price group this price belongs to.
    /// </summary>
    public required int PriceGroupIdentifierIndex { get; init; }

    /// <summary>
    /// The index of the column containing the external identifier for the product this price belongs to.
    /// </summary>
    public required int ProductIdentifierIndex { get; init; }
}