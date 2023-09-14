using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppCore.Models;
using Infractructure;
using AppCore.Interfaces;
using DogCalApi.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Net.Http.Headers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace DogCalApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IDogService _dogService;
        private string[] _claims;
        HttpClient _client;
        public DogController(ApiDbContext context, IDogService dogService, HttpClient client)
        {
            _context = context;
            _dogService = dogService;
            _client = client;
        }
        [Authorize]
        [HttpGet]
        public JsonResult SecuredEndpoint(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var readenToken = tokenHandler.ReadToken(token);
            if (readenToken == null) return new JsonResult(NotFound());
            
            // Pobierz konkretny claim na podstawie jego typu (nazwy).
            var nameIdentifierClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            // Jeśli dotarliśmy do tego miejsca, to token jest poprawny.
            // Kod, który dostarcza chronione dane.
            return new JsonResult(Ok(token));
        }
        [Authorize]
        [HttpPost]
        public JsonResult CreateEdit(AddEditDogDto dogDto)
        {
            var userClaims = User.Claims.ToList();
            var userId= User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            Dog dog = _dogService.AddOrEditDog(dogDto.Id, dogDto.Name, dogDto.Weight, dogDto.ActivityLevel, dogDto.OwnerId);
            _dogService.CalculateCalories(dog);
            if (dog.Id == 0)
            {
                _context.Dogs.Add(dog);

            }
            else
            {
                var dogInDb = _context.Dogs.Find(dog.Id);

                if (dogInDb == null)
                    return new JsonResult(NotFound());

                dogInDb = dog;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(dog));
        }
        [Authorize]
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Dogs.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Dogs.Find(id);
            if (result == null)
                return new JsonResult(NotFound());
            _context.Dogs.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
        [Authorize(Roles = "1")]
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Dogs.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
