using Lab1MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Lab1MVC.Controllers
{
    public class StudentController : Controller
    {
        /*-------------------------------------------------------------
        Global variables
        -------------------------------------------------------------*/
        NationalityData nationalityData = new NationalityData();
        MajorData majorData = new MajorData();
        StudentData studentData = new StudentData();

        /*-------------------------------------------------------------
        Methods from stored proceduress used by JavaScript and Ajax
        -------------------------------------------------------------*/
        // GET: All Students
        public JsonResult ListAllSp()
        {
            try
            {
                return Json(studentData.ListAllSp(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(new { error = error.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        //GET STUDENT BY ID FROM SP
        public JsonResult GetByIdSp(int id)
        {
            try
            {
                return Json(studentData.GetByIdSp(id), JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(new { error = error.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        // GET: All Students BY NAME
        public JsonResult GetStudentByName(string name)
        {
            try
            {
                return Json(studentData.GetStudentByName(name), JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(new { error = error.Message }, JsonRequestBehavior.AllowGet);
            }

        }


        /*-------------------------------------------------------------
        Methods from API used by JavaScript and Ajax
        -------------------------------------------------------------*/
        // GET: All Students
        public JsonResult ListAllApi()
        {
            IEnumerable<StudentApiDTO> students = null;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44317/api/student/");
                    var responseTask = client.GetAsync("GetAllStudentsSP");
                    responseTask.Wait();
                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<StudentApiDTO>>();
                        readTask.Wait();
                        students = readTask.Result;
                    }
                    else
                    {
                        students = Enumerable.Empty<StudentApiDTO>();
                        ModelState.AddModelError(string.Empty, "Server error: Pleace contact administrator");
                    }
                }

                return Json(students, JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(new { error = error.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        //GET STUDENT BY ID FROM SP
        public JsonResult GetByIdApi(int id)
        {
            StudentApiDTO student = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44317/api/student/");
                client.Timeout = TimeSpan.FromMinutes(30);

                try
                {
                    var responseTask = client.GetAsync("GetStudentById/" + id);
                    responseTask.Wait();
                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<StudentApiDTO>();
                        readTask.Wait();
                        student = readTask.Result;
                    }

                }
                catch (AggregateException agg_ex)
                {
                    var ex = agg_ex.InnerExceptions[0];
                }
            }
            return Json(student, JsonRequestBehavior.AllowGet);
        }

        // GET: All Students BY NAME
        public JsonResult GetStudentByNameApi(string name)
        {
            IEnumerable<StudentApiDTO> students = null;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44317/api/student/");
                    var responseTask = client.GetAsync("GetStudentByName/" + name);
                    responseTask.Wait();
                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<StudentApiDTO>>();
                        readTask.Wait();
                        students = readTask.Result;
                    }
                    else
                    {
                        students = Enumerable.Empty<StudentApiDTO>();
                        ModelState.AddModelError(string.Empty, "Server error: Pleace contact administrator");
                    }
                }

                return Json(students, JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(new { error = error.Message }, JsonRequestBehavior.AllowGet);
            }

        }


        /*-------------------------------------------------------------
        Methods from stored proceduress used by Razor
        -------------------------------------------------------------*/

        public ActionResult Index()
        {
            //Get all student from DB by LinQ
            IEnumerable<StudentRazorDTO> students = studentData.ListAllLinQ();
            return View(students);
        }
        [HttpPost]
        public ActionResult Index(string name)
        {
            //Get all student from DB by LinQ
            if (name.Equals(""))
            {
                //Get all student from DB by LinQ
                IEnumerable<StudentRazorDTO> studentsAll = studentData.ListAllLinQ();
                return View(studentsAll);
            }
            IEnumerable<StudentRazorDTO> studentsFind = studentData.ListAllLinQByName(name);
            return View(studentsFind);
        }
        [HttpGet]
        public ActionResult Details(int id) 
        {
            return View(studentData.ListAllLinQ().Find(s => s.StudentId==id));
        }




        /*-------------------------------------------------------------
        Other Methods
        -------------------------------------------------------------*/
        public ActionResult Create()
        {
            List<SelectListItem> nationalities = nationalityData.ListAll().ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Name,
                    Value = d.NationalityId.ToString(),
                    Selected = false
                };
            });

            List<SelectListItem> majors = majorData.ListAll().ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Name,
                    Value = d.MajorId.ToString(),
                    Selected = false
                };
            });

            ViewBag.nationalities = nationalities;
            ViewBag.majors = majors;

            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            studentData.AddSp(student);
            return View("Index", studentData.ListAllLinQ().AsEnumerable());
        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            studentData.DeleteSp(id);
            return View("Index", studentData.ListAllLinQ().AsEnumerable());
        }
        public ActionResult Edit(int id)
        {
            SelectStudentById_Result student = studentData.GetByIdSp(id);

            List<SelectListItem> nationalities = nationalityData.ListAll().ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Name,
                    Value = d.NationalityId.ToString(),
                    Selected = student.NationalityName == d.Name
                };
            });

            List<SelectListItem> majors = majorData.ListAll().ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Name,
                    Value = d.MajorId.ToString(),
                    Selected = student.MajorName == d.Name
                };
            });

            ViewBag.nationalities = nationalities;
            ViewBag.majors = majors;


            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            var stude = student;

            studentData.UpdateSp(student);

            return View("Index", studentData.ListAllLinQ().AsEnumerable());
        }

        /*-------------------------------------------------------------
       Other Methods
       -------------------------------------------------------------*/

        // GET: Students List LINQ
        public JsonResult ListAllLinQ()
        {
            try
            {
                return Json(studentData.ListAllLinQ(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(new { error = error.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult ListAll()
        {
            try
            {
                return Json(studentData.ListAll(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(new { error = error.Message }, JsonRequestBehavior.AllowGet);
            }

        }       
        // SET: Add Student
        public JsonResult Add(StudentDTO student)
        {
            try
            {
                return Json(studentData.Add(student), JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(new { error = error.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetById(int id)
        {
            try
            {
                return Json(studentData.GetById(id), JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(new { error = error.Message }, JsonRequestBehavior.AllowGet);
            }
            
        }
        public JsonResult Update(StudentDTO student)
        {
            return Json(studentData.Update(student), JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddSp(Student student)
        {
            try
            {
                return Json(studentData.AddSp(student), JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(new { error = error.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult DeleteSp(int id)
        {
            return Json(studentData.DeleteSp(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateSp(Student student)
        {
            return Json(studentData.UpdateSp(student), JsonRequestBehavior.AllowGet);
        }

       
    }
}