using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiscFishWebAPI.Models;
using WiscFishWebAPI.Repo;

namespace WiscFishWebAPI.Services
{
    public class PinsService : IPinsService
    {
        private readonly IPinsRepo _pinsRepo;

        public PinsService(IPinsRepo pinsRepo)
        {
            _pinsRepo = pinsRepo;
        }
        public async Task<IEnumerable<Pins>> GetPins()
        {
            return await _pinsRepo.GetPins();
        }

        public async Task<IEnumerable<Pins>> GetPins(string year)
        {
            return await _pinsRepo.GetPins(year);
        }

        public async Task PostPins(List<Pins> pins)
        {
            if (pins.Any())
            {
                foreach (var pin in pins)
                {
                    if (pin.Longitude.Contains(")"))
                    {
                        pin.Longitude = pin.Longitude.TrimEnd(new Char[] { ')', ']' });
                    }

                    await _pinsRepo.PostPins(pin);
                }
            }
        }

        public async Task PostPin(Pins pin)
        {
            if (pin.Longitude.Contains(")"))
            {
                pin.Longitude = pin.Longitude.TrimEnd(new Char[] { ')', ']' });
            }

            await _pinsRepo.PostPins(pin);
        }

        public async Task UpdatePin(Pins pins)
        {
            await _pinsRepo.UpdatePin(pins);
        }

        public async Task DeletePin(Pins pins)
        {
            pins.Active = false;
            await _pinsRepo.DeletePin(pins);
        }
    }
}
