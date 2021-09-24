using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private IBaseService<Schedules> _baseScheduleService;
        private ISchedulesService _Scheduleservice;


        public SchedulesController(IBaseService<Schedules> baseScheduleService
            , ISchedulesService ScheduleAplicattionService)
        {
            _baseScheduleService = baseScheduleService;
            _Scheduleservice = ScheduleAplicattionService;
        }



        [HttpPut]
        public IActionResult Update([FromBody] Schedules schedule)
        {
            if (schedule == null)
                return NotFound();

            return Execute(() => _baseScheduleService.Update<SchedulesValidator>(schedule));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseScheduleService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Schedules schedule)
        {
            if (schedule == null)
                return NotFound();

            return Execute(() => _baseScheduleService.Add<SchedulesValidator>(schedule).Id);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _Scheduleservice.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseScheduleService.GetById(id));
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