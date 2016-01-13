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
        public long UnitID { get; set; }
        public double RDX { get; set; }
        public double RDY { get; set; }
        public int Speed;
        public int Course { get; set; }
        public int NumSatellites { get; set; }
        public int HDOP { get; set; }
        public string Quality { get; set; }

        public void setSpeed(String speed)
        {
            this.Speed = int.Parse(speed);
        }

        public int getSpeed()
        {
            return this.Speed;
        }

        public void setUnitId(String unitId)
        {
            this.Speed = int.Parse(unitId);
        }

        public long getUnitId()
        {
            return this.UnitID;
        }

        public void setRdx(String rdx)
        {
            this.RDX = double.Parse(rdx);
        }

        public double getrdx()
        {
            return this.RDX;
        }

        public void setRdy(String rdy)
        {
            this.RDY = double.Parse(rdy);
        }

        public double getRdy()
        {
            return this.RDY;
        }

        public void setCourse(String course)
        {
            this.Course = int.Parse(course);
        }

        public double getCourse()
        {
            return this.Course;
        }

        public void setNumSatellites(String numSatellites)
        {
            this.NumSatellites = int.Parse(numSatellites);
        }

        public double getNumSatellites()
        {
            return this.NumSatellites;
        }

        public void setHDOP(String hdop)
        {
            this.HDOP = int.Parse(hdop);
        }

        public int getHDOP()
        {
            return this.HDOP;
        }

    }
}
