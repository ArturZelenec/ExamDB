using ExamDB.Database;
using ExamDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDB.Services
{
    public class ParduotuvesRepository : IParduotuvesRepository
    {
        const string password = "1234";

        private readonly ChinookContext _context;

        public ParduotuvesRepository()
        {
            
        }

        public void Begin()
        {
            Console.WriteLine("Pasirinkite veiksma:");
            Console.WriteLine("1. Prisijungti");
            Console.WriteLine("2. Registruotis");
            Console.WriteLine("3. Darbuotojų Parinktys");
            Console.WriteLine("q. Exit");
            var veiksmas = Console.ReadKey().Key;

            if (veiksmas == ConsoleKey.NumPad1) Prisijungti();
            Console.Clear();
            if (veiksmas == ConsoleKey.NumPad2) Registruotis();
            Console.Clear();
            if (veiksmas == ConsoleKey.NumPad3) DarbuotojuParinktys();
            Console.Clear();
            if (veiksmas == ConsoleKey.Q) return;
        }

        public void Begin2()
        {
            Console.WriteLine("Pasirinkite veiksma:");
            Console.WriteLine("1. Peržiūrėti katalogą");
            Console.WriteLine("2. Įdėti į krepšelį");
            Console.WriteLine("3. Peržiūrėti krepšelį ");
            Console.WriteLine("4. Peržiūrėti pirkimų istorija (Išrašai) ");
            Console.WriteLine("q. Exit");
            var veiksmas = Console.ReadKey().Key;

            if (veiksmas == ConsoleKey.NumPad1) PerziuretiKataloga();
            Console.Clear();
            if (veiksmas == ConsoleKey.NumPad2) IdėtiIKrepeeli();
            Console.Clear();
            if (veiksmas == ConsoleKey.NumPad3) Perziuretikrepseli();
            Console.Clear();
            if (veiksmas == ConsoleKey.NumPad4) PerziuretiPirkimuIstorija();
            Console.Clear();
            if (veiksmas == ConsoleKey.Q) Begin();
            Console.Clear();

        }

        private void Perziuretikrepseli()
        {
            throw new NotImplementedException();
        }

        private void PerziuretiPirkimuIstorija()
        {
            throw new NotImplementedException();
        }

        private void IdėtiIKrepeeli()
        {
            throw new NotImplementedException();
        }

        private void PerziuretiKataloga()
        {
            throw new NotImplementedException();
        }

        private void DarbuotojuParinktys()
        {
            Console.WriteLine("Iveskite pin koda");
            string kodas = Console.ReadLine();
            if (kodas == password)
            {
                Begin2();
            }
        }

        private void Registruotis()
        {
            throw new NotImplementedException();
        }

        private void Prisijungti()
        {
            using var ctx = new ChinookContext();
            var visiCustomers = ctx.Customers.Select(c => new Customer
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                CustomerId = c.CustomerId,
                
            });
            foreach (var customer in visiCustomers)
            {
                Console.WriteLine($"\n FirstName: {customer.FirstName} {customer.LastName}\n CustomerId: {customer.CustomerId}");
            }
            Console.WriteLine("Pasirinkite ID");
            int pasirinktasId = int.Parse(Console.ReadLine());
           
        }
    }
}
