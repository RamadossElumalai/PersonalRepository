using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

public class ImageUpload
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id {get;set;}
    public byte[] ContentImage {get;set;}
    public DateTime UploadDateTime {get;set;}
}