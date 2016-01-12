using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    class Monitoring
    {
        public ObjectId Id { get; set; }
        public string UnitID { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }
        public string Type { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
        public string Sum { get; set; }
    }
}
