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

        public async Task<bool> PostPins(Pins pins)
        {
            return await _pinsRepo.PostPins(pins);
        }
    }
}
