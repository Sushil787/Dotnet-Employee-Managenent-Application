using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnetoop.Models.Domain
{

    public class Employee
    {
        public Guid Id { get; set;}
        public string Name { get; set;}
        public String Email { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
        public DateTime DateOfBirth { get; set; }
        

    }


}