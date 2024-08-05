using System.Globalization;
using UcommerceCsvImporter.Configuration;

namespace UcommerceCsvImporter.Fetchers;

/// <summary>
/// A general CSV fetcher that can be used to fetch multiple types of data from a CSV file.
/// </summary>
public abstract class CsvFetcher(
    GeneralSettings generalSettings,
    DataConfigurationBase dataDataDataDataConfiguration)
{
    private readonly CsvConfiguration _csvConfiguration = new(CultureInfo.InvariantCulture)
    {
        Delimiter = dataDataDataDataConfiguration.Delimiter ?? generalSettings.Delimiter,
        Encoding = dataDataDataDataConfiguration.Encoding ?? generalSettings.Encoding,
        TrimOptions =  dataDataDataDataConfiguration.TrimFields ?? generalSettings.TrimFields ? TrimOptions.Trim : TrimOptions.None,
        HasHeaderRecord = dataDataDataDataConfiguration.HasHeaderRecord ?? generalSettings.HasHeaderRecord,
        IgnoreBlankLines = true
    };

    /// <summary>
    /// Fetches data from a CSV file.
    /// </summary>
    protected Task<IReadOnlyList<T>> Fetch<T>(ClassMap<T> classMap, int batchNumber, int batchSize)
    {
        var filePath = Path.Combine(generalSettings.Directory, dataDataDataDataConfiguration.FileName);
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, _csvConfiguration);
        csv.Context.RegisterClassMap(classMap);
        var records = csv.GetRecords<T>();
        records = records.Skip(batchNumber * batchSize)
            .Take(batchSize);

        return Task.FromResult<IReadOnlyList<T>>(records.ToList());
    }
}