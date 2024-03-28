using MongoDb_WebApi.Models;

namespace MongoDb_WebApi.Interfaces
{
    public interface IUserService
    {
        Users createUser(Users users);
        List<Users> listUsers();
        Users getUserById(string id);
        void DeleteUser(string id);
        void UpdateUser(string id,Users users);
    }
}
