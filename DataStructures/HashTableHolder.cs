using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class HashTableHolder
    {
        private string key;

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private Person person;

        public Person Person
        {
            get { return person; }
            set { person = value; }
        }

        public HashTableHolder(string key, Person value)
        {
            this.key = key;
            this.person = value;
        }
    }
}
