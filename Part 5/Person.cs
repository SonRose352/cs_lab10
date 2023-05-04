using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_5
{
    internal class Person
    {
        //Поля
        public string SurName { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public DateTime DateofBirth { get; set; }

        //Конструкторы
        public Person()
        {
            SurName = "Tukhbatullin";
            DateofBirth = new DateTime(2004, 9, 20);
            Height = 180;
            Weight = 80;
        }
        public Person(string surName, int height, int weight, DateTime dateofBirth)
        {
            SurName = surName;
            Height = height;
            Weight = weight;
            DateofBirth = dateofBirth;
        }
        public Person(Person person)
        {
            SurName = person.SurName;
            Height = person.Height;
            Weight = person.Weight;
            DateofBirth = person.DateofBirth;
        }

        //Методы для консольного ввода и вывода
        public void input()
        {
            Console.Write("Введите Фамилию: ");
            SurName = Console.ReadLine();
            Console.Write("Введите рост: ");
            Height = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите вес: ");
            Weight = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите дату рождения: ");
            DateofBirth = Convert.ToDateTime(Console.ReadLine());
        }
        public void output()
        {
            Console.WriteLine($"Фамилия: {SurName}\nРост: {Height}\nВес: {Weight}\nДата рождения: {DateofBirth}");
        }

        //Метод ToString
        public override string ToString()
        {
            return SurName + " " + Height + " " + Weight + " " + DateofBirth;
        }

        //Метод, возвращающий количество полных лет
        public int age()
        {
            var age = DateTime.Now.Year - DateofBirth.Year;
            if (DateTime.Now.DayOfYear < DateofBirth.DayOfYear)
                age--;
            return age;
        }
    }
}