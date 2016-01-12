using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace FinalWebApplication.Models
{
    public class EmployeeContext : DbContext
    {

        public EmployeeContext() : base()
        {
        }

        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public List<Employee> GetEmployeeList()
        {
            return this.Employee.ToList();
        }

        public void AddEmployee(Employee empl)
        {
            Employee.Add(empl);
            this.SaveChanges();
        }

        public void EditEmploee(Employee empl)
        {
            var editItem = Employee.FirstOrDefault(i => i.EmployeeID == empl.EmployeeID);
            if (editItem != null)
            {
                editItem.Name = empl.Name;
                editItem.Position = empl.Position;
                editItem.Salary = empl.Salary;
                editItem.Status = empl.Status;
                // editItem = empl;
                this.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            var editItem = Employee.FirstOrDefault(i => i.EmployeeID == id);
            Employee.Remove(editItem);
            this.SaveChanges();
        }

    }

    public class Writer
    {
        public void TxtWriteResult()
        {
            var context = new EmployeeContext();
            var list = context.Employee.ToList();

            TextWriter tw = new StreamWriter(@"D:\WriteLines.txt");

            foreach (var s in list)
                tw.WriteLine(EmployeeToString(s));

            tw.Close();
        }



        private  string  EmployeeToString(Employee empl)
        {
            double taxSalary;
            if (empl.Salary >= 25000)
            {
                if (empl.Salary >= 10000 && empl.Salary <= 25000)
                {
                    taxSalary = 0.15;
                }
                taxSalary = 0.25;
            }
            else
            {
                taxSalary = 0.10;
            }


            return $"Id={empl.EmployeeID} Name={empl.Name} Position={empl.Position} Taxes={empl.Salary*taxSalary} Status={empl.Status} Salary={empl.Salary-(empl.Salary*taxSalary)}";
         }
    }
}