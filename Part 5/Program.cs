using Part_5;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Person[] array = new Person[3];
        array[0] = new Person("Tukhbatullin", 170, 55, new DateTime(2004, 9, 20));
        array[1] = new Person("Sydorov", 165, 52, new DateTime(2005, 5, 13));
        array[2] = new Person("Vasil'ev", 187, 79, new DateTime(2002, 11, 23));

        Person person4 = new Person();
        person4.input();
        Person person5 = new Person();
        person5.input();

        using (StreamWriter writer = new StreamWriter(@"C:\Users\Нияз\source\repos\cs_lab10\basedir\data\persons.txt"))
        {
            writer.WriteLine(array[0].ToString());
            writer.WriteLine(array[1].ToString());
            writer.WriteLine(array[2].ToString());
            writer.WriteLine(person4.ToString());
            writer.WriteLine(person5.ToString());
        }

        Person[] newArray = new Person[5];
        using (StreamReader reader = new StreamReader(@"C:\Users\Нияз\source\repos\cs_lab10\basedir\data\persons.txt"))
        {
            string textFromFile = reader.ReadToEnd();
            string[] strArray = textFromFile.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < newArray.Length; i++)
            {
                string[] personData = strArray[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] dateElems = personData[3].Split('.');
                newArray[i] = new Person(personData[0],
                    Convert.ToInt32(personData[1]),
                    Convert.ToInt32(personData[2]),
                    new DateTime(Convert.ToInt32(dateElems[2]), Convert.ToInt32(dateElems[1]), Convert.ToInt32(dateElems[0])));
            }
        }

        Console.WriteLine("\nФамилия и возраст каждого человека:");
        foreach (Person person in newArray)
        {
            Console.WriteLine($"{person.SurName}\t{person.age()}");
        }

        int heightSum = 0;
        int weightSum = 0;
        foreach (Person person in newArray)
        {
            heightSum += person.Height;
            weightSum += person.Weight;
        }
        Console.WriteLine($"\nСредний рост: {heightSum / 5}\nСредний вес: {weightSum / 5}");
        using (StreamWriter writer = new StreamWriter(@"C:\Users\Нияз\source\repos\cs_lab10\basedir\data\persons.txt"))
        {
            writer.WriteLine($"\nСредний рост: {heightSum / 5}\nСредний вес: {weightSum / 5}");
        }

        Console.WriteLine("\nДанные тех, кто имеет избыточный вес:");
        foreach (Person person in newArray)
        {
            if (person.Weight > person.Height - 90)
            {
                person.output();
                using (StreamWriter writer = new StreamWriter(@"C:\Users\Нияз\source\repos\cs_lab10\basedir\data\persons.txt"))
                {
                    writer.WriteLine(person.ToString());
                }
            }
        }
    }
}