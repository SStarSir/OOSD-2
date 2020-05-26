using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    class Visit
    {

        private int visitNo;
        private int[] requiredStaff;
        private int patient;
        private int type;
        private int duration;
        private string dateTime;

        public int VisitNo   // property to obtain number of visit
        {
            get { return visitNo; }
            set { visitNo = value; }
        }

        public int[] Staff //property to obtain number of staff required
        {
            get { return requiredStaff; }
            set { requiredStaff = value; }
        }
        public int Patient //property to obtain patient number
        {
            get { return patient; }
            set { patient = value; }
        }

        public int Type //property to obtain visit type
        {
            get { return type; }
            set { type = value; }
        }

        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public string DateTime //property to obtain date and time
        {
            get { return dateTime; }
            set { dateTime = value; }
        }



        public Visit(int staff, int patient, int type, string dateTime)
        { }    // class constructor

        public Visit()
        { }    // empty constructor



    }

}


