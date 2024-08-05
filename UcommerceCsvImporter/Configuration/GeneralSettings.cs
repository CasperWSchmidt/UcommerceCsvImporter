using System.Text;

namespace UcommerceCsvImporter.Configuration;

/// <summary>
/// General settings for the CSV data importer.
/// These settings are used as default values for the <see cref="DataConfigurationBase"/> settings.
/// Values are set in the appsettings.json file under UcommerceCsvImporter:GeneralSettings.
/// </summary>
public record GeneralSettings
{
    /// <summary>
    /// The directory where the CSV files are located.
    /// </summary>
    public required string Directory { get; init; }

    /// <summary>
    /// The delimiter used in the CSV file.
    /// Default is ";".
    /// </summary>
    public required string Delimiter { get; init; } = ";";

    /// <summary>
    /// The encoding used in the CSV file.
    /// Default is UTF-8.
    /// </summary>
    public Encoding Encoding { get; init; } = Encoding.UTF8;

    /// <summary>
    /// If set to <c>true</c>, fields will be trimmed before being processed.
    /// Default is <c>true</c>.
    /// </summary>
    public bool TrimFields { get; init; } = true;

    /// <summary>
    /// If set to <c>true</c>, the first record in the CSV file is considered a header record and is skipped.
    /// Default is <c>true</c>.
    /// </summary>
    public bool HasHeaderRecord { get; init; } = true;
}