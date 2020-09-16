using MongoDB.Driver;
using System.Linq;
using System.Collections.Generic;

public class ImageUploadService
{
    private readonly IMongoCollection<ImageUpload> _imageUpload;

    public ImageUploadService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);
      _imageUpload = database.GetCollection<ImageUpload>(settings.CollectionName);    
    }

    public List<ImageUpload> GetAllImages() {
       return _imageUpload.Find(i=>true).ToList();
    }

    public ImageUpload Get(string id){
      return  _imageUpload.Find<ImageUpload>(i=>i.Id == id).FirstOrDefault();
    }

    public ImageUpload Create(ImageUpload image)
    {
      _imageUpload.InsertOne(image);
      return image;
    }

    public void Update(string id, ImageUpload image)
    {
      _imageUpload.ReplaceOne(i=>i.Id == id,image);
    }
    
    public void Remove(string id) {
      _imageUpload.DeleteOne(i=>i.Id == id);
    }
}