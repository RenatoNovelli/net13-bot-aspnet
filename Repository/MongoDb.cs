﻿using Microsoft.Bot.Connector;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SimpleBot.Repository
{
    public class MongoDb
    {
        private readonly IMongoDatabase _database;

        public MongoDb()
        {
            var client = new MongoClient(ConfigurationManager.AppSettings["connectionString"]);
            _database = client.GetDatabase("bot");
        }

        internal void SaveActivity(Activity activity)
        {
            var coll = _database.GetCollection<Activity>("activity");
            coll.InsertOne(activity);
        }
    }
}