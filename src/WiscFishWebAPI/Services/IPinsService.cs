using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiscFishWebAPI.Models;

namespace WiscFishWebAPI.Services
{
    public interface IPinsService
    {
        Task<IEnumerable<Pins>> GetPins();
        Task<IEnumerable<Pins>> GetPins(string year);
        Task PostPins(List<Pins> pins);
        Task PostPin(Pins pins);
        Task UpdatePin(Pins pins);
        Task DeletePin(Pins pins);
       
    }
}
