using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise
{
    internal class PhoneBook 
    {
        private Dictionary<string, List<Contact>> _contactsByCity;
        private Dictionary<string, List<Contact>> _contactsByName;

        public PhoneBook()
        {
            _contactsByCity = new Dictionary<string, List<Contact>>();
            _contactsByName = new Dictionary<string, List<Contact>>();
        }
        private List<Contact> GetContacts(string city)
        {
            if (_contactsByCity.ContainsKey(city))
                return _contactsByCity[city];
            return null;
        }
        public bool Add(Contact contact)
        {
            bool existsInCity = _contactsByCity.TryGetValue(contact.City, out var cityContacts)
                      && cityContacts.Contains(contact);

            bool existsInName = _contactsByName.TryGetValue(contact.Name, out var nameContacts)
                                && nameContacts.Contains(contact);
            if (!existsInCity && !existsInName)
            {
                AddToContactsByCity(contact);
                AddToContactsByName(contact);
                return true;
            }
            return false;
        }

        private void AddToContactsByCity(Contact contact)
        {
            string key = contact.City;
            List<Contact> contacts;

            if (!_contactsByCity.TryGetValue(key, out contacts))
            {
                contacts = new List<Contact>();
            }

            contacts.Add(contact);
            _contactsByCity[key] = contacts;
        }
        private void AddToContactsByName(Contact contact)
        {
            string key = contact.Name;
            List<Contact> contacts;

            if (!_contactsByName.TryGetValue(key, out contacts))
            {
                contacts = new List<Contact>();
            }

            contacts.Add(contact);
            _contactsByName[key] = contacts;
        }
        public bool Remove(Contact contact)
        {
            bool existsInCity = _contactsByCity.TryGetValue(contact.City, out var cityContacts)
                       && cityContacts.Contains(contact);

            bool existsInName = _contactsByName.TryGetValue(contact.Name, out var nameContacts)
                                && nameContacts.Contains(contact);
            if (!existsInCity || !existsInName)
                return false;

            cityContacts.Remove(contact);
            nameContacts.Remove(contact);
            return true;
        }
       
        public void Clear()
        {
            _contactsByCity.Clear();
            _contactsByName.Clear();
        }
        
        public void PrintByTown()
        {
            foreach (KeyValuePair<string, List<Contact>> pair in _contactsByCity)
            {
                pair.Value.Sort();
                Console.WriteLine($"{pair.Key} :");

                foreach (Contact contact in pair.Value)
                {
                    Console.WriteLine($"   {contact.Name} | {contact.PhoneNumber}");
                }
            }
        }
        public void PrintByTown(string town)
        {
            List<Contact> contacts = GetContacts(town);
            if (contacts != null)
            {
                contacts.Sort();
                Console.WriteLine($"{town} :");
                foreach (Contact contact in contacts)
                {
                    Console.WriteLine($"   {contact.Name} | {contact.PhoneNumber}");
                }
            }
            else
            {
                Console.WriteLine($"town: {town} was not found");
            }
        }
        public List<Contact> Find(string name)
        {
            List<Contact> contacts;
            
            if ( _contactsByName.TryGetValue(name, out contacts))
                return contacts;
            return null;
        }
        public List<Contact> Find(string name, string town)
        {
            List<Contact> contacts;

            if (_contactsByCity.TryGetValue(town, out contacts))
            {
                return contacts.Where(c => c.Name == name).ToList();
            }
            return null;
        }

    }
}
