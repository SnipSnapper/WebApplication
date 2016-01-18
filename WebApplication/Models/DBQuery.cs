using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        static IMongoCollection<BsonDocument> eventCollection = database.GetCollection<BsonDocument>("EVENTS");
        static IMongoCollection<BsonDocument> conCollection = database.GetCollection<BsonDocument>("CONNECTIONS");
        static IMongoCollection<BsonDocument> monCollection = database.GetCollection<BsonDocument>("MONITORING");

        // This method gets the data out of the database and executes a query.
        public static async Task<List<BsonDocument>> GetData(string att, Int64 number, bool equal, bool greater, bool less) {

            var builder = Builders<BsonDocument>.Filter;
            var empty = new BsonDocument();
            var equalQuery = builder.Eq(att, number);
            var greaterQuery = builder.Gt(att, number);
            var lessQuery = builder.Lt(att, number);
            var sort = Builders<BsonDocument>.Sort.Ascending(att);
            if (equal) {

                var result = await posCollection.Find(equalQuery).Sort(sort).ToListAsync();
                return result;
            }
            else if (greater) {

                var result = await posCollection.Find(greaterQuery).Sort(sort).ToListAsync();
                return result;

            }
            else if(less)
            {
                var result = await posCollection.Find(lessQuery).Sort(sort).ToListAsync();
                return result;
            }
            else {

                var result = await posCollection.Find(empty).Sort(sort).ToListAsync();
                return result;
            }
        }

        // This method gets the data from the last method and takes out the selected data and puts it in a List of HTML strings.
        public static async Task<List<HtmlString>> GetPosition(string att, Int64 number, bool equal, bool greater, bool less)
        {

            var positionList = await Task.Run(() => GetData(att, number, equal, greater, less));
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
