using UcommerceCsvImporter.Configuration;

namespace UcommerceCsvImporter.Mapping;

/// <inheritdoc />
public sealed class ProductDataMap : ClassMap<ProductData>
{
    /// <inheritdoc />
    public ProductDataMap(ProductDataConfiguration productDataConfiguration)
    {
        Map(m => m.Name)
            .Index(productDataConfiguration.NameIndex);
        Map(m => m.ExternalIdentifier)
            .Index(productDataConfiguration.ExternalIdentifierIndex);
        Map(m => m.ParentProductIdentifier)
            .Index(productDataConfiguration.ParentProductIdentifierIndex);
        Map(m => m.DefinitionId)
            .Index(productDataConfiguration.DefinitionIdIndex);
        Map(m => m.DisplayOnSite)
            .Index(productDataConfiguration.DisplayOnSiteIndex);
        Map(m => m.PrimaryImageMediaId)
            .Index(productDataConfiguration.PrimaryImageMediaIdIndex);
        Map(m => m.Sku)
            .Index(productDataConfiguration.SkuIndex);
        Map(m => m.VariantSku)
            .Index(productDataConfiguration.VariantSkuIndex);
    }
}