using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Services;

namespace Store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private IProductService _productService;

        public ProductController(ILogger<ProductController> logger,
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [ApiVersion("1.0")]
        [ApiVersion("1.1")]
        [HttpGet(Name = nameof(GetProducts))]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productService.GetProductsAsync();
        }

        [ApiVersion("1.1")]
        [HttpPost(Name = nameof(CreateProduct))]
        public Product CreateProduct([FromBody] Product product)
        {
            return product;
        }
    }
}
