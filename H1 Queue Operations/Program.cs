using System;
using System.Linq;
using System.Collections.Generic;

namespace H1_Queue_Operations
{
    class Program
    {
        private static Queue<Person> people = new Queue<Person>();
        static void Main(string[] args)
        {

            bool keepGoing = true;
            while (keepGoing)
            {
                MainMenu();
                switch (Console.ReadKey(false).KeyChar)
                {
                    case '1': //Add a person
                        AddPersonMenu();
                        break;
                    case '2': //Remove a person
                        RemovePersonMenu();
                        break;
                    case '3': //Show the number of people
                        ShowNumberOfPeopleInQueue();
                        break;
                    case '4': //Show min and max people
                        ShowMinAndMax();
                        break;
                    case '5': //Find a person
                        FindAPersonMenu();
                        break;
                    case '6': //Show all people
                        ShowEntireQueue();
                        break;
                    case '7': //Exit
                        List<string> msg = ReadAscii();
                        foreach (string line in msg)
                        {
                            Console.WriteLine(line);
                        }
                        System.Threading.Thread.Sleep(2500);
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static List<string> ReadAscii()
        {
            return System.IO.File.ReadAllLines("coke.coke").ToList();
        }

        /// <summary>
        /// Show the main menu
        /// </summary>
        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("            H1 Queue Operations Menu              ");
            Console.WriteLine("==================================================");
            Console.WriteLine();
            Console.WriteLine("(1) Add a person");
            Console.WriteLine("(2) Remove a person");
            Console.WriteLine("(3) Show the number of people");
            Console.WriteLine("(4) Show min and max people");
            Console.WriteLine("(5) Find a person");
            Console.WriteLine("(6) Print all people");
            Console.WriteLine("(7) Exit");
            Console.WriteLine();
            Console.Write("Enter your choice: "); //Prompt Line
        }

        /// <summary>
        /// Show the add a person menu
        /// </summary>
        static void AddPersonMenu()
        {
            string name;
            byte age;
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("                   Add a person!                  ");
            Console.WriteLine("==================================================");
            Console.WriteLine();
            Console.WriteLine("A person needs a name and an age!");
            Console.WriteLine();
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Age: ");
            try
            {
                age = Convert.ToByte(Console.ReadLine());
                AddPerson(name, age);
            }
            catch (Exception)
            {
                Console.WriteLine("age was not a valid number!");
                AddPersonMenu();
            }
        }

        /// <summary>
        /// Add a person to the queue
        /// </summary>
        /// <param name="name">The name of the person</param>
        /// <param name="age">The age of the person</param>
        static void AddPerson(string name, byte age)
        {
            people.Enqueue(new Person(name, age));
        }

        /// <summary>
        /// Show the remove a person menu
        /// </summary>
        static void RemovePersonMenu()
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("                 Remove a person!                 ");
            Console.WriteLine("==================================================");
            Console.WriteLine();
            Person _tempPerson = people.Peek();
            Console.WriteLine($"{_tempPerson.Name}({_tempPerson.Age}) is now removed from the queue");
            RemoveAPerson();
            System.Threading.Thread.Sleep(1200);
        }

        /// <summary>
        /// Try to remove a person from the queue, fail if no one is in the queue
        /// </summary>
        static void RemoveAPerson()
        {
            try
            {
                people.Dequeue();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("There is no one in the queue!");
                System.Threading.Thread.Sleep(1200);
            }
        }

        /// <summary>
        ///  Prints the number of people in the queue
        /// </summary>
        static void ShowNumberOfPeopleInQueue()
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("           How many people are in line?           ");
            Console.WriteLine("==================================================");
            Console.WriteLine();
            Console.WriteLine($"There is {people.Count} people in queue right now!");
            System.Threading.Thread.Sleep(1200);
        }

        /// <summary>
        /// Print to console, who is first and last in line
        /// </summary>
        static void ShowMinAndMax()
        {
            List<string> _tempPeople = new List<string>();
            foreach (Person person in people)
            {
                _tempPeople.Add(person.Name);
            }

            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("      Who is first and who is last in line?       ");
            Console.WriteLine("==================================================");
            Console.WriteLine();
            Console.WriteLine($"{_tempPeople.First()} is first in queue, and {_tempPeople.Last()} is last in the queue");
            System.Threading.Thread.Sleep(2000);
        }

        /// <summary>
        /// Show the find a person menu
        /// </summary>
        static void FindAPersonMenu()
        {
            string name;
            byte age = 255;
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("                  People finder                   ");
            Console.WriteLine("==================================================");
            Console.WriteLine();
            Console.WriteLine("To find a person, you need to specify a name or an age, or both");
            Console.WriteLine("Simply press enter without entering anything for a field to remain clear");
            Console.WriteLine();
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Age: ");

            try
            {
                age = Convert.ToByte(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Age is not a valid number");
            }
            //If both is entered
            if (!age.Equals(255) && name.Trim() != null || !age.Equals(255) && name.Trim() != "")
            {
                FindAPerson(name.Trim(), age);
            } //Else if only name is entered
            else if (age.Equals(255) && name.Trim() != null || age.Equals(255) && name.Trim() != null)
            {
                FindAPerson(name.Trim());
            } //Else if only age is entered
            else if (!age.Equals(255) && name.Trim() == null || !age.Equals(255) && name.Trim() == "")
            {
                FindAPerson(age);
            } //Else ERROR
            else
            {
                Console.WriteLine("You didn't enter anything? Try again");
                System.Threading.Thread.Sleep(1500);
                FindAPersonMenu();
            }
        }

        /// <summary>
        /// Find a person by their name
        /// </summary>
        /// <param name="name">The persons name</param>
        static void FindAPerson(string name)
        {
            int iterator = 0;
            foreach (Person person in people)
            {
                iterator++;
                if (person.Name.Equals(name))
                {
                    Console.WriteLine($"{name} is number {iterator} in line");
                    return;
                }
            }
        }

        /// <summary>
        /// Find a person by their age
        /// </summary>
        /// <param name="age">The persons age</param>
        static void FindAPerson(byte age)
        {
            int iterator = 0;
            foreach (Person person in people)
            {
                iterator++;
                if (person.Age.Equals(age))
                {
                    Console.WriteLine($"The person with an age of {age} is number {iterator} in line");
                    return;
                }
            }
        }

        /// <summary>
        /// Find a person by name and age
        /// </summary>
        /// <param name="name">The persons name</param>
        /// <param name="age">The persons age</param>
        static void FindAPerson(string name, byte age)
        {
            int iterator = 0;
            foreach (Person person in people)
            {
                iterator++;
                if (person.Name.Equals(name) && person.Age.Equals(age))
                {
                    Console.WriteLine($"{name} ({age}) is number {iterator} in line");
                    return;
                }
            }
        }

        /// <summary>
        /// Print the entire queue to console
        /// </summary>
        static void ShowEntireQueue()
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("                     List queue                   ");
            Console.WriteLine("==================================================");
            Console.WriteLine();
            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Name}({person.Age}) have been in queue for {person.QueueTimeInMinutes} minutes and {person.QueueTimeInSeconds} seconds");
            }
            System.Threading.Thread.Sleep(5000);
        }
    }
}
