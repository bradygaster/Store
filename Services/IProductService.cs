using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Store.Services
{
    public interface IProductService
    {
        Task<Product[]> GetProductsAsync();
    }
}