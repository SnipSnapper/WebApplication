﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WebApplication.Models
{
    class DBConnection
    {
        static IMongoClient client;
        static IMongoDatabase database;


        public static IMongoDatabase MongoConnection() {

            client = new MongoClient("mongodb://145.24.222.117:27017");
            database = client.GetDatabase("Planetis");

            return database;

        }
    }
}
