namespace UcommerceCsvImporter.Configuration;

/// <summary>
/// Configuration for price group data.
/// </summary>
public record PriceGroupDataConfiguration : DataConfigurationBase
{
    /// <summary>
    /// The index of the column containing the external identifier for the currency.
    /// </summary>
    public required int CurrencyIdentifierIndex { get; init; }

    /// <summary>
    /// The index of the column containing the external identifier for the base price group.
    /// </summary>
    public required int BasePriceGroupIdentifierIndex { get; init; }

    /// <summary>
    /// The index of the column containing the <i>deleted</i> value.
    /// </summary>
    public required int DeletedIndex { get; init; }

    /// <summary>
    /// The index of the column containing the description of the price group.
    /// </summary>
    public required int DescriptionIndex { get; init; }

    /// <summary>
    /// The index of the column containing the external identifier for the price group.
    /// </summary>
    public required int ExternalIdentifierIndex { get; init; }

    /// <summary>
    /// The index of the column containing the name of the price group.
    /// </summary>
    public required int NameIndex { get; init; }

    /// <summary>
    /// The index of the column containing the tax rate.
    /// </summary>
    public required int TaxRateIndex { get; init; }
}