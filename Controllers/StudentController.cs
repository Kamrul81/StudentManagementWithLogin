using StudentManagementWithLogin.Data;
using StudentManagementWithLogin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementWithLogin.Controllers
{
    public class StudentController : Controller
    {
        private StudentDAL studentDAL = null;

        public StudentController()
        {
            studentDAL = new StudentDAL();
        }

        // Private method to check if user is logged in
        private bool IsUserLoggedIn()
        {
            var userName = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(userName))
            {
                return false;
            }
            return true;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            if (!IsUserLoggedIn())
            {
                // If the user is not logged in, redirect them to the login page
                return RedirectToAction("Login", "Account");
            }

            IEnumerable<Student> students = studentDAL.GetAllStudent();
            students = students.OrderBy(s => s.Id);
            return View(students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            if (!IsUserLoggedIn())
            {
                // If the user is not logged in, redirect them to the login page
                return RedirectToAction("Login", "Account");
            }

            Student student = studentDAL.GetStudentData(id);
            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            if (!IsUserLoggedIn())
            {
                // If the user is not logged in, redirect them to the login page
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (!IsUserLoggedIn())
            {
                // If the user is not logged in, redirect them to the login page
                return RedirectToAction("Login", "Account");
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(student); // Re-render the form with validation errors
                }

                studentDAL.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log the error details (this should ideally go into a logging framework)
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
                return View(student); // Return the view with the error
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!IsUserLoggedIn())
            {
                // If the user is not logged in, redirect them to the login page
                return RedirectToAction("Login", "Account");
            }

            Student student = studentDAL.GetStudentData(id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (!IsUserLoggedIn())
            {
                // If the user is not logged in, redirect them to the login page
                return RedirectToAction("Login", "Account");
            }

            try
            {
                studentDAL.UpdateStudent(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            if (!IsUserLoggedIn())
            {
                // If the user is not logged in, redirect them to the login page
                return RedirectToAction("Login", "Account");
            }

            Student student = studentDAL.GetStudentData(id);
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Student student)
        {
            if (!IsUserLoggedIn())
            {
                // If the user is not logged in, redirect them to the login page
                return RedirectToAction("Login", "Account");
            }

            try
            {
                studentDAL.DeleteStudent(student.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
