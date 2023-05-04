using System.Globalization;

string dirName = "C:\\Users\\Нияз\\source\\repos\\cs_lab10\\cs_lab10\\basedir\\dir0";
string basedir = "C:\\Users\\Нияз\\source\\repos\\cs_lab10\\cs_lab10\\basedir";
string[] dirsAndFiles = Directory.GetFileSystemEntries(dirName);

//Task a)
int countFD = 0;
foreach (string dir in dirsAndFiles) countFD++;
Console.WriteLine($"1) Общее количествофайлов и каталогов в директории basedir/dir0/: {countFD}");

//Task b)
Console.WriteLine("\n2) Имена каталогов непосредственно из директории basedir/dir0/:");
foreach (string dir in Directory.GetDirectories(dirName)) Console.WriteLine(dir);

//Task c)
int countF = 0;
int countTxtF = 0;
foreach (string dir in Directory.GetFiles(dirName))
{
    FileInfo fileInfo = new FileInfo(dir);
    countF++;
    if (fileInfo.Extension == ".txt")
        countTxtF++;
}
Console.WriteLine($"\nКоличество файлов в директории basedir/dir0/: {countF}");
Console.WriteLine($"Количество текстовых файлов в директории basedir/dir0/: {countTxtF}");

//Task d)
void TaskD(string basedir)
{
    foreach (string dir in Directory.GetDirectories(basedir))
    {
        if (Directory.GetDirectories(dir).Length + Directory.GetFiles(dir).Length == 0)
            Console.WriteLine(dir);
        else
            TaskD(dir);
    }
}

Console.WriteLine("\nИмена всех пустых директорий в рассматриваемой иерархии:");
TaskD(basedir);

//Task e)
FileInfo elki = new FileInfo("basedir\\dir0\\елки.txt");
Console.WriteLine($"\nПолный абсолютный путь файла елки.txt: {elki.DirectoryName}");

//Task f)
void TaskF(string basedir)
{
    foreach (string file in Directory.GetFiles(basedir))
    {
        Console.WriteLine(file);
    }
    foreach (string dir in Directory.GetDirectories(basedir))
    {
        Console.WriteLine(dir);
        TaskF(dir);
    }
}

Console.WriteLine("\nИмена всех вложенных файлов и директорий в рассматриваемой иерархии:");
TaskF(basedir);

Task g)
string dirG = basedir;
void TaskG(string basedir, ref string dirG)
{
    if (Directory.GetFiles(basedir).Length > Directory.GetFiles(dirG).Length)
        dirG = basedir;
    foreach (string dir in Directory.GetDirectories(basedir))
        TaskG(dir, ref dirG);
}
TaskG(basedir, ref dirG);
Console.WriteLine($"Имя директории с максимальным количеством файлов: {dirG}");

//Task h)
DirectoryInfo GetDeepestDirectory(DirectoryInfo directory)
{
    DirectoryInfo deepestDir = null;
    int deepestLevel = 0;

    foreach (var dir in directory.GetDirectories())
    {
        int level = GetDirectoryLevel(dir);
        if (level > deepestLevel)
        {
            deepestDir = dir;
            deepestLevel = level;
        }

        DirectoryInfo childDeepest = GetDeepestDirectory(dir);
        if (childDeepest != null && GetDirectoryLevel(childDeepest) > deepestLevel)
        {
            deepestDir = childDeepest;
            deepestLevel = GetDirectoryLevel(childDeepest);
        }
    }

    return deepestDir;
}

int GetDirectoryLevel(DirectoryInfo directory)
{
    int level = 0;
    DirectoryInfo parent = directory.Parent;
    while (parent != null)
    {
        level++;
        parent = parent.Parent;
    }

    return level;
}

Console.WriteLine($"Полное имя файла или директории с самой глубокой вложенностью: {GetDeepestDirectory(new DirectoryInfo(basedir))}");

//Task i)
DriveInfo drive = new DriveInfo(Path.GetPathRoot(basedir));
long freeSpace = drive.TotalFreeSpace;

Console.WriteLine($"Свободное место на диске: {freeSpace}");

//Task j)
DriveInfo[] allDrives = DriveInfo.GetDrives();

int driveCount = allDrives.Length;
Console.WriteLine($"Количество устройств хранения: {driveCount}");

foreach (DriveInfo d in allDrives)
{
    Console.WriteLine("Имя устройства: {0}", d.Name);
}