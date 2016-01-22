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

/// <summary>
/// this class gets the data out of the database. It will execute query's and filter the wanted data.
/// </summary>
namespace WebApplication.Models
{
    class DBQuery
    {

        static IMongoDatabase database = DBConnection.MongoConnection();
        static IMongoCollection<BsonDocument> posCollection = database.GetCollection<BsonDocument>("POSITIONS");
        static IMongoCollection<BsonDocument> eventCollection = database.GetCollection<BsonDocument>("EVENTS");
        static IMongoCollection<BsonDocument> conCollection = database.GetCollection<BsonDocument>("CONNECTIONS");
        static IMongoCollection<BsonDocument> monCollection = database.GetCollection<BsonDocument>("MONITORING");

        // get the data out of the database and executes a query.
        public static async Task<List<BsonDocument>> GetSpeed(Int64 number, bool equal, bool greater, bool less, bool between, Int64 number2)
        {

            var builder = Builders<BsonDocument>.Filter;
            var empty = new BsonDocument();
            var query = builder.Empty;

            var sort = Builders<BsonDocument>.Sort.Ascending("Speed");
            if (between) {
                query = builder.Gt("Speed", number) & builder.Lt("Speed", number2);
            }
            else if (equal) {
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

        // get the data from the last method and takes out the selected data and puts it in a List of HTML strings.
        public static async Task<List<HtmlString>> GetSpeedData(Int64 number, bool equal, bool greater, bool less, bool between, Int64 number2 = 0)
        {
            var positionList = await Task.Run(() => GetSpeed(number, equal, greater, less, between, number2));
            List<HtmlString> dataList = new List<HtmlString>();
            foreach (BsonDocument doc in positionList)
            {
                var value = doc["Speed"];
                var value2 = doc["DateTime"];
                var value3 = doc["UnitId"];

                var valueResult = new HtmlString("<table><tr><th>Car ID</th><th>Date and Time</th><th>Speed</th></tr><tr><td style='width:150px'>" + value3.ToString() + "</td> <td style='width:180px'>"
                    + value2.ToString() + "</td> <td style='width:120px'>" + value.ToString() + "</td></tr></table>");
                dataList.Add(valueResult);
            }

            return dataList;
        }

        // get the data out of the database and executes a query.
        public static async Task<List<BsonDocument>> GetUnitId(long unitAtt, bool UnitSpeed, bool UnitLocation)
        {

            var builder = Builders<BsonDocument>.Filter;
            var empty = new BsonDocument();
            var query = builder.Eq("UnitId", unitAtt);


            var result = await posCollection.Find(query).ToListAsync();
            return result;
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

                if (UnitSpeed == true && UnitLocation == false)
                {

                    var valueResult = new HtmlString("<table><tr><th>Car ID</th><th>Date and Time</th><th>Speed</th></tr><tr><td style='width:100px'>" + value.ToString()
                        + "</td> <td style='width:150px'>" + value2.ToString() + "</td> <td style='width:20px'>" + value3.ToString() + "</td></tr></table>");
                    dataList.Add(valueResult);
                }
                else if (UnitLocation && UnitSpeed == false)
                {

                    var valueResult = new HtmlString("<table><tr><th>Car ID</th><th>Date and Time</th><th>Longitude Position</th><th>Latitude Position</th></tr><tr><td style='width:120px'>"
                        + value.ToString() + "</td> <td style='width:180px'>" + value2.ToString() + "</td><td style='width:180px'>" + value4.ToString()
                        + "</td> <td style='width:180px'>" + value5.ToString() + "</td></tr></table>");
                    dataList.Add(valueResult);

                }
                else if (UnitSpeed && UnitLocation)
                {

                    var valueResult = new HtmlString("<table><tr><th>Car ID</th><th>Date and Time</th><th>Speed of Car</th><th>Longtitude Position</th><th>Latitude Position</th></tr><tr><td style='width:120px'>"
                        + value.ToString() + "</td> <td style='width:180px'>" + value2.ToString() + "</td> <td style='width:120px'>" + value3.ToString()
                        + "</td> <td style='width:180px'>" + value4.ToString() + "</td> <td style='width:180px'>" + value5.ToString() + "</td></tr></table>");
                    dataList.Add(valueResult);
                }
                else
                {

                    var valueResult = new HtmlString("<table><tr><th>Car ID</th><th>Speed of Car</th></tr><tr><td style='width:20px'>" + value.ToString() + "</td><td style='width:170px'>" + value3.ToString() + "</td></tr></table>");
                    dataList.Add(valueResult);
                }
            }
            return dataList;
        }
        // get the data out of the database and executes a query.
        public static async Task<List<BsonDocument>> GetSoftware(long softwareCarID, string softwareSort)
        {

            var builder = Builders<BsonDocument>.Filter;
            var empty = new BsonDocument();
            var query = builder.Empty;

            var sort = Builders<BsonDocument>.Sort.Ascending("type");

            var result = await monCollection.Find(query).Sort(sort).ToListAsync();
            return result;
        }

        public static async Task<List<HtmlString>> GetSoftwareData(long softwareCarID, string softwareSort)
        {
            var softwareList = await Task.Run(() => GetSoftware(softwareCarID, softwareSort));
            List<HtmlString> dataList = new List<HtmlString>();
            foreach (BsonDocument doc in softwareList)
            {
                var value = doc["UnitID"];
                var value2 = doc["beginTime"];
                var value3 = doc["type"];
                var value4 = doc["min"];
                var value5 = doc["max"];

                var valueResult = new HtmlString("<table><tr><th>Car ID</th><th>Time</th><th>Software Type</th><th>Value Now</th><th>Last Value</th></tr><tr><td style='width:100px'>" + value.ToString()
                                    + "</td> <td style='width:150px'>" + value2.ToString() + "</td> <td style='width:250px'>" + value3.ToString()
                                    + "</td> <td style='width:100px'>" + value4.ToString() + "</td><td style='width:100px'>" + value5.ToString() + "</td></tr></table> ");
                dataList.Add(valueResult);
            }

            return dataList;
        }
 
        public static async Task<List<HtmlString>> GetDate(string dateTime, long UnitID, bool DateSpeed, bool DateUnitID)
        {
            var positionList = await Task.Run(() => DateData(dateTime, UnitID, DateSpeed, DateUnitID));
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
        // get the data out of the database and executes a query.
        public static async Task<List<BsonDocument>> DateData(string dateTime, long UnitID, bool DateSpeed, bool DateUnitID)
        {

            var builder = Builders<BsonDocument>.Filter;
            var empty = new BsonDocument();
            var query = builder.Regex("DateTime", dateTime) & builder.Eq("UnitId", UnitID);

            var result = await posCollection.Find(query).ToListAsync();
            return result;
        }
        // get the data out of the database and executes a query.
        public static async Task<List<BsonDocument>> GetHardware(long hardwareCarID, string hardwareSort)
        {
            var builder = Builders<BsonDocument>.Filter;
            var empty = new BsonDocument();
            //var query = builder.Eq("UnitID", hardwareCarID) & builder.Eq("type", hardwareSort) & builder.In("beginTime", beginTime);
            var query = builder.Eq("UnitID", hardwareCarID) & builder.Eq("type", hardwareSort);

            var result = await monCollection.Find(query).ToListAsync();
            return result;
        }
        public static async Task<List<HtmlString>> GetHardwareData(long hardwareCarID,string hardwareSort)
        {
            var monitoringList = await Task.Run(() => GetHardware(hardwareCarID, hardwareSort));
            List<HtmlString> dataList = new List<HtmlString>();
            foreach (BsonDocument doc in monitoringList)
            {
                var value = doc["UnitID"];
                var value2 = doc["beginTime"];
                var value3 = doc["type"];
                var value4 = doc["min"];


                var valueResult = new HtmlString("<table><tr><th>Car ID</th><th>Time</th><th>Hardware Type</th><th>Value</th></tr><tr><td style='width:100px'>" + value.ToString()
                     + "</td> <td style='width:150px'>" + value2.ToString() + "</td> <td style='width:150px'>" + value3.ToString()
                     + "</td> <td style='width:20px'>" + value4.ToString() + "</td></tr></table>");
                dataList.Add(valueResult);
            }
            return dataList;
        }
    }
}
