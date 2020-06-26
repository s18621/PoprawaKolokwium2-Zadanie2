using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoprawaKolokwium_Zadanie2.DTOs;
using PoprawaKolokwium_Zadanie2.MyServices;

namespace PoprawaKolokwium_Zadanie2.Controllers
{
    //Tylko druga koncowka do sprawdzenia, tak jak się z Panem umawialem.
    [ApiController]
    [Route("api")]
    public class PetController : ControllerBase
    {
        private readonly DbServices _context;

        public PetController(DbServices context)
        {
            _context = context;
        }

        [HttpPost("/pets")]
        public IActionResult PostPet(PetRequest petRequest)
        {
            return Ok(_context.AddPet(petRequest));
        }
    }
}
