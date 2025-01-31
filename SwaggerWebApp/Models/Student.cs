﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwaggerWebApp.Models
{
    public class Student
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string Name { get; set; } = "";
        public string Roll { get; set; } = "";
        public int Age { get; set; } = 0;

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}