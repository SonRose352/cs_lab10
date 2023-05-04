using System.Globalization;
using System.IO;
using System.Text;

internal class Program
{
    static void Main(string[] args)
    {
        string file1 = "C:\\Users\\Нияз\\source\\repos\\cs_lab10\\basedir\\data\\dataset_1.txt";
        string file2 = "C:\\Users\\Нияз\\source\\repos\\cs_lab10\\basedir\\data\\dataset_2.txt";
        string file3 = "C:\\Users\\Нияз\\source\\repos\\cs_lab10\\basedir\\data\\dataset_3.txt";
        string file4 = "C:\\Users\\Нияз\\source\\repos\\cs_lab10\\basedir\\data\\dataset_4.txt";
        string file5 = "C:\\Users\\Нияз\\source\\repos\\cs_lab10\\basedir\\data\\dataset_5.txt";
        TaskA(file1);
        TaskB(file2);
        TaskC(file3);
        TaskD(file4);
        TaskE(file5);
    }

    public static void TaskA(string file)
    {
        using (StreamReader reader = new StreamReader(file))
        {
            string textFromFile = reader.ReadToEnd();
            string[] strArray = textFromFile.Split();
            int[] array = new int[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                array[i] = Convert.ToInt32(strArray[i]);
            }
            Console.WriteLine($"Task A\na + b = {array[0] + array[1]}");
            Console.WriteLine($"a * b = {array[0] * array[1]}");
            Console.WriteLine($"a + b^2 = {array[0] + Math.Pow(array[1], 2)}\n");
        }
    }

    public static void TaskB(string file)
    {
        using (StreamReader reader = new StreamReader(file))
        {
            string textFromFile = reader.ReadToEnd();
            string[] strArray = textFromFile.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            int[] array = new int[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                array[i] = Convert.ToInt32(strArray[i]);
            }
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                    count++;
            }
            Console.WriteLine($"Task B\nКоличество чётных чисел: {count}\n");
        }
    }

    public static void TaskC(string file)
    {
        using (StreamReader reader = new StreamReader(file))
        {
            string textFromFile = reader.ReadToEnd();
            string[] strArray = textFromFile.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] array = new int[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                array[i] = Convert.ToInt32(strArray[i]);
            }
            Console.WriteLine("Task C:");
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 9999)
                {
                    Console.Write(array[i] + " ");
                    using (StreamWriter writer = new StreamWriter(@"C:\Users\Нияз\source\repos\cs_lab10\basedir\data\res_3.txt", true))
                    {
                        writer.WriteAsync(array[i] + " ");
                    }
                }
            }
            Console.WriteLine("\n");
        }
    }

    public static void TaskD(string file)
    {
        using (StreamReader reader = new StreamReader(file))
        {
            string textFromFile = reader.ReadToEnd();
            string[] strArray = textFromFile.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] array = new int[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                array[i] = Convert.ToInt32(strArray[i]);
            }
            int maxElem = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxElem)
                    maxElem = array[i];
            }
            Console.WriteLine($"Task D:\nНаибольшее число: {maxElem}\n");
            using (StreamWriter writer = new StreamWriter(@"C:\Users\Нияз\source\repos\cs_lab10\basedir\data\res_3.txt", true))
            {
                writer.Write(maxElem);
            }
        }
    }

    public static void TaskE(string file)
    {
        using (StreamReader reader = new StreamReader(file))
        {
            string textFromFile = reader.ReadToEnd();
            string[] strArray = textFromFile.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Task E:");
            foreach (string str in strArray)
            {
                Console.WriteLine(str.ToUpper());
            }
        }
    }
}