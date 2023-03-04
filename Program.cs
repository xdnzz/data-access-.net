using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=@Kumanom1;TrustServerCertificate=True;";
        static void Main(string[] args)
        {
            DeleteUser();
        }
        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>();

                foreach (var user in users)
                {
                    Console.WriteLine(user);
                }
            }
        }

        public static void ReadUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.Get<User>(1);
                Console.WriteLine(users.Name);
            }
        }

        public static void CreateUser()
        {
            var user = new User()
            {
                Bio = "Equipe Brando.dev",
                Email = "brandoteam@brando.dev",
                Imagem = "https://...",
                Name = "Equipe Brando Dev",
                PasswordHash = "Hash",
                Slug = "Equipe-Brando"
            };


            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Insert<User>(user);
                Console.WriteLine("Cadastro realizado com sucesso!");
            }
        }

        public static void DeleteUser()
        {
            // var user = new User()
            // {
            //     Bio = "Equipe Brando.dev",
            //     Email = "brandoteam@brando.dev",
            //     Imagem = "https://...",
            //     Name = "Equipe Brando Dev",
            //     PasswordHash = "Hash",
            //     Slug = "Equipe-Brando"
            // };


            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(2);
                connection.Delete<User>(user);
                Console.WriteLine("Exclusão realizado com sucesso!");
            }
        }
    }



}