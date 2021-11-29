using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;


namespace PhoneBookApp
{
    internal class Program
    {
        public static bool inMenu = true;

        static void Main(string[] args)
        {
            var ContactsAndCalls = new Dictionary<Contact, List<string>>();
            do
            {
                int input = int.Parse(Console.ReadLine());
                MenuAction(input, ContactsAndCalls);
            } while (inMenu);
        }
        class Contact
        {
            public string NameAndSurname { get; set; }
            public string PhoneNumber { get; set; }
            public string Prefference { get; set; }
            public string DisplayDataContact()
            {
                return($"{NameAndSurname}-{PhoneNumber}-{Prefference}");
            }
            public Contact()
            {
                
            }
            public Contact(string prefference)
            {  
                Prefference = prefference;
                
            }
        }
       
        class OutgoingCall
        {
            public DateTime CallSetupTime { get; set; }
            public string CallStatus { get; set; }

        }
        private static void MenuAction(int input, IDictionary<Contact, List<string>> ContactsAndCalls)
        {
            
                switch (input)
                {
                    case 0:
                        inMenu = !inMenu;
                        break;  
                    case 1:
                        DisplayData(ContactsAndCalls);
                        break;
                    case 2:
                        AddNewContact(ContactsAndCalls);
                        break;
                    case 3:
                        DeleteContact(ContactsAndCalls);
                        break;
                    case 4:
                        Prefferences(ContactsAndCalls);
                        break;
                    default:
                        Console.WriteLine("Krivo upisan podatak");
                        break;

                }
            
            
        }
        private static string MainMenu()
        {
            return
                "Telefonski imenik: \n" +
                "1. Ispis svih kontakata\n" +
                "2. Dodavanje novih kontakata u imenik\n" +
                "3. Brisanje kontakata iz imenika\n" +
                "4. Editiranje preferenca iz kontakata\n" +
                "5. Upravljanje kontaktom koje otvara podmenu sa sljedecim funkcionalnostima: \n" +
                "0. za izlaz iz programa\n" ;

        }
        private static string SubMenu()
        {
            return
                "Sub menu:\n" +
                "1. Ispis svih poziva sa poredan od vremenski najnovijeg prema najstarijem\n" +
                "2. Kreiranje novog poziva\n" +
                "3. izlaz iz podmenua"+
                "0. za izlaz iz programa\n";
        }
        private static string MenuContinuation()
        {
            
                return
                    "Menu:\n" +
                    "1. Ispis svih poziva" +
                    "2. Izlaz iz aplikacije" +
                    "0. za izlaz iz programa\n";
            

        }
        private static void DisplayData(IDictionary<Contact, List<string>> ContactsAndCalls)
        {
            var newContact = new Contact();
            int ContactNo=1;
            foreach (var item in ContactsAndCalls)
            {
                Console.WriteLine($"{ContactNo}.kontakt: {item.Key.DisplayDataContact()}");
                ContactNo++;
            }
            Pause();
            Console.Clear();
        }
        private static void AddNewContact(IDictionary<Contact, List<string>> ContactsAndCalls)
        {
            var newContact =new Contact();

            NameSurname(newContact.NameAndSurname);
            PhoneNumber(newContact.PhoneNumber);
            ContactsAndCalls.Add(newContact, null);
            Console.Clear();

        }
        private static void Pause()
        {
            Task.Delay(3000).Wait();
        }
        private static void PrefferenceType(string type)
        {
            Console.WriteLine("Unesi preferencu kontakta, može biti: favorit, normalan ili blokiran");
            type = Console.ReadLine();
            while(type != "favorit" && type!="blokiran" && type != "normalan")
            {
                Console.WriteLine("neispravan unos pokušajte ponovno");
                type = Console.ReadLine();
            }
        }
        private static void PhoneNumber(string number)
        {
            Console.WriteLine("Unesi broj telefona: ");
            number = Console.ReadLine();
            while (string.IsNullOrEmpty(number) || number.Length != 10)
            {
                Console.WriteLine("Neispravan unos, pokušajte ponovno");
                number = Console.ReadLine();
            }
        }
        private static void NameSurname(string name)
        {
            Console.WriteLine("Unesi ime i Prezime: ");
            name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Neispravan unos, pokušajte ponovno");
                name = Console.ReadLine();
            }
        }
        private static void DeleteContact(IDictionary<Contact, List<string>> ContactsAndCalls)
        {
            var newContact = new Contact();
            NameSurname(newContact.NameAndSurname);
            PhoneNumber(newContact.PhoneNumber);
            while (!ContactsAndCalls.ContainsKey(newContact))
            {
                Console.WriteLine("toga kontakta nema u imeniku, unesi ponovno: ");
                NameSurname(newContact.NameAndSurname);
                PhoneNumber(newContact.PhoneNumber);
            }
            ContactsAndCalls.Remove(newContact);
        }
        private static void Prefferences(IDictionary<Contact, List<string>> ContactsAndCalls)
        {
            var newContact = new Contact();
            NameSurname(newContact.NameAndSurname);
            PhoneNumber(newContact.PhoneNumber);
            while (!ContactsAndCalls.ContainsKey(newContact))
            {
                Console.WriteLine("toga kontakta nema u imeniku, unesi ponovno: ");
                NameSurname(newContact.NameAndSurname);
                PhoneNumber(newContact.PhoneNumber);
            }
            PrefferenceType(newContact.Prefference);
            foreach (Contact item in ContactsAndCalls.Keys)
            {
                if (item.NameAndSurname == newContact.NameAndSurname && item.PhoneNumber == newContact.PhoneNumber)
                {
                    item.Prefference = newContact.Prefference;
                }
                break;
            }
            
        }
    }
    
}
