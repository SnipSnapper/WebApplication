using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    class Connections
    {
        public ObjectId Id { get; set; }
        public string DateTime { get; set; }
        public string UnitID { get; set; }
        public string Port { get; set; }
        public string Value { get; set; }
    }
}
