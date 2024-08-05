using UcommerceCsvImporter.Configuration;

namespace UcommerceCsvImporter.Mapping;

/// <inheritdoc />
public sealed class PriceDataMap : ClassMap<PriceData>
{
    /// <inheritdoc />
    public PriceDataMap(PriceDataConfiguration priceDataConfiguration)
    {
        Map(x => x.Amount).Index(priceDataConfiguration.AmountIndex);
        Map(x => x.MinimumQuantity).Index(priceDataConfiguration.MinimumQuantityIndex);
        Map(x => x.ExternalIdentifier).Index(priceDataConfiguration.ExternalIdentifierIndex);
        Map(x => x.PriceGroupIdentifier).Index(priceDataConfiguration.PriceGroupIdentifierIndex);
        Map(x => x.ProductIdentifier).Index(priceDataConfiguration.ProductIdentifierIndex);
    }
}