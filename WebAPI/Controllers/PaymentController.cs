using Bussines.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardInformationsController : Controller
    {
        IRentalService _rentalService;
        public CardInformationsController(IRentalService RentalService)
        {
            _rentalService = RentalService;
        }

        [HttpPost("hire")]
        public IActionResult Hiring(CardInformations cardInformations)
        {
            IResult result = _rentalService.HireACar(cardInformations);
            if (!result.Succes)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
