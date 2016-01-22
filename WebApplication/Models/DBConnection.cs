using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;


/// <summary>
/// this class connects to the database.
/// </summary>
namespace WebApplication.Models
{
    class DBConnection
    {
        static IMongoClient client;
        static IMongoDatabase database;

        // make a connection with the database.
        public static IMongoDatabase MongoConnection() {

            client = new MongoClient("mongodb://145.24.222.117/Planetis3");
            database = client.GetDatabase("Planetis3");

            return database;

        }
    }
}
