using DemoAppCSharp.Model;
using MongoDB.Driver;
using System.Collections.Generic;

public class MongoService
{
    private readonly IMongoCollection<Person> _collection;

    public MongoService()
    {
        // เชื่อมต่อกับ MongoDB ที่รันในเครื่อง
        var client = new MongoClient("mongodb+srv://noppawat1:Pat%40220741@cluster0.jxa1rit.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
        var db = client.GetDatabase("DemoDB");  // ชื่อฐานข้อมูลที่คุณต้องการใช้งานบน Atlas
        _collection = db.GetCollection<Person>("People");

    }

    public void Create(Person p) => _collection.InsertOne(p);
    public List<Person> GetAll() => _collection.Find(_ => true).ToList();
    public void Update(string id, Person p) => _collection.ReplaceOne(x => x.Id == id, p);
    public void Delete(string id) => _collection.DeleteOne(x => x.Id == id);
    public bool Exists(string name, int age, string excludeId = null)
    {
        var filter = Builders<Person>.Filter.Eq(p => p.Name, name) &
                     Builders<Person>.Filter.Eq(p => p.Age, age);

        if (!string.IsNullOrEmpty(excludeId))
        {
            filter &= Builders<Person>.Filter.Ne(p => p.Id, excludeId);
        }

        return _collection.Find(filter).Any();
    }

}
