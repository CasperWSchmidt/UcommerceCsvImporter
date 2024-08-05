namespace UcommerceCsvImporter.Configuration;

/// <summary>
/// Configuration for currency data.
/// </summary>
public record CurrencyDataConfiguration : DataConfigurationBase
{
    /// <summary>
    /// The index of the column containing the <i>deleted</i> value.
    /// </summary>
    public required int DeletedIndex { get; init; }

    /// <summary>
    /// The index of the column containing the ISO currency code.
    /// </summary>
    public required int IsoCodeIndex { get; init; }

    /// <summary>
    /// The index of the column containing the external identifier for the currency.
    /// </summary>
    public required int ExternalIdentifierIndex { get; init; }
}