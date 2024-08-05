namespace UcommerceCsvImporter.Fetchers;

/// <inheritdoc />
public class CsvCategoryFetcher : ICategoryFetcher
{
    /// <inheritdoc />
    public Task<IReadOnlyList<CategoryData>> GetCategoryData(int batchNumber, int batchSize) =>
        throw new System.NotImplementedException();
}