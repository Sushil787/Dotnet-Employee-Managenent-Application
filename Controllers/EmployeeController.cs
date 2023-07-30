using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnet_oop.Models;
using dotnetoop.Data;
using dotnetoop.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Logging;

namespace dotnet_oop.Controllers
{

    public class EmployeeController : Controller
    {


private readonly ILogger<EmployeeController> _logger;


        private readonly MVCDemoDbContext mvcDemoDbContext;
        public EmployeeController(MVCDemoDbContext mvcDemoDbContext,ILogger<EmployeeController> logger)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
    _logger = logger;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var employee = mvcDemoDbContext.Employees.ToList();
            return View(employee);
        }





        [HttpGet]
        public async Task<IActionResult> View(Guid Id)
        {
            var employee = await mvcDemoDbContext.Employees.FindAsync(Id);
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id){
            var employee = await mvcDemoDbContext.Employees.FindAsync(Id);
            if(employee!=null){
                mvcDemoDbContext.Employees.Remove(employee);
                await mvcDemoDbContext.SaveChangesAsync();
                return  RedirectToAction("Index");
            }
            return NotFound();  
        }



        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(Employee employee)
        {
            
            _logger.Log(LogLevel.Error,employee.ToString());
            mvcDemoDbContext.Employees.Update(employee);
            await mvcDemoDbContext.SaveChangesAsync();
            return  RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeViewModel)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeViewModel.Name ?? "",
                Email = addEmployeeViewModel.Email ?? "sushil@gmai.com",
                Salary = addEmployeeViewModel.Salary ?? 0,
                Department = addEmployeeViewModel.Department ?? "",
                DateOfBirth = addEmployeeViewModel.DateOfBirth ?? DateTime.Now

            };
            await mvcDemoDbContext.Employees.AddAsync(employee);
            await mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}