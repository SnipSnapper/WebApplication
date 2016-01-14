using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
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

        static IMongoDatabase database = DBConnection.MongoConnection();
        static IMongoCollection<BsonDocument> posCollection = database.GetCollection<BsonDocument>("POSITIONS");
        static IMongoCollection<BsonDocument> eventCollection = database.GetCollection<BsonDocument>("events");

        public static async Task<List<BsonDocument>> GetData(string att, Int64 number) {

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Gt(att, number);
            var sort = Builders<BsonDocument>.Sort.Ascending("Speed");
            var result = await posCollection.Find(filter).Sort(sort).ToListAsync();

            return result;
        }

        public static async Task<List<HtmlString>> GetPosition(string att, Int64 number)
        {

            var positionList = await Task.Run(() => GetData(att, number));
            List<HtmlString> dataList = new List<HtmlString>();
            foreach (BsonDocument doc in positionList)
            {

                var value = doc["Speed"];
                var value2 = doc["DateTime"];
                var value3 = doc["UnitId"];
                var value4 = doc["Rdx"];
                var value5 = doc["Rdy"];


                var valueResult = new HtmlString(value.ToString() + " | " + value2.ToString() + " | " + value3.ToString() + " | " + value4.ToString() +" | " + value5.ToString());
                dataList.Add(valueResult);

            }

            return dataList;
        }
    }
}
