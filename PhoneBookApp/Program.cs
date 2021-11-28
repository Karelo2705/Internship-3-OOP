using System;
using System.Collections.Generic;

namespace PhoneBookApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var newDictionary = new Dictionary<Contact, List<string>>()
            {

            };
        }
    }
    class Contact
    {
        public string NameAndSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string Prefference { get; set; }
    }
    class OutgoingCall
    {
        public DateTime CallSetupTime { get; set; }
        public string CallStatus { get; set; }

    }

}
