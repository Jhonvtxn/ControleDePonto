using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class DashboardController : ControllerBase
    {
        private IBaseService<Dashboard> _baseDashboardService;
        private IDashboardService _dashboardservice;


        public DashboardController(IBaseService<Dashboard> baseDashboardService
            , IDashboardService DashboardService)
        {
            _baseDashboardService = baseDashboardService;
            _dashboardservice = DashboardService;
        }

        [HttpPut]
        public IActionResult Update([FromBody] Dashboard dashboard)
        {
            if (dashboard == null)
                return NotFound();

            return Execute(() => _baseDashboardService.Update<DashboardValidator>(dashboard));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Dashboard dashboard)
        {
            if (dashboard == null)
                return NotFound();

            return Execute(() => _baseDashboardService.Add<DashboardValidator>(dashboard).Id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseDashboardService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _dashboardservice.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseDashboardService.GetById(id));
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