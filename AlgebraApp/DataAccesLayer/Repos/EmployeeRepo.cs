using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Models;

namespace DataAccesLayer.Repositories
{
    public class EmployesRepo
    {
        private AppDbContext db = new AppDbContext();

        public List<Employee> GetEmployees()
        {
            return db.Employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
            return db.Employees.Find(id);
        }

        public void CreateEmploye(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
        }
    }
}
