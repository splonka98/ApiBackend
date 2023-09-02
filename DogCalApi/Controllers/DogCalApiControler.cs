using AppCore.Models;
using DogCalApi.Dto;
using Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace DogCalApi.Controllers
{
    [Route("[api/dogcal]")]
    [ApiController]
    public class DogCalApiControler : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public DogCalApiControler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("get-all-dogs")]
        public IEnumerable<GetDogDto> GetAllMyDogs([FromQuery] List<int> dogIds)
        {
            IEnumerable<GetDogDto> result = new List<GetDogDto>();



            return result;
        }
        [HttpGet("by-owner")]
        public async Task<IActionResult> GetDogsByOwnerId([FromQuery] int ownerId)
        {
            try
            {
                var dogs = await _dbContext.Dogs
                    .Where(d => d.OwnerId == ownerId)
                    .ToListAsync();

                if (dogs == null || !dogs.Any())
                {
                    return NotFound("Nie znaleziono psów dla podanego ownerId.");
                }

                return Ok(dogs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Wystąpił błąd: {ex.Message}");
            }
        }
        [HttpPost("addMyDog")]
        
        public IActionResult AddDog([FromBody] AddDogDto dog)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var newDog = new AddDogDto
            {
                Name = dog.Name,
                Age = dog.Age,
                Weight = dog.Weight,
                OwnerId = dog.OwnerId // Przypisz Id zalogowanego użytkownika jako właściciela psa
            };
            return CreatedAtRoute("GetDogById", new { id = newDog.Id }, newDog);
        }

    }
}
