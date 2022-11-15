using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolRegister;

namespace SchoolRegister
{
    public class Students
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Students()
        {

        }
        public Students(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}