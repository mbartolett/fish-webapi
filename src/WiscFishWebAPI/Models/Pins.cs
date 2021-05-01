using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WiscFishWebAPI.Models
{
    [Table("Pins")]
    public class Pins
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FishType { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime Date { get; set; }
    }
}
