using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyerDB.Entity;
using BuyerService.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuyerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerManager _iBuyerManager;

        public BuyerController(IBuyerManager iBuyerManager)
        {
            _iBuyerManager = iBuyerManager;
        }
        [HttpPost]
        [Route("EditProfile")]
        public async Task<IActionResult> EditBuyerProfile(Buyer buyer)
        {
            return Ok(await _iBuyerManager.EditBuyerProfile(buyer));

        }
        [HttpGet]
        [Route("Profile/{bid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBuyerProfile(string buyerId)
        {
            Buyer buyer = await _iBuyerManager.GetBuyerProfile(buyerId);
            if (buyer == null)
                return Ok("Invalid User");
            else
            {
                return Ok(buyer);
            }

        }
    }
}
    
