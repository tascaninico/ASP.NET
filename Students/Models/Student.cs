using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Models
{
    // Модель студента
    public class Student
    {
        // id
        public int Id { get; set; }
        // Имя
        public string firstName {  get; set; }
        // Фамилия
        public string lastName {  get; set; }
        // Почта
        public string email {  get; set; }
        // Номер группы
        public string group {  get; set; }
        // Факультет
        public string faculty {  get; set; }
        // Оценка по первому предмету
        public int mark1 {  get; set; }
        // Оценка по второму предмету
        public int mark2 {  get; set; }
        // Оценка по третьему предмету
        public int mark3 {  get; set; }
        // Оценка по четвертому предмету
        public int mark4 {  get; set; }
        // Оценка по пятому предмету
        public int mark5 {  get; set; }
        // Сумма всех баллов
        public int all {  get; set; }
    }
}