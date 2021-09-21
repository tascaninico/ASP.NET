using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Students.Models
{
    public class StudentDbInitializer : DropCreateDatabaseAlways<StudentContext>
    {
        // Создание базы данных
        protected override void Seed(StudentContext db)
        {
            db.Students.Add(new Student { firstName = "Александр", lastName = "Полицинский", group = "7371", faculty = "ФКТИ", email = "example@mail.ru", mark1 = 3, mark2 = 4, mark3 = 3, mark4 = 4, mark5 = 5 });
            db.Students.Add(new Student { firstName = "Даниил", lastName = "Кузьмин", group = "7371", faculty = "ФКТИ", email = "marvel.2012@mail.ru", mark1 = 2, mark2 = 5, mark3 = 4, mark4 = 4, mark5 = 5 });
            db.Students.Add(new Student { firstName = "Иван", lastName = "Кудинов", group = "7374", faculty = "АПУ", email = "qwerty@mail.ru", mark1 = 5, mark2 = 4, mark3 = 4, mark4 = 4, mark5 = 5 });

            base.Seed(db);
        }
    }
}