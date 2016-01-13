using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication.Models
{
    class DBQuery
    {

        static async void Main(string[] args)
        {
            //CallMain(args).Wait();
            //Console.ReadLine();

            //MongoDBConnection().Wait();
            //Console.ReadLine();
            
            Console.ReadLine();
        }

        //public static void Data()
        //{
        //    try
        //    {
        //        var database = DBConnection.MongoConnection();
        //        var collection = database.GetCollection<Positions>("positions");

        //        var query = from c in collection.AsQueryable()
        //                    where c.Speed == 100
        //                    select c;

        //        foreach (Positions pos in query)
        //        {
        //            //Console.WriteLine(pos.UnitID + " | " + pos.DateTime + " | " + pos.Speed);

        //            long unitId = pos.UnitID;
        //            list.Add(unitId);
        //        }
        //            Console.ReadKey();
        //    }
        //    catch (FormatException fe)
        //    {
        //        Console.WriteLine("Error: " + fe);
        //    }
        //    catch (MongoCommandException mce)
        //    {
        //        Console.WriteLine("Error: " + mce);
        //    }
        //}

        public static async Task<List<BsonDocument>> GetData() {

            var database = DBConnection.MongoConnection();
            var collection = database.GetCollection<BsonDocument>("positions");

            var filter = Builders<BsonDocument>.Filter.Eq("Speed", 48);

            var result = await collection.Find(filter).ToListAsync();

            return result;
        }

        public static async Task<List<HtmlString>> GetPosition()
        {

            var positionList = await Task.Run(() => GetData());
            List<HtmlString> dataList = new List<HtmlString>();
            foreach (BsonDocument doc in positionList)
            {

                var value = doc["Speed"];
                var value2 = doc["DateTime"];
                var value3 = doc["UnitId"];


                var valueResult = new HtmlString(value.ToString() + " | " + value2.ToString() + " | " + value3.ToString());
                dataList.Add(valueResult);

            }

            return dataList;
        }
    }
}
