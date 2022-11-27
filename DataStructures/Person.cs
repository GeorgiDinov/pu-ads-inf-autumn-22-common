using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class Person
    {

        private string pin;//ЕГН

        public string Pin
        {
            get { return pin; }
            set { pin = value; }
        }

        private string fullName;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }


        public Person(string pin, string fullName)
        {
            this.pin = pin;
            this.fullName = fullName;
        }

        public override string ToString()
        {
            return "Person{" + "PIN=" + this.pin + ", FullName=" + this.fullName + "}";
        }
    }
}
