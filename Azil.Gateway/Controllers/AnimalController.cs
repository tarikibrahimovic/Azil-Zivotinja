using Azil.Gateway.DTOs.Animal;
using Azil.Gateway.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Azil.Gateway.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "Admin,User")]
    public class AnimalController : ControllerBase
    {
        private readonly HttpClient httpClient;
        private readonly Urls url;

        public AnimalController(HttpClient httpClient, IOptions<Urls> url)
        {
            this.httpClient = httpClient;
            this.url = url.Value;
        }

        [HttpPost("register-animal")]
        public async Task<IActionResult> AddAnimal([FromBody] AnimalRegisterDto request)
        {
            var jsonRequest = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url.Animal + "/register-animal", httpContent);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var animal = JsonConvert.DeserializeObject<Animal>(content);
                return Ok(animal);
            }
            return BadRequest();
        }

        [HttpGet("get-all-animals")]
        public async Task<IActionResult> GetAnimals()
        {
            var response = await httpClient.GetAsync(url.Animal + "/get-all-animals");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var animals = JsonConvert.DeserializeObject<List<Animal>>(content);
                return Ok(animals);
            }
            return BadRequest();
        }
    }
}
