using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace WebApplication.Models
{
    class DBQuery
    {
        public static List<long> list = new List<long>();

        static void Main(string[] args)
        {
            //CallMain(args).Wait();
            //Console.ReadLine();

            //MongoDBConnection().Wait();
            //Console.ReadLine();

            Data();
            Console.ReadLine();
        }

        static async Task MongoDBConnection()
        {
            var client = new MongoClient("mongodb://145.24.222.117/test2");
            //var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Planetis");
            var collection = database.GetCollection<BsonDocument>("Positions");
            var filterBuilder = Builders<BsonDocument>.Filter;
            var filter = filterBuilder.Gt("Speed", 130) & filterBuilder.Lte("Speed", 160);

            await collection.Find(filter).ForEachAsync(d => Console.WriteLine(d));
        }

        static async Task CallMain(string[] args)
        {
            var Client = new MongoClient("mongodb://localhost:27017");
            var DB = Client.GetDatabase("Planetis");
            var collection = DB.GetCollection<BsonDocument>("Positions");
            //var filterPositions = Builders<BsonDocument>.Filter.Eq("Speed", "0");

            using (var cursor = await collection.Find(new BsonDocument()).ToCursorAsync())
            {
                while (await cursor.MoveNextAsync())
                {
                    foreach (var doc in cursor.Current)
                    {
                        Console.WriteLine(doc);
                    }
                }
            }
        }

        public static void Data()
        {
            try
            {
                var database = DBConnection.MongoConnection();
                var collection = database.GetCollection<Positions>("positions");

                var query = from c in collection.AsQueryable()
                            where c.Speed == 100
                            select c;


                foreach (Positions pos in query)
                {
                    //Console.WriteLine(pos.UnitID + " | " + pos.DateTime + " | " + pos.Speed);

                    long unitId = pos.UnitID;
                    list.Add(unitId);
                }
                    Console.ReadKey();
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Error: " + fe);
            }
            catch (MongoCommandException mce)
            {
                Console.WriteLine("Error: " + mce);
            }
        }

        static void getSignalStrenght()
        {
            try
            {
                MongoClient mc = new MongoClient("mongodb://localhost:27017");
                var db = mc.GetDatabase("Planetis");
                var collection = db.GetCollection<Monitoring>("Monitoring");
                var query = from c in collection.AsQueryable()
                                //where c.Type == "Hsdpa/RSCP" //&& c.Min == "38"
                            select c;

                foreach (Monitoring moni in query)
                {
                    Console.WriteLine(/*moni.UnitId, moni.BeginTime, moni.Min*/moni);
                }
                Console.ReadKey();
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Error: " + fe);
            }
        }
    }
}
