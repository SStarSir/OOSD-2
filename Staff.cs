using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    

        public class Staff
        {



            private int id;
            private string firstName;
            private string surname;
            private string address1;
            private string address2;
            private string category;
            private double baselocLat;
            private double baselocLon;


            public int ID
            {
                get { return id; }
                set { id = value; }
            }
            public string Firstname
            {
                get { return firstName; }
                set { firstName = value; }
            }

            public string Surname
            {
                get { return surname; }
                set { surname = value; }
            }

            public string Address1
            {
                get { return address1; }
                set { address1 = value; }
            }
            public string Address2
            {
                get { return address2; }
                set { address2 = value; }
            }

            public string Category
            {
                get { return category; }
                set { category = value; }
            }

            public double Location1
            {
                get { return baselocLat; }
                set { baselocLat = value; }
            }
            public double Location2
            {
                get { return baselocLon; }
                set { baselocLon = value; }
            }

            public Staff(int id, string firstName, string surname, string address1, string address2, string category, double locLat, double locLon)
            {}    // class constructor

            public Staff()
            { }    // empty constructor

        }

    }

