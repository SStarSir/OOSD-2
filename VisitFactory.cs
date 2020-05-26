using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    class VisitFactory
    {

        
        
        // Factory that creates instances of Visit objects
          
        public Visit BuildVisit()
        {
            return new Visit();//Create new visit
        }
    }

}

