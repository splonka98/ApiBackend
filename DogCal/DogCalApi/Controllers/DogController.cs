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
        public DogController(ApiDbContext context, IDogService dogService)
        {
            _context = context;
            _dogService = dogService;
        }
        [Authorize]
        [HttpGet]
        public JsonResult SecuredEndpoint()
        {
            return new JsonResult(Ok("User Authorized"));
        }
        [Authorize]
        [HttpPost]
        public JsonResult CreateEdit(AddEditDogDto dogDto)
        {
            var userClaims = User.Claims.ToList();
            var userNameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).ToString();
            int userId = userNameClaim[userNameClaim.Length - 1] - '0';
            var usersDogs = _context.Dogs.ToList().Where(e => e.OwnerId == userId);

            var IsDogInDb = usersDogs.Where(e => e.Name == dogDto.Name).Any();


            Dog dog = new Dog();
            
            if (!IsDogInDb)
            {
                dog =_dogService.AddOrEditDog(dogDto.Id, dogDto.Name, dogDto.Weight, dogDto.ActivityLevel, userId);
                _dogService.CalculateCalories(dog);
                _context.Dogs.Add(dog);

            }
            else
            {
                var dogInDbByName = usersDogs.Where(e => e.Name == dogDto.Name).FirstOrDefault();
                dog = _dogService.AddOrEditDog(dogInDbByName.Id, dogDto.Name, dogDto.Weight, dogDto.ActivityLevel, userId);
                _dogService.CalculateCalories(dog);
                var dogInDb = usersDogs.Where(e => e.Name == dogDto.Name).FirstOrDefault();

                if (dogInDb == null)
                    return new JsonResult(NotFound());

                dogInDb = dog;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(dog));
        }
        [Authorize]
        [HttpGet]
        public JsonResult GetMyDogs()
        {
            var userClaims = User.Claims.ToList();
            var userNameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).ToString();
            int userId= userNameClaim[userNameClaim.Length - 1] - '0';

            var results = _context.Dogs.ToList()
                .Where(e => e.OwnerId == userId);
            if (results.Any())
                return new JsonResult(Ok(results));

            return new JsonResult(NotFound("No Dogs Found"));
        }
        [Authorize]
        [HttpDelete]
        public JsonResult Delete(string name)
        {
            var userClaims = User.Claims.ToList();
            var userNameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).ToString();
            int userId = userNameClaim[userNameClaim.Length - 1] - '0';
            var usersDogs = _context.Dogs.ToList().Where(e => e.OwnerId == userId);
            var dogInDb = usersDogs.Where(e => e.Name == name).FirstOrDefault();

            var result = dogInDb;
            if (result == null)
                return new JsonResult(NotFound());
            _context.Dogs.Remove(result);
            _context.SaveChanges();

            return new JsonResult(Ok($"Dog named {name} removed"));
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
