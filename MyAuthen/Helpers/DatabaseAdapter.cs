using System;
using System.Collections.Generic;
using System.Linq;
using MyAuthen.Models;
using SQLite;

namespace MyAuthen.Helpers
{
    public class DatabaseAdapter
    {
        private SQLiteConnection Conn { get; }

        public DatabaseAdapter(string dabasePath)
        {
            Conn = new SQLiteConnection(dabasePath);
        }

        public List<User> GetUsers()
        {
            // SQL command mapping
            var result = Conn.Query<User>("select * from UserPassword");
            return result;
        }

        public User GetUser(string username)
        {
            // SQL command mapping
            var result = Conn.Query<User>("select * from UserPassword where Username = ?", new String[] { username}).SingleOrDefault();
            return result;
        }

        public User GetUserAge(string username, int age)
        {
            // SQL command mapping
            var result = Conn.Query<User>("select * from UserPassword where Username = ? && Age = 18", new String[] { username}).SingleOrDefault();
            return result;
        }

        public int AddUser(User user)
        {
            var count = Conn.Insert(user);
            return count;
        }

        public int EditUser(User user)
        {
            var data = GetUser(user.Username);
            if(data == null)
            {
                return 0;
            }
            data.Password = user.Password;
            var count = Conn.Update(data);
            return count;
        }

        public void DeleteUsers()
        {
            Conn.DeleteAll<User>();
        }

    }
}
