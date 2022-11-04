using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyIdentityServer4.API2.Models;

namespace UdemyIdentityServer4.API2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult GetPictures()
        {
            var pictures = new List<Picture>()
            {
                new Picture(){Id=1,Name="Doğa Resmi",Url="dogaresmi.jpg"},
                new Picture(){Id=2,Name="fil Resmi",Url="dogaresmi.jpg"},
                new Picture(){Id=3,Name="aslan Resmi",Url="dogaresmi.jpg"},
                new Picture(){Id=4,Name="fare Resmi",Url="dogaresmi.jpg"},
                new Picture(){Id=5,Name="kedi Resmi",Url="dogaresmi.jpg"},
                new Picture(){Id=6,Name="köpek Resmi",Url="dogaresmi.jpg"},
            };
            return Ok(pictures);
        }
    }
}
