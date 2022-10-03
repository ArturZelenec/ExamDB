using ExamDB.Services;

namespace ExamDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            while (true)
            {
                var repo = new ParduotuvesRepository();
                repo.EntryEkranas();
            }
                
               

            

        }
    }
    
}
