using UcommerceCsvImporter.Configuration;
using UcommerceCsvImporter.Mapping;

namespace UcommerceCsvImporter.Fetchers;

/// <inheritdoc cref="Ucommerce.DataImport.Core.IProductFetcher" />
public class CsvProductFetcher(GeneralSettings generalSettings, ProductDataConfiguration productDataConfiguration) 
    : CsvFetcher(generalSettings, productDataConfiguration), IProductFetcher
{
    /// <inheritdoc />
    public Task<IReadOnlyList<ProductData>> GetProductData(int batchNumber, int batchSize) =>
        Fetch(new ProductDataMap(productDataConfiguration), batchNumber, batchSize);
}