using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Entity.Mongo
{
    [BsonIgnoreExtraElements]

    public class MessageMongo
    {
        public string _id { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
    }
}