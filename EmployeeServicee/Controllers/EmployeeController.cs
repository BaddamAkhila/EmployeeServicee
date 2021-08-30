using EmployeeServicee.Data;
using EmployeeServicee.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeServicee.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeContext _context;
        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateEmployee(Employee emp)
        {
            _context.Employee.Add(emp);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public List<Employee> GetEmployee()
        {
            var emp = _context.Employee.ToList();
            return emp;
        }
        [HttpGet]
        public IActionResult test()
        {
            return Ok();
        }
        [HttpGet]
        public Employee GetEmployeeById(int id)
        {
            var emp = _context.Employee.FirstOrDefault(e=>e.Id==id);
            return emp;
        }
        [HttpPost]
        public IActionResult DeleteEmp(int Id)
        {
            var result = _context.Employee.FirstOrDefault(e => e.Id == Id);
            if (result != null)
            {
                _context.Employee.Remove(result);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
        [HttpGet]
        public string Getusername(string Email)
        {
            var name = Email.Split('@')[0];
            return name;
        }
        [HttpPost]
        public IActionResult employeeUpdate(Employee emp)
        { 
            var result = _context.Employee.FirstOrDefault(e => e.Id == emp.Id);
                if (result != null)
                {
                    result.Age = emp.Age;
                    result.Name = emp.Name;
                    result.Country = emp.Country;
                    result.Designation = emp.Designation;
                    result.ContactNumber = emp.ContactNumber;
                    _context.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
        }
    }

