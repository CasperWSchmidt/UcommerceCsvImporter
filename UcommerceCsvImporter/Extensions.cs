using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ucommerce.DataImport.Core.DependencyInjection;
using UcommerceCsvImporter.Configuration;
using ConfigurationException = UcommerceCsvImporter.Exceptions.ConfigurationException;

namespace UcommerceCsvImporter;

public static class Extensions
{
    /// <summary>
    /// Extenstion method for adding the CSV data importer for Ucommerce
    /// </summary>
    /// <param name="serviceCollection">The <see cref="IServiceCollection"/> used to register the importer.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> used to bind settings automatically by the Ucommerce data importer.</param>
    /// <param name="settings">Optional. Ucommerce data importer settings set in code. These overrides any settings set in the configuration.</param>
    /// <exception cref="ArgumentNullException"><see cref="DataImporterSettings.ConnectionString"/> is null.</exception>
    /// <exception cref="ArgumentException"><see cref="DataImporterSettings.ConnectionString"/> is empty.</exception>
    /// <exception cref="ArgumentException"><see cref="DataImporterSettings.BatchSize"/> is zero or negative.</exception>
    /// <exception cref="InvalidOperationException">If no implementation of a fetcher can be found. - or - More than one implementation of a fetcher is found.</exception>
    /// <exception cref="ConfigurationException">If any of the following sections is missing from the settings:
    /// <ul>
    /// <li>GeneralSettings</li>
    /// <li>CurrencyDataSettings</li>
    /// <li>PriceDataSettings</li>
    /// <li>PriceGroupDataSettings</li>
    /// <li>ProductDataSettings</li>
    /// </ul>
    /// </exception>
    public static IServiceCollection AddUcommerceCsvDataImporter(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        DataImporterSettings? settings = null)
    {
        serviceCollection.AddSingleton(
            configuration.GetSection("UcommerceCsvImporter:GeneralSettings").Get<GeneralSettings>()
            ?? throw new ConfigurationException("GeneralSettings is missing in the settings."));
        serviceCollection.AddSingleton(
            configuration.GetSection("UcommerceCsvImporter:CurrencyDataSettings").Get<CurrencyDataConfiguration>()
            ?? throw new ConfigurationException("CurrencyDataSettings is missing in the settings."));
        serviceCollection.AddSingleton(
            configuration.GetSection("UcommerceCsvImporter:PriceDataSettings").Get<PriceDataConfiguration>()
            ?? throw new ConfigurationException("PriceDataSettings is missing in the settings."));
        serviceCollection.AddSingleton(
            configuration.GetSection("UcommerceCsvImporter:PriceGroupDataSettings")
                .Get<PriceGroupDataConfiguration>()
            ?? throw new ConfigurationException("PriceGroupDataSettings is missing in the settings."));
        serviceCollection.AddSingleton(
            configuration.GetSection("UcommerceCsvImporter:ProductDataSettings").Get<ProductDataConfiguration>()
            ?? throw new ConfigurationException("ProductDataSettings is missing in the settings."));

        return serviceCollection.AddUcommerceDataImporter(configuration, typeof(Extensions).Assembly, settings);
    }
}