using UcommerceCsvImporter.Configuration;
using UcommerceCsvImporter.Mapping;

namespace UcommerceCsvImporter.Fetchers;

/// <inheritdoc cref="Ucommerce.DataImport.Core.IPriceFetcher" />
public class CsvPriceFetcher(GeneralSettings generalSettings, PriceDataConfiguration priceDataConfiguration) 
    : CsvFetcher(generalSettings, priceDataConfiguration), IPriceFetcher
{
    /// <inheritdoc />
    public Task<IReadOnlyList<PriceData>> GetPriceData(int batchNumber, int batchSize) =>
        Fetch(new PriceDataMap(priceDataConfiguration), batchNumber, batchSize);
}