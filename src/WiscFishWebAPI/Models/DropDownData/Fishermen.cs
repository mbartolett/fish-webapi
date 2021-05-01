using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WiscFishWebAPI.Models.DropDownData
{
    [Table("Pins.dbo.[Fishermen]")]
    public class Fishermen
    {
        public string Fisherman { get; set; }
    }
}
