using UcommerceCsvImporter.Configuration;
using UcommerceCsvImporter.Mapping;

namespace UcommerceCsvImporter.Fetchers;

/// <inheritdoc cref="Ucommerce.DataImport.Core.ICurrencyFetcher" />
public class CsvCurrencyFetcher(GeneralSettings generalSettings, CurrencyDataConfiguration currencyDataConfiguration)
    : CsvFetcher(generalSettings, currencyDataConfiguration), ICurrencyFetcher
{
    /// <inheritdoc />
    public Task<IReadOnlyList<CurrencyData>> GetCurrencyData(int batchNumber, int batchSize) =>
        Fetch(new CurrencyDataMap(currencyDataConfiguration), batchNumber, batchSize);
}