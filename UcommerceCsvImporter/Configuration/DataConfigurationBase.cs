using System.Text;

namespace UcommerceCsvImporter.Configuration;

/// <summary>
/// Base class for data type configurations. See <see cref="CurrencyDataConfiguration"/>, <see cref="PriceDataConfiguration"/>, 
/// <see cref="PriceGroupDataConfiguration"/>, and <see cref="ProductDataConfiguration"/> for details on each configuration.
/// </summary>
public abstract record DataConfigurationBase
{
    /// <summary>
    /// The file name of the CSV file.
    /// </summary>
    public required string FileName { get; init; }

    /// <summary>
    /// The delimiter used in the CSV file.
    /// If not set, the default delimiter set in <see cref="GeneralSettings"/> is used.
    /// </summary>
    public string? Delimiter { get; init; }

    /// <summary>
    /// The encoding used in the CSV file.
    /// If not set, the default encoding set in <see cref="GeneralSettings"/> is used.
    /// </summary>
    public Encoding? Encoding { get; init; }

    /// <summary>
    /// If set to <c>true</c>, fields will be trimmed before being processed.
    /// If not set, the default value set in <see cref="GeneralSettings"/> is used.
    /// </summary>
    public bool? TrimFields { get; init; } = true;

    /// <summary>
    /// If set to <c>true</c>, the first record in the CSV file is considered a header record and is skipped.
    /// If not set, the default value set in <see cref="GeneralSettings"/> is used.
    /// </summary>
    public bool? HasHeaderRecord { get; init; }
}