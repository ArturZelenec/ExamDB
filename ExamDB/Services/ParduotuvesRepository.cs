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
        
        private Customer? _logIncustomer;
        private long? invoiceId;

        public ParduotuvesRepository()
        {
            
        }

        public void Pirkimai(long customerId, long trackId )
        {
            using var context = new ChinookContext();
            var invoice = new Invoice
            {
                CustomerId = _logIncustomer.CustomerId,
            };
            invoice.InvoiceItems.Add(new InvoiceItem
            {
                
                TrackId = trackId
                
                
            });
            context.Invoices.Add(invoice);
            context.SaveChanges();
            Console.WriteLine("Nupirkta");
            Console.WriteLine("Sugristi [q]");
            var veiksmas = Console.ReadKey().Key;
            if (veiksmas == ConsoleKey.Q) PirkimoEkranas();
           
        }
        public void PirkimaiAlbumo(long customerId, long albumId)
        {
            using var context = new ChinookContext();
            var invoice = new Invoice
            {
                CustomerId = _logIncustomer.CustomerId,
            };
            invoice.InvoiceItems.Add(new InvoiceItem
            {
                
                InvoiceId = albumId

            });
            context.Invoices.Add(invoice);
            context.SaveChanges();
        }

        private void Perziuretikrepseli()
        {
            Console.Clear();
            Console.WriteLine("UNDER CONSTRUCTION COMING SOON");
            Console.ReadLine();
            return;
        }

        private void PerziuretiPirkimuIstorija()
        {
            Console.Clear();
            Console.WriteLine("UNDER CONSTRUCTION COMING SOON");
            Console.ReadLine();
            return;
        }

       

        private void PerziuretiKataloga()
        {
            using var context = new ChinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Activ")
                .Include(x => x.Genre)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"TrackId => {track.TrackId}\n \tName = >{track.Name}\n \tGenre.Name => {track.Genre.Name}\n \tComposer => {track.Composer}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Pasirinkite veiksmas: [o] => rikiavimas;  [s] => paieska; [q] => sugrizti atgal");
            Console.ResetColor();
            var pasirinkimas = Console.ReadKey().Key;
            if (pasirinkimas == ConsoleKey.O)
            {
                Console.WriteLine("Rikiavimas: [A] => ABC; [Z] => CBA");
                var pasirinkimas2 = Console.ReadKey().Key;
                if (pasirinkimas2 == ConsoleKey.A) TracksNameDidejimas();
                if (pasirinkimas2 == ConsoleKey.Z) TracksNameMazejancia();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pasirinkite veiksmas: [s] => rusiavimas; [q] => sugrizti atgal");
                var pasirinkimas3 = Console.ReadKey().Key;
                Console.ResetColor();
                if (pasirinkimas3 == ConsoleKey.S) RikiavimoEkranas();
                if (pasirinkimas3 == ConsoleKey.Q) PirkimoEkranas();
            }
           
                //Console.WriteLine("Pasirinkite veiksma [p] => paieska [q] => grizti");
                //var pasirinkimas3 = Console.ReadKey().Key;
                if (pasirinkimas == ConsoleKey.S) PirkimoEkranasIdetiIKrepseli();
                if (pasirinkimas == ConsoleKey.Q) PirkimoEkranas();
            
        }

        private void StatistikaDarbuotojams()
        {
            Console.Clear();
            Console.WriteLine("UNDER CONSTRUCTION COMING SOON");
            Console.ReadLine();
            return;
        }


       

        #region Ekranai
        public void EntryEkranas()
        {
            Console.Clear();
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
            Console.Clear();
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
        private void IdetiIKrepeeli()
        {
            Console.Clear();

            PirkimoEkranasIdetiIKrepseli();

        }
        public void PirkimoEkranasIdetiIKrepseli()
        {
            Console.Clear();

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
            Console.Clear();


            Console.WriteLine("Pasirinkite veiksma:");
            Console.WriteLine("1. Keisti klientų duomenis");
            Console.WriteLine("2. Pakeisti dainos statusą");
            Console.WriteLine("3. Statistika (Darbuotojams)");
            Console.WriteLine("q. Back");
            var veiksmas = Console.ReadKey().Key;
            if (veiksmas == ConsoleKey.NumPad1)
            {

                KeistiKlientuDuomenis();
            }

            if (veiksmas == ConsoleKey.NumPad2)
            {
                Console.WriteLine("Iveskite Dainos Id");
                long dainosId = long.Parse(Console.ReadLine());
                Console.WriteLine("Iveskite Statusa [Activ] arba [Inactive]");
                string status = Console.ReadLine();
                PakeistiDainosStatusa(dainosId, status);
            }

            if (veiksmas == ConsoleKey.NumPad3) StatistikaDarbuotojams();

            if (veiksmas == ConsoleKey.Q) EntryEkranas();

        }
        public void DarbuotojuParinktysEkranasKeistiKlientuDuomenis()
        {
            Console.Clear();

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

            if (veiksmas == ConsoleKey.NumPad3)
            {
                Console.WriteLine("Ivesjite Id");
                long klientoId = long.Parse(Console.ReadLine());
                Console.WriteLine("Iveskite varda");
                string vardas = Console.ReadLine();
                Console.WriteLine("Iveskite pavarde");
                string pavarde = Console.ReadLine();
                Console.WriteLine("Iveskite email");
                string email = Console.ReadLine();
                ModifikuotiPirkėjoDuomenis(klientoId, vardas, pavarde, email);
            }

            if (veiksmas == ConsoleKey.Q) PirkimoEkranasIdetiIKrepseli();

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
        private void KeistiKlientuDuomenis()
        {
            DarbuotojuParinktysEkranasKeistiKlientuDuomenis();

        }
        public void RikiavimoEkranas()
        {
            Console.Clear();

            Console.WriteLine("Pasirinkite veiksma:");
            Console.WriteLine("1. Pagal Composer");
            Console.WriteLine("2. Pagal Genre");
            Console.WriteLine("3. Pagal Composer And Genre");
            Console.WriteLine("q. Back");
            var veiksmas = Console.ReadKey().Key;
            if (veiksmas == ConsoleKey.NumPad1) 
            {
                DainosByComposer();
                Console.WriteLine("Sugristi [q]");
                var veiksmas4 = Console.ReadKey().Key;
                if (veiksmas4 == ConsoleKey.Q) PirkimoEkranas();
                
            }
            if (veiksmas == ConsoleKey.NumPad2)
            {
                DainosByGenre();
                Console.WriteLine("Sugristi [q]");
                var veiksmas4 = Console.ReadKey().Key;
                if (veiksmas4 == ConsoleKey.Q) PirkimoEkranas();
                
            }
            if (veiksmas == ConsoleKey.NumPad3) 
            {
                DainosByComposerAndGenre();
                Console.WriteLine("Sugristi [q]");
                var veiksmas4 = Console.ReadKey().Key;
                if (veiksmas4 == ConsoleKey.Q) PirkimoEkranas();
            }
            if (veiksmas == ConsoleKey.Q)
            {
                DarbuotojuParinktysEkranas();
                Console.WriteLine("Sugristi [q]");
                var veiksmas4 = Console.ReadKey().Key;
                if (veiksmas4 == ConsoleKey.Q) PirkimoEkranas();
            }
        }
        #endregion

        #region Prisijungimas
        private void Prisijungti()
        {

            using var context = new ChinookContext();
            var visiCustomers = context.Customers.Select(c => new Customer
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                CustomerId = c.CustomerId,

            });
            foreach (var customer in visiCustomers)
            {
                Console.WriteLine($"\n FirstName => {customer.FirstName} {customer.LastName}\n CustomerId => {customer.CustomerId}");
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
                _logIncustomer = atrinktasCustomer;
                PirkimoEkranas();
            }
            

        }
        
        #endregion

        #region Registruotis
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
            Console.WriteLine("User sukurtas");
            Console.ReadLine();
        }

        #endregion

        #region Pirkejo Modifikavimas
        private void ModifikuotiPirkėjoDuomenis(long id, string vardas, string pavarde, string email)
        {
            using var context = new ChinookContext();
            var customer = context.Customers.Find(id);
            customer.FirstName = vardas;
            customer.LastName = pavarde;
            customer.Email = email;
            context.SaveChanges();

            Console.WriteLine("Sugristi [q]");
            var veiksmas = Console.ReadKey().Key;
            if (veiksmas == ConsoleKey.Q) DarbuotojuParinktysEkranasKeistiKlientuDuomenis();
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
            Console.WriteLine("Istrinta");
            Console.WriteLine("Sugristi [q]");
            var veiksmas = Console.ReadKey().Key;
            if (veiksmas == ConsoleKey.Q) DarbuotojuParinktysEkranasKeistiKlientuDuomenis();
        }
        private void GautiPirkejuSarasa()
        {
            using var context = new ChinookContext();
            var visiCustomers = context.Customers.Select(c => new Customer
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                CustomerId = c.CustomerId,

            });
            foreach (var customer in visiCustomers)
            {
                Console.WriteLine($"\n FirstName => {customer.FirstName} {customer.LastName}\n \tCustomerId => {customer.CustomerId}");
            }
            Console.WriteLine("Sugristi [q]");
            var veiksmas = Console.ReadKey().Key;
            if (veiksmas == ConsoleKey.Q) DarbuotojuParinktysEkranasKeistiKlientuDuomenis();
            
        }



        #endregion

        #region Rusiavimas
        public void TracksNameDidejimas()
        {
            using var context = new ChinookContext();
            var tracks = context.Tracks
                .OrderBy(x => x.Name)
                .Include(x => x.Genre)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"TrackId => {track.TrackId}\n \tName => {track.Name}\n \tGenre Name => {track.Genre.Name}\n \tComposer => {track.Composer}");
            }
        }
        public void TracksNameMazejancia()
        {
            using var context = new ChinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Activ")
                .Include(x => x.Genre)
                .OrderByDescending(x => x.Name)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"TrackId => {track.TrackId}\n \tName => {track.Name}\n \tGenre Name => {track.Genre.Name}\n \tComposer => {track.Composer} ");
            }
        }
        public void DainosByComposer()
        {
            using var context = new ChinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Activ")
                .Include(x => x.Genre)
                .OrderBy(x => x.Composer)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"TrackId => {track.TrackId}\n \tName => {track.Name}\n \tGenre.Name => {track.Genre.Name}\n \tComposer => {track.Composer}");
            }
        }
        public void DainosByGenre()
        {
            using var context = new ChinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Activ")
                .Include(x => x.Genre)
                .OrderBy(x => x.Genre)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"TrackId => {track.TrackId}\n \tName => {track.Name}\n \tGenre.Name => {track.Genre.Name}\n \tComposer => {track.Composer}");
            }
        }
        public void DainosByComposerAndGenre()
        {
            using var context = new ChinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Activ")
                .Include(x => x.Genre)
                .OrderBy(x => x.Composer).ThenBy(x => x.Genre)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"TrackId => {track.TrackId}\n \tName => {track.Name}\n \tGenre.Name => {track.Genre.Name}\n \tComposer => {track.Composer}");
            }
        }
        #endregion

        #region Dainu Statuso Ketimas
        private void PakeistiDainosStatusa(long id, string status)
        {
            if (status == "Activ")
            {
                using var context = new ChinookContext();
                var track = context.Tracks.Find(id);
                track.Status = "Activ";
                context.SaveChanges();
            }
            else if (status == "Inactive")
            {
                using var context = new ChinookContext();
                var track = context.Tracks.Find(id);
                track.Status = "Inactive";
                context.SaveChanges();
            }
        }
        #endregion

        #region Dainu Paeska
        public void PaieskaSecundemDaugiau(int daugiau)
        {
            using var context = new ChinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Activ")
                .Include(x => x.Genre)
                .Where(x => x.Milliseconds > daugiau)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"TrackId => {track.TrackId}\n \tName => {track.Name}\n \tGenre Name => {track.Genre.Name}\n \tComposer => {track.Composer}");
            }
        }
        public void PaieskaSecundemMaziau(int maziau)
        {
            using var context = new ChinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Activ")
                .Include(x => x.Genre)
                .Where(x => x.Milliseconds < maziau)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"TrackId => {track.TrackId}\n \tName => {track.Name}\n \tGenre Name => {track.Genre.Name}\n \tComposer => {track.Composer}");
            }
        }
        private void DainosPagalAlbumoPavadinima(string albumoPavadinimas)
        {
            using var context = new ChinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Activ")
                .Include(x => x.Genre)
                .Include(x => x.Album)
                .Where(x => x.Album.Title == albumoPavadinimas)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"TrackId {track.TrackId}\n Name {track.Name}\n Genre.Name {track.Genre.Name}\n Composer {track.Composer} "); //{Encoding.Default.GetString(track.UnitPrice)} Eur
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Norite nupirkti visos dainos spauskite => [y] sugrizti atgal => [q]");
            Console.ResetColor();
            var pasirinkimas = Console.ReadKey().Key;
            if (pasirinkimas == ConsoleKey.Y)
            {

            }
            if (pasirinkimas == ConsoleKey.Q)
            {
                PirkimoEkranasIdetiIKrepseli();
            }
        }
        private void DainosPagalAlbumoId(long albumoId)
        {
            using var context = new ChinookContext();
            var tracks = context.Tracks
                .Where(x => x.Status == "Activ")
                .Include(x => x.Genre)
                .Where(x => x.AlbumId == albumoId)
                .ToList();
            foreach (var track in tracks)
            {
                Console.WriteLine($"TrackId => {track.TrackId}\n \tName => {track.Name}\n \tGenre.Name => {track.Genre.Name}\n \tComposer => {track.Composer}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Norite nupirkti visos dainos spauskite => [y] sugrizti atgal => [q]");
            Console.ResetColor();
            var pasirinkimas = Console.ReadKey().Key;
            if (pasirinkimas == ConsoleKey.Y)
            {
                PirkimaiAlbumo(_logIncustomer.CustomerId, albumoId);
            }
            if (pasirinkimas == ConsoleKey.Q)
            {
                PirkimoEkranasIdetiIKrepseli();
            }
        }
        private void DainaPagalPavadinima(string pavadinimas)
        {
            using var context = new ChinookContext();
            var result = context.Tracks
                .Where(x => x.Status == "Activ")
                .Include(x => x.Genre)
                .Where(x => x.Name == pavadinimas)
                .ToList();
            foreach (var track in result)
            {
                Console.WriteLine($"TrackId => {track.TrackId}\n \tName => {track.Name}\n \tGenre Name => {track.Genre.Name}\n \tComposer => {track.Composer}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Norite nupirkti daina spauskite => [y] sugrizti atgal => [q]");
            Console.ResetColor();
            var pasirinkimas = Console.ReadKey().Key;
            if (pasirinkimas == ConsoleKey.Y)
            {

            }
            if (pasirinkimas == ConsoleKey.Q)
            {
                PirkimoEkranasIdetiIKrepseli();
            }
        }
        private void DainaPagalId(long trackId)
        {
            using var context = new ChinookContext();

            var result = context.Tracks
            .Where(x => x.TrackId == trackId)
            .Select(c => new Track
            {

                Album = c.Album,
                Name = c.Name,
            });

            foreach (var item in result)
            {
                Console.WriteLine($"Album Title => {item.Album.Title}\n \tName => {item.Name}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Norite nupirkti daina spauskite => [y] sugrizti atgal => [q]");
            Console.ResetColor();
            var pasirinkimas = Console.ReadKey().Key;
            if (pasirinkimas == ConsoleKey.Y)
            {
                Pirkimai(_logIncustomer.CustomerId, trackId);
            }
            if (pasirinkimas == ConsoleKey.Q)
            {
                PirkimoEkranasIdetiIKrepseli();
            }

        }



        #endregion

    }
}
