using manage.Context;
using manage.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace manage.Controllers
{
    public class EmployeeController : Controller
    {
        EventContext db = new EventContext();
        public ActionResult Index()
        {
            return View();
        }


        // GET: Admin
        public ActionResult Employee(string LastName, string searchString)
        {
            var nameList = new List<string>();
            var nameQuery = from a in db.Employees
                            orderby a.LastName
                            select a.LastName;

            nameList.AddRange(nameQuery.Distinct());
            ViewBag.LastName = new SelectList(nameList);

            var employee = from e in db.Employees
                           select e;
            //select by 
            if (!String.IsNullOrEmpty(LastName))
            {
                employee = employee.Where(x => x.LastName == LastName);
            }
            //select by name 
            if (!String.IsNullOrEmpty(searchString))
            {
                employee = employee.Where(s => s.FirstName.Contains(searchString));
            }

            return View(employee);
        }
        public ActionResult Details(int? ID)
        {
            Employee employee = db.Employees.Find(ID);
            return View(employee);
        }

        public ActionResult Edit(int? ID)
        {
            Employee employee = db.Employees.Find(ID);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }

        }
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Employee employee = db.Employees.Find(ID);
            if (employee == null)
            {
                return HttpNotFound(); //if someone tries to delete something absent its not found 
            }
            return View(employee);
        }
        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirm(int? ID)
        {
            Employee employee = db.Employees.Find(ID);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Employee employee)

        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);

                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }

        /*    public ActionResult FileUpload(HttpPostedFileBase file)
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(
                                           Server.MapPath("Images/"), pic);
                    // file is uploaded
                    file.SaveAs(path);

                    // save the image path path to the database or you can send image 
                    // directly to database
                    // in-case if you want to store byte[] ie. for DB
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                    }

                }
                // after successfully uploading redirect the user
                return RedirectToAction("actionname", "controller name");
            }

        */


    }
}
      
  