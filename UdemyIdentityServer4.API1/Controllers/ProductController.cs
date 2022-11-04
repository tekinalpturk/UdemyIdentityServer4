using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyIdentityServer4.API1.Models;

namespace UdemyIdentityServer4.API1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [Authorize("ReadProduct")]
        [HttpGet]
        public IActionResult GetProducts()
        {
            var productList = new List<Product>()
            {
                new Product(){Id=1,Name="Kalem",Price=101,Stock=501},
                new Product(){Id=2,Name="Silgi",Price=102,Stock=502},
                new Product(){Id=3,Name="Defter",Price=103,Stock=503},
                new Product(){Id=4,Name="Kitap",Price=104,Stock=504},
                new Product(){Id=5,Name="Bant",Price=105,Stock=505},
            };
            return Ok(productList);
        }

        [Authorize("UpdateOrCreate")]
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            return Ok($"Id'si {id} olan product güncellenmiştir");
        }

        [Authorize("UpdateOrCreate")]
        [HttpGet]
        public IActionResult CreateProduct(Product product)
        {
            return Ok(product);
        }
    }
}
