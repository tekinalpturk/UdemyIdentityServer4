using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using UdemyIdentityServer4.Client1.Models;

namespace UdemyIdentityServer4.Client1.Controllers
{
    public class ProductsController : Controller
    {
        List<Product> products = new List<Product>();
        private readonly IConfiguration _configuration;
        public ProductsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            HttpClient httpClient = new HttpClient();

            var disco = await httpClient.GetDiscoveryDocumentAsync("https://localhost:5001");//I would prefer to add the addresses manually instead of an extra call
            if (disco.IsError) { return View("Error"); }

            ClientCredentialsTokenRequest clientCredentialsTokenRequest = new ClientCredentialsTokenRequest()
            {
                ClientId = _configuration["Client:ClientId"],
                ClientSecret = _configuration["Client:ClientSecret"],
                Address = disco.TokenEndpoint
            };

            var token = await httpClient.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest);
            if (token.IsError) { return View("Error"); }

            httpClient.SetBearerToken(token.AccessToken);

            var response = await httpClient.GetAsync("https://localhost:5016/api/Product/GetProducts");
            
            if (response.IsSuccessStatusCode)
            {
                var contest = await response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<Product>>(contest);
            }

            return View(products);
        }
    }
}
