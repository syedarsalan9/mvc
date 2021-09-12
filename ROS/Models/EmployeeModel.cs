using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ROS.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}