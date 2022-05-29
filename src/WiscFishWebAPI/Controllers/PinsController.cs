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

        [HttpPost]
        [Route("PostPinsList")]
        public async Task<IActionResult> PostPinsList([FromBody] List<Pins> pins)
        {
            _logger.LogInformation("post pin request");
            if (pins != null)
            {
                _logger.LogInformation("{@0}", pins);
                await _pinsService.PostPins(pins);
                return Ok();            
            }
            else
            {
                _logger.LogInformation("pin data missing");
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("PostPin")]
        public async Task<IActionResult> PostPins([FromBody] Pins pin)
        {
            _logger.LogInformation("post pin request");
            if (pin != null)
            {
                _logger.LogInformation("{@0}", pin);
                await _pinsService.PostPin(pin);
                return Ok();
            }
            else
            {
                _logger.LogInformation("pin data missing");
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdatePin")]
        public async Task<IActionResult> UpdatePins([FromBody] Pins pin)
        {
            _logger.LogInformation("update pin request");
            if (pin != null)
            {
                _logger.LogInformation("{@0}", pin);
                await _pinsService.UpdatePin(pin);
                return Ok();
            }
            else
            {
                _logger.LogInformation("pin data missing");
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("DeletePin")]
        public async Task<IActionResult> DeletePins([FromBody] Pins pin)
        {
            _logger.LogInformation("delete pin request");
            if (pin != null)
            {
                _logger.LogInformation("{@0}", pin);
                await _pinsService.DeletePin(pin);
                return Ok();
            }
            else
            {
                _logger.LogInformation("pin data missing");
                return BadRequest();
            }
        }
    }
}
