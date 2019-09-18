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

        [Ignore]
        public String BackgroundColor
        {
            get
            {
                if (Id % 2 == 0)
                {
                   return "#f3f5f4";
                }
                return "#ffffff";
            }
        }

        

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }



        public int Age { get; set; }
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
