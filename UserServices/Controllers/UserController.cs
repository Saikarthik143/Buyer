using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyerDB.Entity;
using BuyerDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserServices.Manager;

namespace UserServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _iUserManager;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserManager iUserManager, ILogger<UserController> logger)
        {
            _iUserManager = iUserManager;
            _logger = logger;
        }
        /// <summary>
        /// Register buyer
        /// </summary>
        /// <param name="buyer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Buyer(Buyer buyer)
        {

            _logger.LogInformation("Register");
            if (buyer is null)
            {
                return BadRequest("Buyer is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _logger.LogInformation("Succesfully Registered");
            return Ok(await _iUserManager.BuyerRegister(buyer));

        }
        /// <summary>
        /// Login Buyer
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> BuyerLogin(Login login)
        {
            _logger.LogInformation("User Login");
            Login login1 = await _iUserManager.BuyerLogin(login);
           
            if (login1 == null)
            {
                return Ok("Invalid User");
            }
            _logger.LogInformation($"Welcome{login1.userName}");
            return Ok(login1);
        }
    }
}