using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WiscFishWebAPI.Models.DropDownData;

namespace WiscFishWebAPI.Repo
{
    public class DropDownDataRepo : IDropDownDataRepo
    {
        private readonly IConfiguration _config;
        private readonly ILogger<DropDownDataRepo> _logger;

        public DropDownDataRepo(IConfiguration config,
            ILogger<DropDownDataRepo> logger)
        {
            _config = config;
            _logger = logger;
        }
        public async Task<IEnumerable<Fishermen>> GetFishermen()
        {
            _logger.LogInformation("getting all fishermen from db");
            IEnumerable<Fishermen> fishermen = new List<Fishermen>();
            try
            {
                using (var con = new SqlConnection(_config.GetConnectionString("DefaultConnectionString")))
                {
                    const string query = "SELECT * FROM Fishermen";
                    con.Open();
                    fishermen = await con.QueryAsync<Fishermen>(query);
                }

            }
            catch (SqlException ex)
            {
                _logger.LogError("sql error {0}", ex.Message);
            }

            return fishermen;
        }

        public async Task<IEnumerable<Fish>> GetFish()
        {
            _logger.LogInformation("getting all fish types from db");
            IEnumerable<Fish> fish = new List<Fish>();
            try
            {
                using (var con = new SqlConnection(_config.GetConnectionString("DefaultConnectionString")))
                {
                    const string query = "SELECT * FROM Fish";
                    con.Open();
                    fish = await con.QueryAsync<Fish>(query);
                }

            }
            catch (SqlException ex)
            {
                _logger.LogError("sql error {0}", ex.Message);
            }

            return fish;
        }

        public async Task<IEnumerable<Years>> GetYears()
        {
            _logger.LogInformation("getting all years from db");
            IEnumerable<Years> years = new List<Years>();
            try
            {
                using (var con = new SqlConnection(_config.GetConnectionString("DefaultConnectionString")))
                {
                    const string query = "SELECT * FROM Years";
                    con.Open();
                    years = await con.QueryAsync<Years>(query);
                }

            }
            catch (SqlException ex)
            {
                _logger.LogError("sql error {0}", ex.Message);
            }

            return years;
        }
    }
}
