using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ucommerce.DataImport.Core;
using UcommerceCsvImporter;
using UcommerceCsvImporter.Exceptions;

namespace UcommerceCsvImporterTests.Helpers;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class TestFixture
{
    private readonly IServiceProvider _serviceProvider;
    
    public TestFixture()
    {
        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, false)
            .Build();
        services.AddUcommerceCsvDataImporter(configuration);
        var connectionString = configuration.GetSection("Ucommerce:DataImport:ConnectionString").Value ??
                           throw new ConfigurationException("ConnectionString is missing");
        services.AddSqlServer<TestDbContext>(connectionString);
        _serviceProvider = services.BuildServiceProvider();
        var dataImporter = _serviceProvider.GetRequiredService<DataImporter>();
        dataImporter.Run().Wait();
    }
    
    public AsyncServiceScope CreateScope() => _serviceProvider.CreateAsyncScope();
}