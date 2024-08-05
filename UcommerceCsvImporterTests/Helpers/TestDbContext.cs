using Microsoft.EntityFrameworkCore;
using Ucommerce.DataImport.Core.Models;
using UcommerceCsvImporterTests.TestModels;
using CurrencyData = UcommerceCsvImporterTests.TestModels.CurrencyData;
using PriceData = UcommerceCsvImporterTests.TestModels.PriceData;
using PriceGroupData = UcommerceCsvImporterTests.TestModels.PriceGroupData;
using ProductData = UcommerceCsvImporterTests.TestModels.ProductData;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace UcommerceCsvImporterTests.Helpers;

public class TestDbContext(DbContextOptions<TestDbContext> options, DataImporterSettings dataImporterSettings)
    : DbContext(options)
{
    public DbSet<CurrencyData> Currencies { get; init; }
    public DbSet<PriceData> Prices { get; init; }
    public DbSet<PriceGroupData> PriceGroups { get; init; }
    public DbSet<ProductData> Products { get; init; }
    public DbSet<ProductPriceData> ProductPrices { get; init; }

    #region Configuration
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(dataImporterSettings.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var currencyBuilder = modelBuilder.Entity<CurrencyData>();
            currencyBuilder.ToTable("uCommerce_Currency");
            currencyBuilder.Property(x => x.Id).HasColumnName("CurrencyId");
            currencyBuilder.Property(x => x.ISOCode)
                .IsRequired();
            currencyBuilder.Property(x => x.Deleted)
                .IsRequired();
            currencyBuilder.Property(x => x.ExternalIdentifier);
            
        var priceBuilder = modelBuilder.Entity<PriceData>();
        priceBuilder.ToTable("uCommerce_Price");
        priceBuilder.Property(x => x.Id).HasColumnName("PriceId");
        priceBuilder.Property(x => x.Amount)
            .IsRequired();
        priceBuilder.Property(x => x.ExternalIdentifier);
        priceBuilder.HasOne(x => x.PriceGroup)
            .WithMany()
            .HasForeignKey("PriceGroupId");
        
        var priceGroupBuilder = modelBuilder.Entity<PriceGroupData>();
        priceGroupBuilder.ToTable("uCommerce_PriceGroup");
        priceGroupBuilder.Property(x => x.Id).HasColumnName("PriceGroupId");
        priceGroupBuilder.Property(x => x.Name)
            .IsRequired();
        priceGroupBuilder.Property(x => x.ExternalIdentifier);
        priceGroupBuilder.Property(x => x.VatRate)
            .HasColumnName("VATRate")
            .HasPrecision(18, 2)
            .IsRequired();
        priceGroupBuilder.Property(x => x.Description);
        priceGroupBuilder.HasOne(x => x.BasePriceGroup)
            .WithMany(x => x.DerivedPriceGroups)
            .HasForeignKey("BasePriceGroupId");
        priceGroupBuilder.HasOne(x => x.Currency)
            .WithMany()
            .HasForeignKey("CurrencyId");
        
        var productBuilder = modelBuilder.Entity<ProductData>();
        productBuilder.ToTable("Ucommerce_Product");
        productBuilder.Property(x => x.Id).HasColumnName("ProductId");
        productBuilder.Property(x => x.Sku)
            .IsRequired();
        productBuilder.Property(x => x.VariantSku)
            .IsRequired(false);
        productBuilder.Property(x => x.Name)
            .IsRequired();
        productBuilder.Property(x => x.DisplayOnSite);
        productBuilder.HasOne(x => x.Parent)
            .WithMany(x => x.Variants)
            .HasForeignKey("ParentProductId");
        productBuilder.HasMany(x => x.Prices)
            .WithOne(x => x.Product)
            .HasForeignKey("ProductId");
        
        var productPriceBuilder= modelBuilder.Entity<ProductPriceData>();
        productPriceBuilder.ToTable("uCommerce_ProductPrice");
        productPriceBuilder.Property(x => x.Id).HasColumnName("ProductPriceId");
        productPriceBuilder.Property(x => x.MinimumQuantity);
        productPriceBuilder.HasOne(x => x.Price)
            .WithMany()
            .HasForeignKey("PriceId");
    }
    #endregion
}