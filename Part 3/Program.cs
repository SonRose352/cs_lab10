using System.IO;

internal class Program
{
    static void Main(string[] args)
    {
        string basedir = "C:\\Users\\Нияз\\source\\repos\\cs_lab10\\cs_lab10\\basedir";

        // Создание директорий
        Directory.CreateDirectory(Path.Combine(basedir, "Picture"));
        Directory.CreateDirectory(Path.Combine(basedir, "Texts/History"));
        Directory.CreateDirectory(Path.Combine(basedir, "Texts/Horror/First"));

        // Создание файлов
        File.Create(Path.Combine(basedir, "Picture/1.txt")).Close();
        File.Create(Path.Combine(basedir, "Picture/2.txt")).Close();
        File.Create(Path.Combine(basedir, "Picture/3.txt")).Close();
        File.Create(Path.Combine(basedir, "Picture/4.txt")).Close();
        File.Create(Path.Combine(basedir, "Picture/5.txt")).Close();
        File.Create(Path.Combine(basedir, "Picture/6.txt")).Close();

        // Переименование файла
        File.Move(Path.Combine(basedir, "Picture/5.txt"), Path.Combine(basedir, "Picture/5000.txt"));

        // Перемещение файла в другую директорию
        File.Move(Path.Combine(basedir, "Picture/5000.txt"), Path.Combine(basedir, "Texts/History/5000.txt"));

        // Удаление файла
        File.Delete(Path.Combine(basedir, "Picture/6.txt"));

        // Ввод пользовательского выбора
        Console.Write("Введите имя файла, который нужно удалить из папки Picture: ");
        string filename = Console.ReadLine();

        // Удаление выбранного файла
        File.Delete(Path.Combine(basedir, "Picture", filename));

        // Удаление директорий
        Directory.Delete(Path.Combine(basedir, "Texts/Horror"), true);
        Directory.Delete(Path.Combine(basedir, "Picture"), true);
    }
}