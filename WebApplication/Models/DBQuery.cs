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
using WebApplication.Models;

namespace WebApplication.Models
{
    class DBQuery
    {

        static IMongoDatabase database = DBConnection.MongoConnection();
        static IMongoCollection<BsonDocument> posCollection = database.GetCollection<BsonDocument>("POSITIONS");
        static IMongoCollection<BsonDocument> eventCollection = database.GetCollection<BsonDocument>("EVENTS");
        static IMongoCollection<BsonDocument> conCollection = database.GetCollection<BsonDocument>("CONNECTIONS");
        static IMongoCollection<BsonDocument> monCollection = database.GetCollection<BsonDocument>("MONITORING");

        //get the data out of the database and executes a query.
        public static async Task<List<BsonDocument>> GetSpeed(Int64 number2, Int64 number, bool equal, bool greater, bool less)
        {

            var builder = Builders<BsonDocument>.Filter;
            var empty = new BsonDocument();
            var query = builder.Empty;

            var sort = Builders<BsonDocument>.Sort.Ascending("Speed");

            if (equal) {
                query = builder.Eq("Speed", number);
            }
            else if (greater) {
                query = builder.Gt("Speed", number);
            }
            else if (less) {
                query = builder.Lt("Speed", number);
            }

            var result = await posCollection.Find(query).Sort(sort).ToListAsync();
            return result;
        }

        public static async Task<List<BsonDocument>> GetUnitId(long unitAtt, bool UnitSpeed, bool UnitLocation)
        {

            var builder = Builders<BsonDocument>.Filter;
            var empty = new BsonDocument();
            var query = builder.Eq("UnitId", unitAtt);

            var result = await posCollection.Find(query).ToListAsync();
            return result;
        }

        //get the data from the last method and takes out the selected data and puts it in a List of HTML strings.
        public static async Task<List<HtmlString>> GetSpeedData(Int64 number2, Int64 number, bool equal, bool greater, bool less)
        {
            var positionList = await Task.Run(() => GetSpeed(number2, number, equal, greater, less));
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

        public static async Task<List<HtmlString>> GetUnitIdData(long unitAtt, bool UnitSpeed, bool UnitLocation)
        {
            var positionList = await Task.Run(() => GetUnitId(unitAtt, UnitSpeed, UnitLocation));
            List<HtmlString> dataList = new List<HtmlString>();
            foreach (BsonDocument doc in positionList)
            {
                var value = doc["UnitId"];
                var value2 = doc["DateTime"];
                var value3 = doc["Speed"];
                var value4 = doc["Rdx"];
                var value5 = doc["Rdy"];

                if (UnitSpeed == true && UnitLocation == false) {

                    var valueResult = new HtmlString(value.ToString() + " | " + value2.ToString() + " | " + value3.ToString());
                    dataList.Add(valueResult);
                }
                else if (UnitLocation && UnitSpeed == false) {

                    var valueResult = new HtmlString(value.ToString() + " | " + value2.ToString() + " | " + value4.ToString() + " | " + value5.ToString());
                    dataList.Add(valueResult);

                }
                else if (UnitSpeed && UnitLocation) {

                    var valueResult = new HtmlString(value.ToString() + " | " + value2.ToString() + " | " + value3.ToString() + " | " + value4.ToString() + " | " + value5.ToString());
                    dataList.Add(valueResult);
                }
                else {

                    var valueResult = new HtmlString(value.ToString() + " | " + value3.ToString());
                    dataList.Add(valueResult);
                }
            }
            return dataList;
        }
    }
}
