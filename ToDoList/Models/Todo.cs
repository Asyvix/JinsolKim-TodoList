using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class Todo
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();

        public string Title { get; set; }

        public DateTime Date { get; set; }
        public string Body { get; set; } = string.Empty;

        public bool IsComplete { get; set; } = false;

       
    }
}
