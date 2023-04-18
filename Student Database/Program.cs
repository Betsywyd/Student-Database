using System;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Student_Database
{
    public class Program
    {
        static void Main()
        {
            string[] nameArr = { "Andrew", "Charlie", "Jonathon", "Gavin", "Mia", "Adam", "Mary", "Liam", "Enthon" };
            string[] HometownArr = { "Detroit", "Grand Rapids", "Farmington Hill", "Ann Arbor", "Canton", "Rochester", "Pontiac", "Waterford", "Madison Heights" };
            string[] FavoritefoodArr = { "Ice Cream", "Chocolate", "Cheese Bar", "Pasta", "Steak", "Noodles", "Cheese Bread", "Fries", "Pizza" };
            Console.WriteLine("Welcomt to students database system:");
            bool goOn = true;
            do { 
            if (AskNameList() == true)
            {
                ShowNameList(nameArr);
                ByNumOrName(nameArr, HometownArr, FavoritefoodArr);
               
            }
            else
            {
                ByNumOrName(nameArr, HometownArr, FavoritefoodArr);
                   
            }
                goOn = Continue();
            }while (goOn==true);

            }

       
        public static bool Continue()
        {
            Console.WriteLine("Would you like to learn about another student? Enter \"y\" or \"n\":  ");
            string answer = Console.ReadLine().ToLower().Trim();
            if (answer == "y")
            {
                return true;
            }
            else if (answer == "n")
            {
                Console.WriteLine("Thanks!");
                return false;
            }
            else
            {

                Console.WriteLine("Enter wrong.Let's try again.");
                return Continue();
            }
        }
      
      
        public static int PickNum(string[] arr)
        {
            Console.WriteLine($"Which student would you like to learn more about? Enter a number 1-{arr.Length}:");
            int num = int.Parse(Console.ReadLine());
            if (num <= 0 || num > arr.Length) 
            {
                Console.WriteLine("Stdent number is out of range.Let's try again.");
                return PickNum(arr);
            }
            else
            {
                return num;
            }


        }

        public static void ByNumOrName(string[] arr1, string[] arr2, string[] arr3)
        {
            Console.WriteLine("would like to pick though number or name,enter \"num\" or \"name\"?");
            string enter=Console.ReadLine().ToLower().Trim();
            if (enter == "num")
            {

                PickCategory(arr1, arr2, arr3, PickNum(arr1));
            }
            else if (enter == "name")
            {
                PickCategory(arr1, arr2, arr3, FindNameIndex(arr1)+1);
            }
            else
            {
                Console.WriteLine("I can't understand,Let's try again.");
                ByNumOrName(arr1, arr2, arr3);
            }

        }


        public static int FindNameIndex(string[] arr)
        {
            Console.WriteLine($"Which student would you like to learn more about? Enter a student name: ");
            string name = Console.ReadLine().ToLower().Trim();
          for(int i=0; i<arr.Length; i++)
            {
                if (arr[i].ToLower().Trim() == name)
                {
                    return i;
                }
            }
          return -1;
        }

        

        public static void PickCategory(string[] arr1, string[] arr2, string[] arr3 ,int num)
        {
            if(num>=1) { 
            Console.Write($"Student {num} is {arr1[num - 1]}.");
            bool s = true;
            do
            {
                Console.WriteLine("What would you like to know? Enter \"hometown\" or \"favorite food\"");
                string enter = Console.ReadLine().ToLower().Trim();

                if (enter == "hometown"|| enter == "town" || enter == "home")
                {
                    Console.WriteLine($"{arr1[num - 1]} is from {arr2[num - 1]}. ");
                    s= false;
                }
                else if (enter == "favorite food"|| enter == "favorite" || enter == "food")
                {
                    Console.WriteLine($"{arr1[num - 1]}'s favorite food is {arr3[num - 1]}. ");
                    s = false;
                }
                else
                {
                    Console.WriteLine("That category does not exist.,Let's try again.");
                    s = true;
                    continue;

                }
            } while (s == true);
        }
            else
            {
                Console.WriteLine("This student isn't in this class,let's try again!");
                PickCategory(arr1, arr2, arr3, FindNameIndex(arr1) + 1);

            }

      }


        public static bool AskNameList()
        {
            Console.WriteLine("Do you want have the name list of student? \"y\" or \"n\":");
            string anwer=Console.ReadLine().ToLower().Trim();
            if(anwer == "y")
            {
             return true;
            }
            else if(anwer == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("I can't understand you.,Let's try again.");
                return AskNameList();
            }

        }
        public static void ShowNameList(string[] arr)
        {
           for(int i=0; i<arr.Length; i++)
            {
                Console.WriteLine($"{i+1} : {arr[i]}");
            }
        }


    }

}

