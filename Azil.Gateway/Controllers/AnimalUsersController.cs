using Azil.Gateway.DTOs.AnimalUser;
using Azil.Gateway.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace Azil.Gateway.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "Admin, User")]
    public class AnimalUsersController : ControllerBase
    {
        private readonly HttpClient httpClient;
        private readonly Urls url;
        private readonly IHttpContextAccessor acc;
        public AnimalUsersController(HttpClient httpClient, IOptions<Urls> url, IHttpContextAccessor acc)
        {
            this.httpClient = httpClient;
            this.url = url.Value;
            this.acc = acc;
        }

        [HttpGet("get-all-animal-user")]
        public async Task<IActionResult> GetAnimals()
        {
            try
            {
                var response = await httpClient.GetAsync(url.AnimalUser + "/animal_users");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var animals = JsonConvert.DeserializeObject<AnimalUserDto>(content);
                    return Ok(animals);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    error = ex.Message.ToString()
                });
            }  
        }

        [HttpPost("take-animal")]
        public async Task<IActionResult> TakeAnimal([FromBody]AnimalUserRequestDto request)
        {
            int userId = int.Parse(acc.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value);
            if (userId < 0)
            {
                return BadRequest();
            }
            var newRequest = new TakeAnimaDto
            {
                animal_id = request.AnimalId,
                user_id = userId
            };
            var response = await httpClient.GetAsync(url.Animal + "/check-animal/" + newRequest.animal_id);
            if (response.IsSuccessStatusCode)
            {
                var jsonRequest = JsonConvert.SerializeObject(newRequest);
                var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                response = await httpClient.PostAsync(url.AnimalUser + "/animal_user", httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var animal = JsonConvert.DeserializeObject<AnimalUserResponseDto>(content);
                    return Ok(animal);
                }
                return BadRequest();
            }
            return BadRequest();
        }
    }
}
