namespace six
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до файла: ");
            string path = Console.ReadLine();
            if (File.Exists(path))
            {
                Console.Clear();
                SaveFiles newf = new SaveFiles();
                newf.Serialize(path);
            }
            else
            {
                Console.WriteLine("Такого файла нет");
            }
        }
    }
}