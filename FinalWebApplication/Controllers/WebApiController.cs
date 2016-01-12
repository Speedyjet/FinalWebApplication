using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using FinalWebApplication.Models;

namespace FinalWebApplication.Controllers
{
    public class WebApiController : ApiController
    {

        [System.Web.Http.HttpPost]
        public JsonResult LoadEdit([FromBody] string emplId)
        {
            var context = new EmployeeContext();
            var id = Convert.ToInt32(emplId);
            var empl = context.Employee.FirstOrDefault(c => c.EmployeeID == id);
          
            return new JsonResult
            {
                Data = new
                {
                    name = empl.Name ?? "",
                    position = empl.Position,
                    salary = empl.Salary,
                    status = empl.Status
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

      
        [System.Web.Http.HttpPost]
        public JsonResult Save(Employee empl)
        {
            var context = new EmployeeContext();
            if (empl.EmployeeID == 0)
                context.AddEmployee(empl);
            else
                context.EditEmploee(empl);
            return null;
        }

        [System.Web.Http.HttpPost]
        public JsonResult Delete([FromBody] string pageId)
        {
            var context = new EmployeeContext();
            context.DeleteEmployee(Convert.ToInt32(pageId));
            return null;
        }

        [System.Web.Http.HttpPost]
        public void TxtWriteResult()
        {
            var writer = new Writer();
            writer.TxtWriteResult();
        }
    }
}
