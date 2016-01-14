using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Vector2
    {
        private string lnd;
        private string ltd;

        public string Lnd
        {
            get
            {
                return lnd;
            }

            set
            {
                lnd = value;
            }
        }

        public string Ltd
        {
            get
            {
                return ltd;
            }

            set
            {
                ltd = value;
            }
        }

        public Vector2(string lnd, string ltd)
        {
            this.Lnd = lnd;
            this.Ltd = ltd;
        }

        

    }
}