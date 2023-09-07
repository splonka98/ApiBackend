using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppCore.Models;
using Infractructure;

namespace DogCalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DogController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult CreateEdit (Dog dog)
        {
            if (dog.Id==0)
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

        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Dogs.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }
    }
}
