using System;
using System.Collections.Generic;
using System.Text;
using System.IO; // added for data handling

namespace BusinessLayer
{

    public static class visitTypes
    {
        public const int assessment = 0;
        public const int medication = 1;
        public const int bath = 2;
        public const int meal = 3;

    }
    public class HealthFacade
    {
        int clientcounter = 0; //used to store how many times clients were added
        int visitcounter = 0;
        int staffcounter = 0;

        // string staffCat = "";
        bool staffChecker = false;
        bool clientChecker = false;
        bool loadState = false;
        string readStaffText = "";
        string readClientText = "";
        string readVisitText = "";

        public string clientResult = "";

        private List<Client> clientlist = new List<Client>(); //client list
        private List<Staff> stafflist = new List<Staff>(); //staff list
        private List<Visit> visitlist = new List<Visit>(); //visit list




        public Boolean addStaff(int id, string firstName, string surname, string address1, string address2, string category, double baseLocLat, double baseLocLon)
        {
            /*
             * Add your implementation here!
             */
            loadState = false; // when i press addStaff, set loadState to false to allow the adding of new staff after load

            Staff s = new Staff();

            s.ID = id;
            s.Firstname = firstName;
            s.Surname = surname;
            s.Address1 = address1;
            s.Address2 = address2;
            s.Category = category;
            s.Location1 = baseLocLat;
            s.Location2 = baseLocLon;

            stafflist.Add(s);

            
            staffChecker = true;
            staffcounter = +staffcounter;

            return staffChecker; // had to change this to true, otherwise it would print the void list
        }

        public Boolean addClient(int id, string firstName, string surname, string address1, string address2, double locLat, double locLon)
        {
            loadState = false;

            Client c = new Client();

            // the parameters in the addclient() will be assigned to the value of the class
          

            c.ID = id;
            c.Firstname = firstName;
            c.Surname = surname;
            c.Address1 = address1;
            c.Address2 = address2;
            c.Location1 = locLat;
            c.Location2 = locLon;

            clientlist.Add(c);

            clientChecker = true;
            clientcounter = +clientcounter;

            return clientChecker;
            
        }

        public Boolean addVisit(int[] staff, int patient, int type, string dateTime)
        {

            //loadState = false;

            VisitFactory factory = new VisitFactory(); //Create new factory
            Visit v = factory.BuildVisit(); //Create new Factory product

            






            v.Staff = staff;
            v.Patient = patient;
            v.Type = type;
            v.DateTime = dateTime;

            if ((clientChecker == true) & (staffChecker == true))

            {



               

                if ((type >= 0) & (type <= 3))

                {

                    if ((patient >= 0) & (patient <= 3))

                    {

                        foreach (Staff s in stafflist)
                        {
                            if (type == 3 & s.Category != "Care Worker") //i wrote only this because it was all it was needed for the visit lists, but it can be easily expanded to cover each visit

                            {

                                throw new Exception("\n Error: Patient " + patient + " @" + dateTime + " - visit not added because staff category " + s.Category + " is invalid \n");

                            }

                            else
                                visitlist.Add(v);

                            return true; //this boolean is necessary to show visit added sentence

                        }
                    }

                    else

                        throw new Exception("Error: Patient " + patient + " @" + dateTime + " - visit not added because patient " + patient + " is invalid \n");




                }

                else

                    throw new Exception("\n Error: Patient " + patient + " @" + dateTime + " - visit not added because type " + type + " is invalid \n"); //(Patient " + patient + " @" + dateTime + ")\n");

                


            }

            else

            { throw new Exception("\n You need to add staff and clients first \n"); }


            return false;//If no errors thrown, assum OK
        }


        public String getStaffList()
        {
            {
                String result = "Staff list \n";

                if (loadState == true)

                {
                    result = readStaffText;


                    return result;
                }



                else

                {

                    foreach (Staff s in stafflist)
                    {

                        result += s.ID.ToString() + " " + s.Firstname.ToString() + " " + s.Surname.ToString() + ", " + s.Address1.ToString() + ", " + s.Address2.ToString() + ", " + s.Category.ToString() + ", " + s.Location1.ToString() + ", " + s.Location2.ToString() + "\n";

                        // i need += in order to print all the values, otherwise it will overwrite and print only the last one




                    }


                    visitcounter = +visitcounter;


                    return result;
                }
            }

        }

            public String getClientList()
            {



                String result = "Client list \n";


                if (loadState == true)

                {
                    result = readClientText;


                    return result;
                }



                else

                {

                    foreach (Client c in clientlist)
                    {



                        result += c.ID.ToString() + " " + c.Firstname.ToString() + " " + c.Surname.ToString() + ", " + c.Address1.ToString() + ", " + c.Address2.ToString() + ", " + c.Location1.ToString() + ", " + c.Location2.ToString() + "\n"; // i need += in order to print all the values, otherwise it will overwrite and print only the last one




                    }


                    return result;
                }
            }

        public String getVisitList()
        {

            String result = "\n Visit list \n";



            {

                if (loadState == true)

                {
                    result = readVisitText;


                    return result;
                }

                else

                    foreach (Visit v in visitlist)
                    {



                        result += " Patient " + v.Patient + " @" + v.DateTime + " - visit added \n"; // i need += in order to print all the values, otherwise it will overwrite and print only the last one




                    }



                return result;
            }
        }

                    public void clear()
                    {

                        
                        stafflist.Clear();
                        clientlist.Clear();
                        visitlist.Clear();
            staffChecker = false;
            clientChecker = false;
            visitcounter = 0;
            staffcounter = 0;
            clientcounter = 0;

                    }


                    public Boolean load()
                    {

                        loadState = true;

                        FileInfo filestaff = new FileInfo("stafflist.txt");
                        FileInfo fileclient = new FileInfo("clientlist.txt");
                        FileInfo filevisit = new FileInfo("visitlist.txt");//nel peggiore dei casi sposta nel business layer
                       


                     

                            readStaffText = System.IO.File.ReadAllText(@"stafflist.txt");

                            readClientText = System.IO.File.ReadAllText(@"clientlist.txt");

                            readVisitText = System.IO.File.ReadAllText(@"visitlist.txt");

                        


                        


                        return false;
                    }

                    public bool save()
                    {

            SaveSingleton s = SaveSingleton.Instance;

            s.SaveAll();

            
             
            FileInfo filestaff = new FileInfo("stafflist.txt");
                        FileInfo fileclient = new FileInfo("clientlist.txt");
                        FileInfo filevisit = new FileInfo("visitlist.txt");//nel peggiore dei casi sposta nel business layer

            




        
            

                      string pathstaff = @"stafflist.txt";
                        string pathclient = @"clientlist.txt";
                        string pathvisit = @"visitlist.txt";
            
            
             
                       string staffText = getStaffList(); //takes the list from the parameter passed from getstafflist
                        string clientText = getClientList();
                        string visitText = getVisitList();

            
            
            System.IO.File.WriteAllText(pathstaff, staffText);
                        System.IO.File.WriteAllText(pathclient, clientText);
                        System.IO.File.WriteAllText(pathvisit, visitText);

            
    
                       

   
                        return true;
                    }

                }
            }
       
