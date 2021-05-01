using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiscFishWebAPI.Services;

namespace WiscFishWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropDownDataController : ControllerBase
    {
        private readonly IDropDownDataService _dropDownDataService;
        private readonly ILogger<DropDownDataController> _logger;
        public DropDownDataController(IDropDownDataService dropDownDataService,
            ILogger<DropDownDataController> logger)
        {
            _dropDownDataService = dropDownDataService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetFish")]
        public async Task<IActionResult> GetFish()
        {
            _logger.LogInformation("gettign fish");
            var fish = await _dropDownDataService.GetFish();

            if (fish != null)
            {
                _logger.LogInformation("fish found");
                return Ok(fish);
            }
            else
            {
                _logger.LogInformation("no fish found");
                return NoContent();
            }
        }

        [HttpGet]
        [Route("GetFishermen")]
        public async Task<IActionResult> GetFishermen()
        {
            _logger.LogInformation("gettign fishermen");
            var fishermen = await _dropDownDataService.GetFishermen();

            if (fishermen != null)
            {
                _logger.LogInformation("fishermen found");
                return Ok(fishermen);
            }
            else
            {
                _logger.LogInformation("no fishermen found");
                return NoContent();
            }
        }

        [HttpGet]
        [Route("GetYears")]
        public async Task<IActionResult> GetYears()
        {
            _logger.LogInformation("gettign years");
            var years = await _dropDownDataService.GetYears();

            if (years != null)
            {
                _logger.LogInformation("years found");
                return Ok(years);
            }
            else
            {
                _logger.LogInformation("no years found");
                return NoContent();
            }
        }
    }
}
