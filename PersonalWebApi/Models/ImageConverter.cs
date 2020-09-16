using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

public class ImageConverter
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id {get;set;}
    public string ContentImage {get;set;}
    public DateTime UploadDateTime {get;set;}
}