using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using dotnetoop.Models.Domain;

namespace dotnetoop.Data
{

    public class MVCDemoDbContext: DbContext
    {
        
        public MVCDemoDbContext(DbContextOptions options):base(options)
        {
             
        }
        public  DbSet<Employee> Employees { get; set; }

       
    }


}