using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Todos
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public bool isDone { get; set; }
        public virtual ApplicationUser User { get; set; } 
    }
}