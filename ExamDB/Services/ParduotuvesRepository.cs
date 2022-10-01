using ExamDB.Database;
using ExamDB.Models;
using Microsoft.EntityFrameworkCore;
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

            if (veiksmas == ConsoleKey.NumPad2)
            {
                Console.WriteLine("Iveskite varda");
                string vardas = Console.ReadLine();
                Console.WriteLine("Iveskite pvarde");
                string pavarde = Console.ReadLine();
                Console.WriteLine("Iveskite kompanija");
                string company = Console.ReadLine();
                Console.WriteLine("Iveskite adresa");
                string adresas = Console.ReadLine();
                Console.WriteLine("Iveskite miesta");
                string miestas = Console.ReadLine();
                Console.WriteLine("Iveskite valstija");
                string valstija = Console.ReadLine();
                Console.WriteLine("Iveskite sali");
                string salis = Console.ReadLine();
                Console.WriteLine("Iveskite postKoda");
                string pastoKodas = Console.ReadLine();
                Console.WriteLine("Iveskite telNe");
                string telNr = Console.ReadLine();
                Console.WriteLine("Iveskite fax");
                string fax = Console.ReadLine();
                Console.WriteLine("Iveskite email");
                string email = Console.ReadLine();
                Registruotis(vardas, pavarde, company, adresas, miestas, valstija, salis, pastoKodas, telNr, fax, email);
            }
            
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

            if (veiksmas == ConsoleKey.NumPad2)
            {
                Console.WriteLine("Iveskite dainos pavadinima");
                string dainosPavadinimas = Console.ReadLine();
                DainaPagalPavadinima(dainosPavadinimas);
            }

            if (veiksmas == ConsoleKey.NumPad3)
            {
                Console.WriteLine("Iveskite albumo ID");
                long albumoId = long.Parse(Console.ReadLine());
                DainosPagalAlbumoId(albumoId);
            }

            if (veiksmas == ConsoleKey.NumPad4)
            {
                Console.WriteLine("Iveskite albumo pavadinima");
                string albumoPavdinimas = Console.ReadLine();
                DainosPagalAlbumoPavadinima(albumoPavdinimas);
            }
            
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
            if (veiksmas == ConsoleKey.NumPad1)
            {
                Console.WriteLine("Ivesjite Id");
                long klientoId = long.Parse(Console.ReadLine());
                Console.WriteLine("Iveskite varda");
                string vardas = Console.ReadLine();
                Console.WriteLine("Iveskite pavarde");
                string pavarde = Console.ReadLine();
                Console.WriteLine("Iveskite email");
                string email = Console.ReadLine();
                KeistiKlientuDuomenis(klientoId, vardas, pavarde, email);
            }

            if (veiksmas == ConsoleKey.NumPad2)
            {
                Console.WriteLine("Iveskite Dainos Id");
                long dainosId = long.Parse(Console.ReadLine());
                Console.WriteLine("Iveskite Statusa [Activ] arba [Notactiv]");
                string status = Console.ReadLine();
                PakeistiDainosStatusa(dainosId, status);
            }
            
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

        private void PakeistiDainosStatusa(long id, string status)
        {
            if (status == "Active")
            {
                using var context = new ChinookContext();
                var track = context.Tracks.Find(id);
                track.Status = "Active";
                context.SaveChanges();
            }
            else if (status == "Notactive")
            {
                using var context = new ChinookContext();
                var track = context.Tracks.Find(id);
                track.Status = "Notactive";
                context.SaveChanges();
            }
        }

        private void KeistiKlientuDuomenis(long id, string vardas, string pavarde, string email)
        {
            DarbuotojuParinktysEkranasKeistiKlientuDuomenis();
            using var context = new ChinookContext();
            var customer = context.Customers.Find(id);
            customer.FirstName = vardas;
            customer.LastName = pavarde;
            customer.Email = email;
            context.SaveChanges();
        }

        private void DainosPagalAlbumoPavadinima(string albumoPavadinimas)
        {
            using var context = new ChinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Active")
                .Include(x => x.Genre)
                .Include(x => x.Album)
                .Where(x => x.Album.Title == albumoPavadinimas)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"TrackId {track.TrackId}\n Name {track.Name}\n Genre.Name {track.Genre.Name}\n Composer {track.Composer} "); //{Encoding.Default.GetString(track.UnitPrice)} Eur
            }
        }

        private void DainosPagalAlbumoId(long albumoId)
        {
            using var context = new ChinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Active")
                .Include(x => x.Genre)
                .Where(x => x.AlbumId == albumoId)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.TrackId} {track.Name} {track.Genre.Name} {track.Composer} {Encoding.Default.GetString(track.UnitPrice)} Eur");
            }
        }

        private void DainaPagalPavadinima(string pavadinimas)
        {
            using var context = new ChinookContext();
            var result = context.Tracks
                .Where(x => x.Status == "Active")
                .Include(x => x.Genre)
                .Where(x => x.Name == pavadinimas)
                .ToList();
            foreach (var track in result)
            {
                Console.WriteLine($"{track.TrackId} {track.Name} {track.Genre.Name} {track.Composer}");
            }
        }

        private void DainaPagalId(long trackId)
        {
            using (var chinContext = new ChinookContext())
            {
                var result = chinContext.Tracks.Where(x => x.TrackId == trackId).Select(c => new Track
                {
                    
                    Album = c.Album,
                    Name = c.Name,
                });

                foreach (var item in result) 
                { 
                    Console.WriteLine($" {item.Album} {item.Name}"); 
                }
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
            using var context = new ChinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Active")
                .Include(x => x.Genre)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"{track.TrackId} {track.Name} {track.Genre.Name} {track.Composer} {Encoding.Default.GetString(track.UnitPrice)} Eur");
            }
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

        private void Registruotis(string vardas, string pavarde, string? company, string? adresas, string? miestas, string? valstija, string? salis, string? pastoKodas, string? telNr, string? fax, string email)
        {
            using var context = new ChinookContext();
            context.Customers.Add(new Customer
            {
                FirstName = vardas,
                LastName = pavarde,
                Company = company,
                Address = adresas,
                City = miestas,
                State = valstija,
                Country = salis,
                PostalCode = pastoKodas,
                Phone = telNr,
                Fax = fax,
                Email = email
            });
            context.SaveChanges();
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
