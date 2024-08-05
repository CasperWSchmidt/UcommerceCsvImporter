This project is a flexible implementation of the [Ucommerce Data Importer](https://dev.ucommerce.net/ucommerce-next-gen/data-import) for CSV files. To get started, all you need to do is add your configuration to appsettings.json as shown in [The test project appsettings.json](https://github.com/CasperWSchmidt/UcommerceCsvImporter/blob/main/UcommerceCsvImporterTests/appsettings.json) and remember to add the CSV importer to your service collection like below:

```
services.AddUcommerceCsvImporter(configuration);
```

Optionally you can add your `DataImporterSettings` (see the Ucommerce documentation) to the call:

```
services.AddUcommerceCsvImporter(configuration, settings);
```

You can now get an instance of `DataImporter` from `Ucommerce.DataImport.Core` and use it to import your CSV data!
