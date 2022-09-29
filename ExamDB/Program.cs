using ExamDB.Services;

namespace ExamDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var repo = new ParduotuvesRepository();
            repo.EntryEkranas();
        }
    }
    
}
