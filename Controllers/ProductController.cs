using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingProject.Services;
using ShoppingProject.Services.Interfaces;

namespace ShoppingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ISizeService _sizeService;

        public ProductController(IProductService productService, ISizeService sizeService)
        {
            _productService = productService;
            _sizeService = sizeService;
        }

        [Route("api/GetProductList")]
        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var productList = await _productService.GetAllProductsAsync();

            if(productList == null)
            {
                return NotFound();
            }

            return Ok(productList);
        }

        [Route("api/GetProductById")]
        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [Route("api/GetSizeByProduct")]
        [HttpGet]
        public async Task<IActionResult> GetSizeByProduct(int id)
        {
            var sizeList = await _sizeService.GetSizesByProductIdAsync(id);
            if (sizeList == null)
            {
                return NotFound();
            }
            return Ok(sizeList);
        }

        [Route("api/GetProductBySize")]
        [HttpGet]

        public async Task<IActionResult> GetProductBySize(string size)
        {

            var productList = await _sizeService.GetProductBySizeAsync(size.ToUpper());

            if (productList == null)
            {
                return NotFound();
            }
            return Ok(productList);
        }
    }
}
