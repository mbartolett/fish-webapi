using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiscFishWebAPI.Models.DropDownData;
using WiscFishWebAPI.Repo;

namespace WiscFishWebAPI.Services
{
    public class DropDownDataService : IDropDownDataService
    {
        private readonly IDropDownDataRepo _dropDownDataRepo;

        public DropDownDataService(IDropDownDataRepo dropDownDataRepo)
        {
            _dropDownDataRepo = dropDownDataRepo;
        }
        public async Task<IEnumerable<Fish>> GetFish()
        {
            return await _dropDownDataRepo.GetFish();
        }

        public async Task<IEnumerable<Fishermen>> GetFishermen()
        {
            return await _dropDownDataRepo.GetFishermen();
        }

        public async Task<IEnumerable<Years>> GetYears()
        {
            return await _dropDownDataRepo.GetYears();
        }
    }
}
