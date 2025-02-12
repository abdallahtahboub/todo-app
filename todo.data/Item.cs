using System;
using System.ComponentModel.DataAnnotations;
using todo.data;

namespace todo.data
{
    public class Item
    {

        public int ItemId { get; set; }
        public string Value { get; set; }
        public bool IsCompleted { get; set; }

    }
}
