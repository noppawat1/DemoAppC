using DemoAppCSharp.Model;
using MongoDB.Driver;
using System.Collections.Generic;


    public class MongoService
    {
        private readonly IMongoCollection<Person> _collection;
        private readonly IMongoCollection<User> _users;

        public MongoService()
        {
            var client = new MongoClient("mongodb+srv://noppawat1:Pat%40220741@cluster0.jxa1rit.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
            var db = client.GetDatabase("DemoDB");
            _collection = db.GetCollection<Person>("People");
            _users = db.GetCollection<User>("Users");
        }

        // สำหรับคน (Person)
        public void Create(Person p) => _collection.InsertOne(p);
        public List<Person> GetAll() => _collection.Find(_ => true).ToList();
        public void Update(string id, Person p) => _collection.ReplaceOne(x => x.Id == id, p);
        public void Delete(string id) => _collection.DeleteOne(x => x.Id == id);
        public bool Exists(string name, int age, string excludeId = null)
        {
            var filter = Builders<Person>.Filter.Eq(p => p.Name, name) &
                         Builders<Person>.Filter.Eq(p => p.Age, age);
            if (!string.IsNullOrEmpty(excludeId))
                filter &= Builders<Person>.Filter.Ne(p => p.Id, excludeId);

            return _collection.Find(filter).Any();
        }

        // สำหรับผู้ใช้ (User)

        // ตรวจสอบผู้ใช้ (login)
        public bool ValidateUser(string username, string password, out User user)
        {
            user = _users.Find(u => u.Username == username && u.Password == password).FirstOrDefault();
            return user != null;
        }

        // ดึงผู้ใช้ทั้งหมด
        public List<User> GetUsers()
        {
            return _users.Find(_ => true).ToList();
        }

        // เช็คว่ามี username นี้อยู่แล้วไหม
        public bool UserExists(string username)
        {
            return _users.Find(u => u.Username == username).Any();
        }

        // เพิ่มผู้ใช้ใหม่
        public void AddUser(User user)
        {
            _users.InsertOne(user);
        }

        // ลบผู้ใช้ตาม id
        public void DeleteUser(string id)
        {
            _users.DeleteOne(u => u.Id == id);
        }

        // อัปเดต role ของผู้ใช้ตาม id
        public void UpdateUserRole(string id, string newRole)
        {
            var update = Builders<User>.Update.Set(u => u.Role, newRole);
            _users.UpdateOne(u => u.Id == id, update);
        }
    }
