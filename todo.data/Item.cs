using System;
using System.ComponentModel.DataAnnotations;
using todo.data;

namespace todo.data
{
    public class Item
    {
        public int ItemId { get; set; }
        [Required]
          public string Value { get; set; } = string.Empty;
        [Required]
        public bool IsCompleted { get; set; } = false;

    }
}
