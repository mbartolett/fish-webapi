using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiscFishWebAPI.Models;

namespace WiscFishWebAPI.Repo
{
    public interface IPinsRepo
    {
        Task<IEnumerable<Pins>> GetPins();
        Task<IEnumerable<Pins>> GetPins(string year);
        Task<bool> PostPins(Pins pins);
    }
}
