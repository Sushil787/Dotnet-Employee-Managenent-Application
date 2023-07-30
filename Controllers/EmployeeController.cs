using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnet_oop.Models;
using dotnetoop.Data;
using dotnetoop.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_oop.Controllers
{
 
    public class EmployeeController : Controller
    {

       private readonly MVCDemoDbContext mvcDemoDbContext;
        public EmployeeController(MVCDemoDbContext mvcDemoDbContext){
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

       [HttpGet]
       public IActionResult Index(){
       var employee =  mvcDemoDbContext.Employees.ToList();
       Console.WriteLine(employee);
       return View(employee);
       } 

     

      [HttpGet]
      public  IActionResult Add(){
            return View();
        }

    [HttpPost]
    public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeViewModel){
        var employee = new Employee(){
            Id=Guid.NewGuid(),
            Name= addEmployeeViewModel.Name??"",
            Email= addEmployeeViewModel.Email??"sushil@gmai.com",
            Salary= addEmployeeViewModel.Salary??0,
            Department = addEmployeeViewModel.Department??"",
            DateOfBirth = addEmployeeViewModel.DateOfBirth?? DateTime.Now

        };
       await mvcDemoDbContext.Employees.AddAsync(employee);
       await mvcDemoDbContext.SaveChangesAsync();
       return RedirectToAction("Index"); 
    }
    }
}