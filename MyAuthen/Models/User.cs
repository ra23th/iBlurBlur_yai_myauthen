using System;
using SQLite;

namespace MyAuthen.Models
{
    // Data annotation
    [Table("UserPassword")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User(string username, string password, int age)
        {
            Username = username;
            Password = password;
            Age = age;
        }

        public User()
        {

        }
    }
}
