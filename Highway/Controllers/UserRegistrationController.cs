using Highway.Entities;
using Highway.Models.UserModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Highway.Controllers
{
    [Route("api/register", Name ="Register")]
    public class UserRegistrationController: Controller
    {
        private UserManager<User> _userManager;

        public UserRegistrationController(UserManager<User> userManager)
        {
            _userManager = userManager;

        }

        [HttpPost]
        public async Task<object> CreateUser([FromBody] UserModelForCreationDto user)
        {
            var applicationUser = new User()
            {
                LastName = user.LastName,
                FirstName = user.FirstName,
                UserName = user.Username,
                Email = user.Email,
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, user.Password);
                return Ok(result);
            }

            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
