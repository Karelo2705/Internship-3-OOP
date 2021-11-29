using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PhoneBookApp
{
    internal class Program
    {
        public static bool inMenu = true;

        static void Main(string[] args)
        {
            var ContactsAndCalls = new Dictionary<Contact, List<OutgoingCall>>();
            do
            {
                
                int input = MenuInput();
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
        private static void MenuAction(int input, IDictionary<Contact, List<OutgoingCall>> ContactsAndCalls)
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
                    case 5:
                    var newInput = MenuInputSub();
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
        private static void DisplayData(IDictionary<Contact, List<OutgoingCall>> ContactsAndCalls)
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
        private static void AddNewContact(IDictionary<Contact, List<OutgoingCall>> ContactsAndCalls)
        {
            var newContact =new Contact();

            newContact.NameAndSurname = NameSurname(newContact.NameAndSurname);
            newContact.PhoneNumber = PhoneNumber(newContact.PhoneNumber);
            newContact.Prefference = PrefferenceType(newContact.Prefference);
            ContactsAndCalls.Add(newContact, null);
            Console.Clear();

        }
        private static void Pause()
        {
            Task.Delay(3000).Wait();
        }
        private static string PrefferenceType(string type)
        {
            Console.WriteLine("Unesi preferencu kontakta, može biti: favorit, normalan ili blokiran");
            type = Console.ReadLine();
            while(type != "favorit" && type!="blokiran" && type != "normalan")
            {
                Console.WriteLine("neispravan unos pokušajte ponovno");
                type = Console.ReadLine();
            }
            return type;
        }
        public static string PhoneNumber(string number)
        {
            Console.WriteLine("Unesi broj telefona: ");
            number = Console.ReadLine();
            while (string.IsNullOrEmpty(number) || number.Length != 10)
            {
                Console.WriteLine("Neispravan unos, pokušajte ponovno");
                number = Console.ReadLine();
            }
            return number;
        }
        public static string NameSurname(string name)
        {
            Console.WriteLine("Unesi ime i Prezime: ");
            name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Neispravan unos, pokušajte ponovno");
                name = Console.ReadLine();
            }
            return name;
        }
        private static void DeleteContact(IDictionary<Contact, List<OutgoingCall>> ContactsAndCalls)
        {
            var newContact = new Contact();
            newContact.NameAndSurname = NameSurname(newContact.NameAndSurname);
            newContact.PhoneNumber = PhoneNumber(newContact.PhoneNumber);
            foreach(var item in ContactsAndCalls)
            {
                if (item.Key.PhoneNumber != newContact.PhoneNumber || item.Key.NameAndSurname != newContact.NameAndSurname)
                {
                    Console.WriteLine("toga kontakta nema u imeniku, unesi ponovno: ");
                    newContact.NameAndSurname = NameSurname(newContact.NameAndSurname);
                    newContact.PhoneNumber = PhoneNumber(newContact.PhoneNumber);
                    continue;
                } 
                ContactsAndCalls.Remove(item);
            }
            Console.Clear();
        }
        private static void Prefferences(IDictionary<Contact, List<OutgoingCall>> ContactsAndCalls)
        {
            var newContact = new Contact();
            newContact.NameAndSurname= NameSurname(newContact.NameAndSurname);
            newContact.PhoneNumber = PhoneNumber(newContact.PhoneNumber);
            foreach(var item in ContactsAndCalls)
            {
                if (item.Key.PhoneNumber != newContact.PhoneNumber || item.Key.NameAndSurname != newContact.NameAndSurname)
                {
                    Console.WriteLine("toga kontakta nema u imeniku, unesi ponovno: ");
                    newContact.NameAndSurname = NameSurname(newContact.NameAndSurname);
                    newContact.PhoneNumber = PhoneNumber(newContact.PhoneNumber);
                    continue;
                }
                ContactsAndCalls.Remove(item); 
            }
            Console.WriteLine("unesi novi prefference za ovaj kontakt");
            newContact.Prefference = PrefferenceType(newContact.Prefference);
            ContactsAndCalls.Add(newContact, null);

        }
        public static int MenuInput()
        {
            var isInputed = false;
            var menuInput = 0;


            while (!isInputed)
            {
                Console.Clear();
                Console.WriteLine(MainMenu());

                isInputed = int.TryParse(Console.ReadLine(), out menuInput);
                if (isInputed)
                {
                    break;
                }

                Console.WriteLine("Nesipravan unos, pokušajte ponovno");
                Pause();
            }

            return menuInput;
        }
        public static int MenuInputSub()
        {
            var isInputed = false;
            var menuInput = 0;


            while (!isInputed)
            {
                Console.Clear();
                Console.WriteLine(SubMenu());

                isInputed = int.TryParse(Console.ReadLine(), out menuInput);
                if (isInputed)
                {
                    break;
                }

                Console.WriteLine("Nesipravan unos, pokušajte ponovno");
                Pause();
            }

            return menuInput;
        }
    }
    
}
