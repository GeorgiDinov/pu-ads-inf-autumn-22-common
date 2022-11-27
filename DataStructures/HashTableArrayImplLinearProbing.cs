using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    // Note in this implementation we do not check for duplicate keys
    // and we use pretty primitive hashing function
    internal class HashTableArrayImplLinearProbing
    {

        private int size;
        private HashTableHolder[] hashTable;

        public HashTableArrayImplLinearProbing()
        {
            size = 0;
            hashTable = new HashTableHolder[10];
        }

        public void Put(string key, Person person)
        {
            int hashedKey = HashTheKey(key);
            if (IsOccupied(hashedKey))
            {
                int stopIndex = hashedKey;
                hashedKey = PrepareForLinearProbing(hashedKey);
                while (hashedKey != stopIndex && IsOccupied(hashedKey))
                {
                    hashedKey = IncrementAndModKey(hashedKey);
                }
            }
            if (IsOccupied(hashedKey))
            {
                Console.WriteLine("There is no space available!");
            }
            else
            {
                hashTable[hashedKey] = new HashTableHolder(key, person);
                size++;
            }
        }

        public Person Remove(string key)
        {
            int hashedKey = FindTheKey(key);
            if (hashedKey == -1)
            {
                return null;
            }
            Person person = hashTable[hashedKey].Person;
            hashTable[hashedKey] = null;
            HashTableHolder[] tempTable = hashTable;
            hashTable = new HashTableHolder[tempTable.Length];
            size = 0;
            foreach (HashTableHolder holder in tempTable)
            {
                if (holder != null)
                {
                    Put(holder.Key, holder.Person);
                }
            }
            return person;
        }

        public Person Get(string key)
        {
            int hashedKey = FindTheKey(key);
            if (hashedKey == -1)
            {
                return null;
            }
            return hashTable[hashedKey].Person;
        }

        public int Size()
        {
            return size;
        }

        public double GetLoadFactor()
        {
            return (double)size / hashTable.Length;
        }

        public void PrintHashTable()
        {
            for (int i = 0; i < hashTable.Length; i++)
            {
                Console.WriteLine(hashTable[i] != null
                        ? "Position " + i + ": " + hashTable[i].Person
                        : "Position " + i + ": available...");
            }
        }

        private int FindTheKey(string key)
        {
            int hashedKey = HashTheKey(key);
            if (IsOccupied(hashedKey) && Matches(hashedKey, key))
            {
                return hashedKey;
            }
            int stopIndex = hashedKey;
            hashedKey = PrepareForLinearProbing(hashedKey);
            while (hashedKey != stopIndex && IsOccupied(hashedKey) && !Matches(hashedKey, key))
            {
                hashedKey = IncrementAndModKey(hashedKey);
            }
            if (IsOccupied(hashedKey) && Matches(hashedKey, key))
            {
                return hashedKey;
            }
            else
            {
                return -1;
            }
        }

        private int HashTheKey(string key)
        {
            return key.Length % hashTable.Length;
        }

        private bool IsOccupied(int index)
        {
            return hashTable[index] != null;
        }

        private bool Matches(int hashedKey, string key)
        {
            return hashTable[hashedKey].Key.Equals(key);
        }

        private int PrepareForLinearProbing(int hashedKey)
        {
            if (hashedKey == hashTable.Length - 1)
            {
                return 0;
            }
            else
            {
                return hashedKey + 1;
            }
        }

        private int IncrementAndModKey(int hashedKey)
        {
            return (hashedKey + 1) % hashTable.Length;
        }

    }
}
