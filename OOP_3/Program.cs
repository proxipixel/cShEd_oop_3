using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace OOP3
{
    public class Program
    {
        // serialization method
        public static void serIn(List<Employee> aList, string aPath)
        {
            XmlSerializer serOb = new XmlSerializer(aList.GetType(), new Type[] { typeof(List<Fixed>), typeof(List<Hourly>) });
            using (StreamWriter aStream = new StreamWriter(new FileStream(aPath, (File.Exists(aPath) ? FileMode.Append : FileMode.Create))))
            {
                serOb.Serialize(aStream, aList);
            }
        }
        // deserialization method
        public static List<Employee> serOut(string aPath)
        {
            List<Employee> aList = new List<Employee>();
            XmlSerializer deSerOb = new XmlSerializer(aList.GetType(), new Type[] { typeof(List<Fixed>), typeof(List<Hourly>) });
            using (StreamReader aStream = new StreamReader(new FileStream(aPath, FileMode.Open)))
            {
                return aList = (List<Employee>)deSerOb.Deserialize(aStream);
            }
        }
        static void Main()
        {
            // variables declaration block
            int userChoice;
            string aName;
            List<Employee> empList = new List<Employee>();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\XML_srlztn.txt";

            Console.Write("\nUse a following menu to manage employees.");
            do
            {
                // main menu
                Console.Write("\n\n   Main menu:\n\n[1] Create new record for an employee of 'Fixed rate' type\n[2] Create new record for an employee of 'Hourly rate'\n[3] Manage records of existing employees\n(type an option's number and confirm choice by pressing 'Enter'): ");
                while (!Int32.TryParse(Console.ReadLine(), out userChoice) || (userChoice < 1 | userChoice > 3))
                {
                    Console.Write("\nWhoops ! No such option within the menu ! Please pick a valid one: ");
                }
                // prevention of 'existing employees' menu item usege in case the list is empty 
                if (userChoice == 3 && empList.Count == 0)
                {
                    Console.Write("\nThere's no employee created yet !\nPlease create at least one empoyee to use 'Manage existing employees' menu item !");
                    continue;
                }

                switch (userChoice)
                {
                    case 1: //'Fixed rate' case
                        //adding an eployee's name
                        Console.Write("\nEnter an employee's name: ");
                        while (String.IsNullOrWhiteSpace(aName = Console.ReadLine()))
                        {
                            Console.Write("\nEmployee's name mustn't be empty ! Please enter a valid name: ");
                        }
                        // new 'fixed type employee' instantiation
                        empList.Add(new Fixed { Name = aName });
                        Console.Write("\nNew 'Fixed rate' employee successfully created !");

                        break;

                    case 2: //'Hourly rate' case
                            //adding an eployee's name
                        Console.Write("\nEnter an employee's name: ");
                        while (String.IsNullOrWhiteSpace(aName = Console.ReadLine()))
                        {
                            Console.Write("\nEmployee's name mustn't be empty ! Please enter a valid name: ");
                        }
                        //adding an eployee's working hours
                        Console.Write("\nEnter an employee's working hours: ");
                        while (!Int32.TryParse(Console.ReadLine(), out userChoice))
                        {
                            Console.Write("\nHours amount mustn't be empty ! Please enter a valid amount: ");
                        }
                        // new 'hourly type employee' instantiation
                        empList.Add(new Hourly { Name = aName, Hours = userChoice });
                        Console.Write("\nNew 'Hourly rate' employee successfully created !");

                        break;

                    case 3:
                        // sub menu to manage existing employees
                        Console.Write("\n   Manage existing employees:\n\n[1] Sort a list of employees\n[2] Display summary for all existing employees\n[3] Display specific number of employees from the beginning of the list\n[4] Display specific number of employees from the end of the list\n[5] Export employees' data into an XML file\n[6] Import employees' data from an XML file\n[7] Check an exported XML file's status\n(type an option's number and confirm choice by pressing 'Enter'): ");
                        while (!Int32.TryParse(Console.ReadLine(), out userChoice) || (userChoice < 1 | userChoice > 7))
                        {
                            Console.Write("\nWhoops ! No such option within the menu ! Please pick a valid one: ");
                        }

                        switch (userChoice)
                        {
                            case 1:

                                break;

                            case 2:
                                Console.Write("\n\tEmployees list\n\nID\tNAME\t\tSALARY\n");
                                for (int i = 0; i < empList.Count; i++)
                                {
                                    empList[i].SalCalc();
                                    Console.Write("\n{0}\t{1}\t\t{2}", empList[i].Id, empList[i].Name, empList[i].Salary);
                                }

                                break;

                            case 3:

                                break;

                            case 4:

                                break;

                            case 5: // export (serialization) a List<T> containing emloyees into an XML file

                                if (File.Exists(path))
                                    File.Delete(path);
                                serIn(empList, path);
                                Console.Write("\nEmployees list successfuly exported into a file into your 'Desktop' directory !");

                                break;

                            case 6: // import (deserialization) of an XML containing emloyees

                                if (!File.Exists(path))
                                {
                                    Console.Write("\nThere's no file to import from ! You need to export an employees list first .");
                                    continue;
                                }
                                List<Employee> deserList;
                                deserList = serOut(path);
                                Console.Write("\nFollowing employees successfuly imported from a file:\n\nID\tNAME\t\tSALARY\n");
                                foreach (Employee anEmployee in deserList)
                                {
                                    Console.Write("\n{0}\t{1}\t\t{2}", anEmployee.Id, anEmployee.Name, anEmployee.Salary);
                                }

                                break;

                            case 7:

                                break;

                        }

                        break;
                }

                Console.Write("\n\nPress any key to continue or 'Ctrl+c' combination to close the program");
                Console.ReadKey(true);
            }
            while (true);
        }
    }
}
