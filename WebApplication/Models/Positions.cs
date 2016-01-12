using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    class Positions
    {
        public ObjectId Id { get; set; }
        public string DateTime { get; set; }
        public string UnitID { get; set; }
        public string RDX { get; set; }
        public string RDY { get; set; }
        public string Speed { get; set; }
        public string Course { get; set; }
        public string NumSatellites { get; set; }
        public string HDOP { get; set; }
        public string Quality { get; set; }
    }
}
