using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Store.Services
{
    public class MemoryCacheProductService : IProductService
    {
        public MemoryCacheProductService(IMemoryCache memoryCache)
        {
            MemoryCache = memoryCache;
            GenerateSampleDataAsync();
        }

        public IMemoryCache MemoryCache { get; }
        private List<Product> Products { get; set; }

        public void GenerateSampleDataAsync()
        {
            Products = new List<Product>();
            Products.Add(new Product(1, "Vinyl Record", .99));
            Products.Add(new Product(2, "Cassette Tape", 2.99));
            Products.Add(new Product(3, "Compact Disc", 5.99));

            MemoryCache.Set<List<Product>>(nameof(Products), Products);
        }

#pragma warning disable CS1998
        public async Task<Product[]> GetProductsAsync()
        {
            Products = MemoryCache.Get<List<Product>>(nameof(Products));
            return Products.ToArray();
        }
#pragma warning restore CS1998
    }
}