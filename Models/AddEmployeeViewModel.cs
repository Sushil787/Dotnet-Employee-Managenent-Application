using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_oop.Models
{
    public class AddEmployeeViewModel
    {
        public Guid Id {get;set;}
        public string? Name {get;set;}
        public string? Email{get;set;}
        public long? Salary{get;set;}

        public DateTime? DateOfBirth{get;set;}
        public string? Department{get;set;}


    }
}