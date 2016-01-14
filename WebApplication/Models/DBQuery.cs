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
        static IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("Positions");

        public static async Task<List<BsonDocument>> GetData() {

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Gt("Speed", 100);
            var sort = Builders<BsonDocument>.Sort.Ascending("Speed");
            var result = await collection.Find(filter).Sort(sort).ToListAsync();

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
                var value4 = doc["Rdx"];
                var value5 = doc["Rdy"];


                var valueResult = new HtmlString(value.ToString() + " | " + value2.ToString() + " | " + value3.ToString() + " | " + value4.ToString() +" | " + value5.ToString());
                dataList.Add(valueResult);

            }

            return dataList;
        }
    }
}
