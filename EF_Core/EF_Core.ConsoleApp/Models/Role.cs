﻿namespace EF_Core.ConsoleApp.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}