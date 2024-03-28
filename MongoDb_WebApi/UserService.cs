using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDb_WebApi.Interfaces;
using MongoDb_WebApi.Models;

namespace MongoDb_WebApi
{
    public class UserService:IUserService
    {
        private readonly IMongoCollection<Users> _users;
        public UserService(IOptions<MongoDbConnection> connection,IMongoClient mongoclient)
        {
            var db = mongoclient.GetDatabase(connection.Value.Database);
            _users=db.GetCollection<Users>(connection.Value.CollectionName);
            
        }

        public Users createUser(Users users)
        {
            _users.InsertOne(users);
            return users;
        }

        public void DeleteUser(string id)
        {
            _users.DeleteOne(x=>x.Id==id);
        }

        public Users getUserById(string id)
        {
           Users user=_users.Find(x=>x.Id==id).FirstOrDefault();
            return user;
        }

        public List<Users> listUsers()
        {
            return _users.Find(x=>true).ToList();
        }

        public void UpdateUser(string id, Users users)
        {
            _users.ReplaceOne(x=>x.Id==id,users);
            

        }
    }
}
