using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiscFishWebAPI.Models.DropDownData;

namespace WiscFishWebAPI.Repo
{
    public interface IDropDownDataRepo
    {
        Task<IEnumerable<Fishermen>> GetFishermen();
        Task<IEnumerable<Years>> GetYears();
        Task<IEnumerable<Fish>> GetFish();
    }
}
