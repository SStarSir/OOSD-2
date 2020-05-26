using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;

using System.Linq;

using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Client
    {

        


        private int id;
        private string firstName;
        private string surname;
        private string address1;
        private string address2;
        private double locLat;
        private double locLon;

        public int ID //
        {
            get { return id; }
            set { id = value; }
        }
        public string Firstname //
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string Surname //
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Address1 //
        {
            get { return address1; }
            set { address1 = value; }
        }
        public string Address2 //
        {
            get { return address2; }
            set { address2 = value; }
        }

        public double Location1 //
        {
            get { return locLat; }
            set { locLat = value; }
        }
        public double Location2 //
        {
            get { return locLon; }
            set { locLon = value; }
        }

        public Client(int id, string firstName, string surname, string address1, string address2, double locLat, double locLon)
        { }    // class constructor

        public Client()
        { }    // empty constructor
    }

}

    

