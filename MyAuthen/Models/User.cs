﻿using System;
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
    }
}
