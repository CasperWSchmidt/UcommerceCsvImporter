using UcommerceCsvImporter.Configuration;

namespace UcommerceCsvImporter.Mapping;

/// <inheritdoc />
public sealed class CurrencyDataMap : ClassMap<CurrencyData>
{
    /// <inheritdoc />
    public CurrencyDataMap(CurrencyDataConfiguration currencyDataConfiguration)
    {
        Map(m => m.Deleted)
            .Index(currencyDataConfiguration.DeletedIndex);
        Map(m => m.ExternalIdentifier)
            .Index(currencyDataConfiguration.ExternalIdentifierIndex);
        Map(m => m.IsoCode)
            .Index(currencyDataConfiguration.IsoCodeIndex);
    }
}