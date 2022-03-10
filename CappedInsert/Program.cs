using System;
using System.IO;
using System.Net;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using MongoDB.Driver.Linq;



namespace CappedInsert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========TESTING INSERT INTO CAPPED COLLECTION=============");

            var dbClient = new MongoClient("mongodb://myUserAdmin:1qazXSW%40@168.138.189.225:27727/?authSource=admin&readPreference=primary&appname=MongoDB%20Compass&directConnection=true&ssl=false");
            IMongoDatabase db = dbClient.GetDatabase("TestingMongoDB");
            var CappedPromotion = db.GetCollection<BsonDocument>("CappedPromotion");
           
            string[] countries = { "th", "sg", "id" };

            for (int m = 0; m <= 100; m++)
            {
                var documnt = new BsonDocument
                {
                {"PromotionID",m.ToString()},
                {"InsertDate",DateTime.Now.ToUniversalTime()},
                {"CountryCode",countries[0]},
                };
                CappedPromotion.InsertOne(documnt);
                Console.WriteLine("Write Last Documents"+documnt);
            }

            Console.WriteLine("==========END INSERTION , Please PRESS ENTER =============");
            Console.ReadLine();

        }
    }
}
