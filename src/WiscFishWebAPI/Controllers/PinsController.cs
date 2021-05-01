using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiscFishWebAPI.Models;
using WiscFishWebAPI.Services;

namespace WiscFishWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PinsController : ControllerBase
    {
        private readonly IPinsService _pinsService;
        private readonly ILogger<PinsController> _logger;

        public PinsController(IPinsService pinsService,
            ILogger<PinsController> logger)
        {
            _pinsService = pinsService;
            _logger = logger;
        }

        // GET: api/Pins
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("get request for all pins");
            var pins = await _pinsService.GetPins();

            if (pins != null)
            {
                _logger.LogInformation("returning pins");
                return Ok(pins);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/Pins/5
        [HttpGet("{year}", Name = "Get")]
        public async Task<IActionResult> Get(string year)
        {
            _logger.LogInformation("get request for all pins for year {0}", year);
            if (!string.IsNullOrWhiteSpace(year))
            {
                var pins = await _pinsService.GetPins(year);

                if (pins != null)
                {
                    _logger.LogInformation("returning pins");
                    return Ok(pins);
                }
                else
                {
                    _logger.LogInformation("no pins found");
                    return NotFound();
                }
            }
            else
            {
                _logger.LogInformation("year is empty");
                return BadRequest();
            }            
        }

        // POST: api/Pins
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pins Pin)
        {
            _logger.LogInformation("post pin request");
            if (Pin != null)
            {
                _logger.LogInformation("{@0}", Pin);
                var inserted = await _pinsService.PostPins(Pin);

                if(!inserted)
                {
                    return NotFound();
                }
                else
                {
                    return Ok();
                }
            }
            else
            {
                _logger.LogInformation("pin data missing");
                return BadRequest();
            }
        }
    }
}
