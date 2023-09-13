using AccountMicroServisApi.Dtos;
using AppCore.Interfaces;
using AppCore.Models;
using Infrastructure;
using Infrastructure.Entities;
using Infrastructure.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AccountMicroServisApi.Controllers
{
    [Route("api/accountService/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AccountMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly ApiDbContext _apiDbContext;
        IConfiguration _configuration;
        public UserController(ApiDbContext apiDbContext, IAccountService accountService, AccountMapper mapper, IConfiguration configuration)
        {
            _apiDbContext = apiDbContext;
            _accountService = accountService;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        public JsonResult Register([FromBody]RegisterUserDto user)
        {
            _apiDbContext.Users.Add(_mapper.UserModelToEntity(_accountService.RegisterUser(user.Email,user.Password, user.FirstName, user.LastName, user.RoleId)));

            _apiDbContext.SaveChanges();

            return new JsonResult(Ok(user));
        }
        [HttpPost]
        public JsonResult Login([FromBody]LoginDto userLogin)
        {
            if(userLogin != null)
            {
                var resultOfCheckDb = _apiDbContext.Users
                    .Where(l => l.Email == userLogin.Email && l.Password == userLogin.Password)
                    .FirstOrDefault();
                string token;
                if (resultOfCheckDb != null)
                {
                    User user = _mapper.UserEntityToModel(resultOfCheckDb);
                    token =_accountService.GenerateJwt(resultOfCheckDb.Email, resultOfCheckDb.Password, user, _configuration);
                }
                else return new JsonResult(NotFound());

                return new JsonResult(Ok(token));
            }
            else return new JsonResult(NotFound());
        }
    }
}
