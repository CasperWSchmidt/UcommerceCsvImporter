using UcommerceCsvImporter.Configuration;

namespace UcommerceCsvImporter.Mapping;

/// <inheritdoc />
public sealed class PriceGroupDataMap : ClassMap<PriceGroupData>
{
    /// <inheritdoc />
    public PriceGroupDataMap(PriceGroupDataConfiguration priceGroupDataConfiguration)
    {
        Map(m => m.CurrencyIdentifier)
            .Index(priceGroupDataConfiguration.CurrencyIdentifierIndex);
        Map(m => m.BasePriceGroupIdentifier)
            .Index(priceGroupDataConfiguration.BasePriceGroupIdentifierIndex);
        Map(m => m.Deleted)
            .Index(priceGroupDataConfiguration.DeletedIndex);
        Map(m => m.Description)
            .Index(priceGroupDataConfiguration.DescriptionIndex);
        Map(m => m.ExternalIdentifier)
            .Index(priceGroupDataConfiguration.ExternalIdentifierIndex);
        Map(m => m.Name)
            .Index(priceGroupDataConfiguration.NameIndex);
        Map(m => m.TaxRate)
            .Index(priceGroupDataConfiguration.TaxRateIndex);
    }
}