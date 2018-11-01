using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Models
{
    public class ToDo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public ToDo() {
        }

        public ToDo(string name) {
            Name = name;
        }

        public ToDo(string name, bool status) {
            Name = name;
            Status = status;
        }
    }
}
