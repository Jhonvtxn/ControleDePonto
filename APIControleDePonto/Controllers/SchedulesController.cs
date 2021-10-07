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
        private IBaseService<Schedules> _baseSchedulesService;
        private ISchedulesService _Schedulesservice;


        public SchedulesController(IBaseService<Schedules> baseSchedulesService
            , ISchedulesService SchedulesService)
        {
            _baseSchedulesService = baseSchedulesService;
            _Schedulesservice = SchedulesService;
        }

        [HttpPut]
        public IActionResult Update([FromBody] Schedules schedule)
        {
            if (schedule == null)
                return NotFound();

            return Execute(() => _baseSchedulesService.Update<SchedulesValidator>(schedule));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseSchedulesService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Schedules schedule)
        {
            if (schedule == null)
                return NotFound();

            return Execute(() => _baseSchedulesService.Add<SchedulesValidator>(schedule).Id);
        }

        [HttpPost]
        [Route("AutoSchedule")]
        public IActionResult AutoSchedule(int id, int adtype)
        {
            var auto_schedule = new Schedules();
            auto_schedule.CollaboratorId = id;

            if (adtype == 1)
            {
                auto_schedule.Entry = DateTime.Now;
                
            }
            else if (adtype == 2)
            {
                auto_schedule.LunchTime = DateTime.Now;
            }
            else if (adtype == 3)
            {
                auto_schedule.ReturnLunchTime = DateTime.Now;
            }
            else {

                auto_schedule.DepartureTime = DateTime.Now;
                
            }
            return Execute(() => _baseSchedulesService.Add<SchedulesValidator>(auto_schedule).Id);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _Schedulesservice.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseSchedulesService.GetById(id));
        }

        [HttpGet]
        [Route("CollaboratorSchedulesByToday/{id}")]

        public IActionResult CollaboratorSchedulesByUserByToday (int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _Schedulesservice.GetSchedulesByUserByToday(id));

        }

        [HttpGet]
        [Route("CollaboratorSchedules")]
        public IActionResult GetSchedulesByUser(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _Schedulesservice.GetSchedulesByUserId(id));
        }

        [HttpGet]
        [Route("BeatTime")]
        public IActionResult BeatTime(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _Schedulesservice.BeatTime(id));
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