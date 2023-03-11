using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=@Kumanom1;TrustServerCertificate=True;";
        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            ReadRoles(connection);
            connection.Close();
        }
        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.Get();
            repository.Delete(1);

            foreach (var user in users) repository.Delete(user);

        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new RoleRepository(connection);

            var roles = repository.Get();

            foreach (var role in roles) Console.WriteLine(role);

        }














        // public static void ReadUser()
        // {
        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         var users = connection.Get<User>(1);
        //         Console.WriteLine(users.Name);
        //     }
        // }

        // public static void CreateUser()
        // {
        //     var user = new User()
        //     {
        //         Bio = "Equipe Brando.dev",
        //         Email = "brandoteam@brando.dev",
        //         Imagem = "https://...",
        //         Name = "Equipe Brando Dev",
        //         PasswordHash = "Hash",
        //         Slug = "Equipe-Brando"
        //     };


        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         connection.Insert<User>(user);
        //         Console.WriteLine("Cadastro realizado com sucesso!");
        //     }
        // }

        // public static void DeleteUser()
        // {
        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         var user = connection.Get<User>(2);
        //         connection.Delete<User>(user);
        //         Console.WriteLine("Exclusão realizado com sucesso!");
        //     }
        // }
    }



}