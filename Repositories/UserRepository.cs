using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection) => _connection = connection;
        
        public IEnumerable<User> GetDataDatabase(string connectionString) => _connection.GetAll<User>();

        public User GetDataDatabase(int id, string connectionString) => _connection.Get<User>(id);
        
        public void Create(User user, string connectionString) => _connection.Get<User>(user);
    
          
    }
}