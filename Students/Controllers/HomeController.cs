using Students.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Students.Controllers
{
    public class HomeController : Controller
    {
        // Создаем контекст данных
        StudentContext db = new StudentContext();

        public ActionResult Index()
        {
            // Получаем из бд все объекты Student
            IEnumerable<Student> students = db.Students;
            // Передаем все объекты в динамическое свойство Students в ViewBag
            ViewBag.Students = students;
            // Возвращаем представление
            return View();
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            // Расчет id
            var i = 1;
            foreach (var student in db.Students)
            {
                i++;
            }
            // Сохраняем id
            ViewBag.Id = i;
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(Student student)
        {
            // Добавляем информацию в базу данных
            db.Students.Add(student);
            // Сохраняем в бд все изменения
            db.SaveChanges();
            return Redirect("/Home/Index");
        }

        [HttpGet]
        public ActionResult ChangeUser(int id, string firstName, string lastName, string email,
            string group, string faculty, int mark1, int mark2, int mark3, int mark4, int mark5)
        {
            // Сохраняем все необходимые данные
            ViewBag.Id = id;
            ViewBag.FirstName = firstName;
            ViewBag.LastName = lastName;
            ViewBag.Email = email;
            ViewBag.Group = group;
            ViewBag.Faculty = faculty;
            ViewBag.Mark1 = mark1;
            ViewBag.Mark2 = mark2;
            ViewBag.Mark3 = mark3;
            ViewBag.Mark4 = mark4;
            ViewBag.Mark5 = mark5;
            return View();
        }

        [HttpPost]
        public ActionResult ChangeUser(Student student)
        {
            Student b = db.Students.Find(student.Id);
            db.Students.Remove(b);
            // Добавляем информацию в базу данных
            db.Students.Add(student);
            // Сохраняем в бд все изменения
            db.SaveChanges();
            return Redirect("/Home/Index");
        }

        [HttpGet]
        public ActionResult BestWorst()
        {
            // Посчет суммы баллов у всех студентов
            foreach (var best in db.Students) {
                best.all = best.mark1 + best.mark2 + best.mark3 + best.mark4 + best.mark5;
            }
            // Сохранение изменений
            db.SaveChanges();
            // Получение 5 лучших
            ViewBag.Best = db.Students
                .OrderByDescending(p => p.all).Take(5);
            // Получение 5 худших
            ViewBag.Worst = db.Students
                .OrderBy(p => p.all).Take(5);
            return View();
        }
        
        [HttpGet]
        public string WriteFile()
        {
            // Открытие файла
            StreamWriter f = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory 
                + @"App_Data/file.txt", false);
            foreach (var student in db.Students)
            {
                // Запись в файл
                f.WriteLine(student.Id + " " + student.firstName + " " + student.lastName + 
                    " " + student.email + " " + student.group + " " + student.faculty + " " +
                    student.mark1 + " " + student.mark2 + " " + student.mark3 + " " +
                    student.mark4 + " " + student.mark5);
            }
            // Закрытие файла
            f.Close();
            return "Данные из БД записаны в файл";
        }
    }
}