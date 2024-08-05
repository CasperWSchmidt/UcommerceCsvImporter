using UcommerceCsvImporter.Configuration;
using UcommerceCsvImporter.Mapping;

namespace UcommerceCsvImporter.Fetchers;

/// <inheritdoc cref="Ucommerce.DataImport.Core.IPriceGroupFetcher" />
public class CsvPriceGroupFetcher(GeneralSettings generalSettings, PriceGroupDataConfiguration priceGroupDataConfiguration)
    : CsvFetcher(generalSettings, priceGroupDataConfiguration), IPriceGroupFetcher
{
    /// <inheritdoc />
    public Task<IReadOnlyList<PriceGroupData>> GetPriceGroupData(int batchNumber, int batchSize) =>
        Fetch(new PriceGroupDataMap(priceGroupDataConfiguration), batchNumber, batchSize);
}