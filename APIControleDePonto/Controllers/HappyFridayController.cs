using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Validators;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HappyFridayController : ControllerBase
    {
        private IBaseService<HappyFriday> _baseHappyService;
        private IHappyFridayService _happyService;


        public HappyFridayController(IBaseService<HappyFriday> baseHappyService
            , IHappyFridayService happyService)
        {
            _baseHappyService = baseHappyService;
            _happyService = happyService;

        }



        [HttpGet]
        [Route("byCompanyId")]
        public IActionResult GetHappyByCompanyIdAndYearAndMonth([FromQuery] int idCompany, [FromQuery] int year, [FromQuery] int month)
        {
            return Execute(() => _happyService.GetHappyFridayByCompanyId(idCompany, year, month));
        }

        [HttpGet]
        [Route("GetAllHappyFriday")]
        public IActionResult Get()
        {
            return Execute(() => _happyService.GetAll());
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] HappyFridayViewModel happyFriday)
        {
            if (happyFriday == null)
                return NotFound();

            return Execute(() => _happyService.Create(happyFriday));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
