namespace UcommerceCsvImporter.Configuration;

/// <summary>
/// Configuration for product data.
/// </summary>
public record ProductDataConfiguration : DataConfigurationBase
{
    /// <summary>
    /// The index of the column containing the name of the product.
    /// </summary>
    public required int NameIndex { get; init; }

    /// <summary>
    /// The index of the column containing the external identifier for the product.
    /// </summary>
    public required int ExternalIdentifierIndex { get; init; }

    /// <summary>
    /// The index of the column containing the external identifier for the parent product.
    /// </summary>
    public required int ParentProductIdentifierIndex { get; init; }

    /// <summary>
    /// The index of the column containing the id (in Ucommerce) for the product definition.
    /// </summary>
    public required int DefinitionIdIndex { get; init; }

    /// <summary>
    /// The index of the column containing the <i>Display on website</i> value.
    /// </summary>
    public required int DisplayOnSiteIndex { get; init; }

    /// <summary>
    /// The index of the column containing the primary image media ID (in Ucommerce).
    /// </summary>
    public required int PrimaryImageMediaIdIndex { get; init; }

    /// <summary>
    /// The index of the column containing the SKU.
    /// </summary>
    public required int SkuIndex { get; init; }

    /// <summary>
    /// The index of the column containing the variant SKU.
    /// </summary>
    public required int VariantSkuIndex { get; init; }
}