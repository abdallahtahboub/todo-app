using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace todo.data
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
