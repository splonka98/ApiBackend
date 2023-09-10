﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppCore.Models;
using Infractructure;
using AppCore.Interfaces;
using DogCalApi.Dtos;

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

        [HttpPost]
        public JsonResult CreateEdit(AddEditDogDto dogDto)
        {
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

        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Dogs.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
