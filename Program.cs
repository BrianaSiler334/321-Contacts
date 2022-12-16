

namespace _321_Contact {
    internal class Program {

        struct Contact {
            public string firstName;
            public string lastName;
            public string address;
            public string city;
            public string state;
            public int zipcode;
            public string title;
        }//end struct
        static void Main(string[] args) {


        int userSelection = -1;

            while (userSelection != 3) {
                userSelection = Menu();

                switch (userSelection) {
                    case 1: { SearchName(); break; }
                    case 2: { AddMode(); break; }

                    default: { Console.WriteLine(""); break; }
                }//end menu selection switch statement
                if (userSelection == 3) {
                    Input("Thank you for using my program");
                } //end if

            }//end while

        } //end main


       
        static string Input(string prompt) {
            Console.Write(prompt + " : ");
            return Console.ReadLine();
        }//end input

        static int Menu() {

            string path = @"C:\Users\BSiler\Downloads\contacts.dat";
            string data = "";
            string records = "";
            string userInput = "";
            string name = "";
            bool parsing = false;
            int userSelection;
            string test = "";

            


            do {
                Console.Clear();
            //call header method
                                        Header("--------------------Welcome to the Three Two One Contact Program--------------------");              
                Console.WriteLine("\nPlease make a selection from the menu");
                Console.WriteLine("\n1. Search Mode");
                Console.WriteLine("\n2. Add Mode");
                Console.WriteLine("\n3. Exit the Program.");

                userInput = Input("\n Program Selector");
                parsing = int.TryParse(userInput, out userSelection);
            } while (parsing == false || userSelection < 0 || userSelection > 3);
            

            return userSelection;
        }//end menu

        static void SearchName() { //searches for a name in the file
            Console.Clear();
            string path = @"C:\Users\BSiler\Downloads\contacts.dat";
            string data = "";
           // string records = "";
            string userInput = "";
            string name = "";
            bool parsing = false;
            int userSelection;



            StreamReader sr = new StreamReader(path);

            while (sr.EndOfStream == false) {
                data = sr.ReadLine();
            }//End whileloop that reads data by the line
            sr.Close();


            
            //split record contact by record separator char
            string[] recordsArray = data.Split((char)30);

            // create an array of structs
           Contact[] contacts = new Contact[recordsArray.Length];

            
          


            // loop through the records and split them into fields
            for (int index = 0; index < contacts.Length; index++) {

              
                //get a record
                string currentRecord = recordsArray[index];

                //split field of record with a unit separator char
                string[] fields = currentRecord.Split((char)31);

                // assign the fields to the struct
                contacts[index].firstName = fields[0];
                contacts[index].lastName = fields[1];
                contacts[index].address = fields[2];
                contacts[index].city = fields[3];
                contacts[index].state = fields[4];
                contacts[index].zipcode = int.Parse(fields[5]);
                contacts[index].title = fields[6];
            }//end for

            //  do while loop to ask user for name which includes partial matches, ignoring case and ask if the user wants to search again
            do {

                name = Input("Search Name");



                for (int i = 0; i < contacts.Length; i++) {
                    Contact currentContact = contacts[i];
                    if (currentContact.firstName.ToLower().Contains(name.ToLower()) || currentContact.lastName.ToLower().Contains(name.ToLower())) {
                        Console.WriteLine($"Name:    {currentContact.title}.{currentContact.firstName} {currentContact.lastName}");
                        Console.WriteLine($"Address: {currentContact.address} ");
                        Console.WriteLine($"         {currentContact.city} {currentContact.state},{currentContact.zipcode}");
                        

                        Console.WriteLine("");
                    }//end if


                }//end for loop

                // ask the user if they would like to search again
                Console.WriteLine("Would you like to search again? (y/n)");
                userInput = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("");

                if (userInput.ToLower() == "y") {
                    parsing = true;
                }//end if
                else {
                    parsing = false;
                }//end else
            } while (parsing == true);
            
        }//end function



        static void AddMode() {
            Console.Clear();
            string path = @"C:\Users\BSiler\Downloads\contacts.dat";
            string userInput = "";
            //string name = "";
            bool parsing = false;
            

            StreamWriter outfile = new StreamWriter(@"C:\Users\BSiler\Downloads\contacts.dat", true);



            do {
                outfile.Write((char)30);
                outfile.Write(Input("\nEnter first name"));
                outfile.Write((char)31);
                outfile.Write(Input("\nEnter last name"));
                outfile.Write((char)31);
                outfile.Write(Input("\nEnter your address"));
                outfile.Write((char)31);
                outfile.Write(Input("\nEnter your city"));
                outfile.Write((char)31);
                outfile.Write(Input("\nEnter your state"));
                outfile.Write((char)31);
                outfile.Write(Input("\nEnter your zipcode"));
                outfile.Write((char)31);
                outfile.Write(Input("\nEnter your title"));

                
                // ask the user if they would like to add again
                Console.WriteLine("Would you like to add another contact? (y/n)");
                userInput = Console.ReadLine();
                Console.Clear();
                Console.Clear();
                Console.WriteLine("");




             } while (parsing == true);
            


                outfile.Close();
            
        }//end function

        public static void Header(string title, string subtitle = "") {
            Console.Clear();
            Console.WriteLine();
            int windowWidth = 90 - 2;
            string titleContent = String.Format("\t    ║{0," + ((windowWidth / 2) + (title.Length / 2)) + "}{1," + (windowWidth - (windowWidth / 2) - (title.Length / 2) + 1) + "}", title, "║");
            string subtitleContent = String.Format("\t    ║{0," + ((windowWidth / 2) + (subtitle.Length / 2)) + "}{1," + (windowWidth - (windowWidth / 2) - (subtitle.Length / 2) + 1) + "}", subtitle, "║");



            Console.WriteLine("\t    ╔════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine(titleContent);
            if (!string.IsNullOrEmpty(subtitle)) {
                Console.WriteLine(subtitleContent);
            }
            Console.WriteLine("\t    ╚════════════════════════════════════════════════════════════════════════════════════════╝");
        }

    }//end class
    }//end namespace