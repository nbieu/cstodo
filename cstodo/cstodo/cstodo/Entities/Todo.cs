using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cstodo.Entities
{
    public class Todo
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public ObjectId Id { get; set; }

        // Other properties of Todo class
        public string title { get; set; }
        public string status { get; set; }
        // Other properties as needed
    }
}