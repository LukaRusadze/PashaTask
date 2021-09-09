using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskForIntern.Models
{
    public class TodoItemModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ToDoItem { get; set; }
    }
}
