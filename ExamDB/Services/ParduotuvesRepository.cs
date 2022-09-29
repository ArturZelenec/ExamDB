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

        public void EntryEkranas()
        {
            Console.WriteLine("Pasirinkite veiksma:");
            Console.WriteLine("1. Prisijungti");
            Console.WriteLine("2. Registruotis");
            Console.WriteLine("3. Darbuotojų Parinktys");
            Console.WriteLine("q. Exit");
            var veiksmas = Console.ReadKey().Key;
            if (veiksmas == ConsoleKey.NumPad1) Prisijungti();
            
            if (veiksmas == ConsoleKey.NumPad2) Registruotis();
            
            if (veiksmas == ConsoleKey.NumPad3) DarbuotojuParinktys();
            
            if (veiksmas == ConsoleKey.Q) return;
        }

        public void PirkimoEkranas()
        {
            Console.WriteLine("Pasirinkite veiksma:");
            Console.WriteLine("1. Peržiūrėti katalogą");
            Console.WriteLine("2. Įdėti į krepšelį");
            Console.WriteLine("3. Peržiūrėti krepšelį ");
            Console.WriteLine("4. Peržiūrėti pirkimų istorija (Išrašai) ");
            Console.WriteLine("q. Back");
            var veiksmas = Console.ReadKey().Key;
            if (veiksmas == ConsoleKey.NumPad1) PerziuretiKataloga();
            
            if (veiksmas == ConsoleKey.NumPad2) IdetiIKrepeeli();
            
            if (veiksmas == ConsoleKey.NumPad3) Perziuretikrepseli();
     
            if (veiksmas == ConsoleKey.NumPad4) PerziuretiPirkimuIstorija();
            
            if (veiksmas == ConsoleKey.Q) EntryEkranas();
            
        }
        public void PirkimoEkranasIdetiIKrepseli()
        {
            Console.WriteLine("Pasirinkite veiksma:");
            Console.WriteLine("1. Daina pagal Id");
            Console.WriteLine("2. Daina pagal pavadinimą");
            Console.WriteLine("3. Dainos pagal albumo Id");
            Console.WriteLine("4. Dainos pagal albumo pavadinimą");
            Console.WriteLine("q. Back");
            var veiksmas = Console.ReadKey().Key;
            if (veiksmas == ConsoleKey.NumPad1)
            {
                Console.WriteLine("Iveskite dainos Id");
                long dainosId = long.Parse(Console.ReadLine());
                DainaPagalId(dainosId);
            }
            
            if (veiksmas == ConsoleKey.NumPad2) DainaPagalPavadinima();
            
            if (veiksmas == ConsoleKey.NumPad3) DainosPagalAlbumoId();
            
            if (veiksmas == ConsoleKey.NumPad4) DainosPagalAlbumoPavadinima();
            
            if (veiksmas == ConsoleKey.Q) PirkimoEkranas();
            
        }
        public void DarbuotojuParinktysEkranas()
        {
            
            Console.WriteLine("Pasirinkite veiksma:");
            Console.WriteLine("1. Keisti klientų duomenis");
            Console.WriteLine("2. Pakeisti dainos statusą");
            Console.WriteLine("3. Statistika (Darbuotojams)");
            Console.WriteLine("q. Back");
            var veiksmas = Console.ReadKey().Key;
            if (veiksmas == ConsoleKey.NumPad1) KeistiKlientuDuomenis();
            
            if (veiksmas == ConsoleKey.NumPad2) PakeistiDainosStatusa();
            
            if (veiksmas == ConsoleKey.NumPad3) StatistikaDarbuotojams();
            
            if (veiksmas == ConsoleKey.Q) EntryEkranas();
            
        }
        public void DarbuotojuParinktysEkranasKeistiKlientuDuomenis()
        {
            
            Console.WriteLine("Pasirinkite veiksma:");
            Console.WriteLine("1. Gauti pirkėjų sąrašą");
            Console.WriteLine("2. Pašalinti pirkėją pagal ID");
            Console.WriteLine("3. Modifikuoti pirkėjo duomenis");
            Console.WriteLine("q. Back");
            var veiksmas = Console.ReadKey().Key;
            if (veiksmas == ConsoleKey.NumPad1) GautiPirkejuSarasa();
            
            if (veiksmas == ConsoleKey.NumPad2)
            {
                Console.WriteLine("Iveskite Customer Id");
                long customerId = long.Parse(Console.ReadLine());
                PasalintiPirkejaPagalID(customerId);
            }
            
            if (veiksmas == ConsoleKey.NumPad3) ModifikuotiPirkėjoDuomenis();
            
            if (veiksmas == ConsoleKey.Q) DarbuotojuParinktysEkranas();
            
        }

        private void ModifikuotiPirkėjoDuomenis()
        {
            throw new NotImplementedException();
        }

        private void PasalintiPirkejaPagalID(long customerId)
        {
            using (var chinContext = new ChinookContext())
            {
                var result = chinContext.Customers.Where(x => x.CustomerId == customerId).FirstOrDefault();
                result.SupportRep = null;
                //chinContext.Update(result);
                chinContext.Customers.Remove(result);
                chinContext.SaveChanges();
            }
        }

        private void GautiPirkejuSarasa()
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
        }

        private void StatistikaDarbuotojams()
        {
            throw new NotImplementedException();
        }

        private void PakeistiDainosStatusa()
        {
            throw new NotImplementedException();
        }

        private void KeistiKlientuDuomenis()
        {
            DarbuotojuParinktysEkranasKeistiKlientuDuomenis();
            
        }

        private void DainosPagalAlbumoPavadinima()
        {
            using (var chinContext = new ChinookContext())
            {
                var result = chinContext.Albums.GroupBy(g => g.Title);
            }
        }

        private void DainosPagalAlbumoId()
        {
            throw new NotImplementedException();
        }

        private void DainaPagalPavadinima()
        {
            throw new NotImplementedException();
        }

        private void DainaPagalId(long trackId)
        {
            using (var chinContext = new ChinookContext())
            {
                var result = chinContext.Tracks.Where(x => x.TrackId == trackId).Select(c => new Track
                {
                    TrackId = c.TrackId,
                    Album = c.Album,
                    Name = c.Name,
                });

                foreach (var item in result) { Console.WriteLine($"{item.TrackId} {item.Album} {item.Name}"); }
            }   
        }

        private void Perziuretikrepseli()
        {
            throw new NotImplementedException();
        }

        private void PerziuretiPirkimuIstorija()
        {
            throw new NotImplementedException();
        }

        private void IdetiIKrepeeli()
        {
            PirkimoEkranasIdetiIKrepseli();
            
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
                DarbuotojuParinktysEkranas();
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
            var pasirinktasId = int.Parse(Console.ReadLine());
            var atrinktasCustomer = visiCustomers.Where(x => x.CustomerId == pasirinktasId).FirstOrDefault();
            if (atrinktasCustomer == null)
            {
                Console.WriteLine("Nera tokio ID");
                Console.ReadKey();
                Console.Clear();
                EntryEkranas();

            }
            else
            {
                Console.Clear();
                PirkimoEkranas();

            }
        }
    }
}
