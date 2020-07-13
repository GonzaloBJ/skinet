using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsData =
                        File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        var newBrand = new ProductBrand(){Name = item.Name};
                        context.ProductBrands.Add(newBrand);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var typesData = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        var newType = new ProductType(){Name = item.Name};
                        context.ProductTypes.Add(newType);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var productsData = 
                        File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        /** var newProduct = new Product(){
                            Name = item.Name,
                            Description = item.Description,
                            Price = item.Price,
                            PictureUrl = item.PictureUrl,
                            ProductBrand = new ProductBrand(), 
                            ProductBrandId = item.ProductBrandId,
                            ProductType = new ProductType(), 
                            ProductTypeId = item.ProductTypeId
                            
                        };**/
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.InnerException.Message);
            }
        }
    }
}