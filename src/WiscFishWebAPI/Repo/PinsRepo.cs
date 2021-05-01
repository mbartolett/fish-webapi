using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WiscFishWebAPI.Models;

namespace WiscFishWebAPI.Repo
{
    public class PinsRepo : IPinsRepo
    {
        private readonly IConfiguration _config;
        private readonly ILogger<PinsRepo> _logger;

        public PinsRepo(IConfiguration config,
            ILogger<PinsRepo> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task<IEnumerable<Pins>> GetPins()
        {
            _logger.LogInformation("getting all pins from db");
            IEnumerable<Pins> pins = new List<Pins>();
            try
            {
                using (var con = new SqlConnection(_config.GetConnectionString("DefaultConnectionString")))
                {
                    const string query = "SELECT * FROM PINS";
                    con.Open();
                    pins = await con.QueryAsync<Pins>(query);
                }
                
            }
            catch(SqlException ex)
            {
                _logger.LogError("sql error {0}", ex.Message);
            }

            return pins;
        }

        public async Task<IEnumerable<Pins>> GetPins(string year)
        {
            IEnumerable<Pins> pins = new List<Pins>();
            if (year == "All")
            {
                try
                {
                    using (var con = new SqlConnection(_config.GetConnectionString("DefaultConnectionString")))
                    {
                        const string query = "SELECT * FROM PINS";
                        con.Open();
                        pins = await con.QueryAsync<Pins>(query);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("sql error {0}", ex.Message);
                }
            }
            else
            {
                try
                {
                    using (var con = new SqlConnection(_config.GetConnectionString("DefaultConnectionString")))
                    {
                        const string query = "SELECT * FROM PINS WHERE DATE LIKE @year";
                        con.Open();
                        pins = await con.QueryAsync<Pins>(query, new { @year = "%" + year + "%" });
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("sql error {0}", ex.Message);
                }
            }

            return pins;
        }

        public async Task<bool> PostPins(Pins pins)
        {
            bool inserted = false;
            try
            {
                using (var con = new SqlConnection(_config.GetConnectionString("DefaultConnectionString")))
                {
                    con.Open();
                    var id = await con.InsertAsync(new Pins { Name = pins.Name, FishType = pins.FishType, Latitude = pins.Latitude, Longitude = pins.Longitude, Date = pins.Date });

                    inserted = id != 0;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("sql error {0}", ex.Message);
            }

            return inserted;
        }
    }
}
