using System;

namespace Random_Name_Generator
{
     class Program
     {
          static void Main()
          {
               //Variables
               string input;
               int numOfNames;
               string tempName;
               string again = "n";
               string sameListRepeat = "n";
               string runAgain = "y";

               //Output a header
               Console.WriteLine("Random Name Generator\n");

               //Get the number of names to be randomized from the user
               Console.Write("How many names would you like to randomize? ");
               input = Console.ReadLine();
               numOfNames = int.Parse(input);
               Console.WriteLine();

               //Dynamically allocate an array for the name list
               string[] nameList = new string[numOfNames];
               string[] nameListMaster = new string[numOfNames];

               //Get the names from the user
               for (int i = 0; i < numOfNames; i++)
               {
                    Console.Write("Input name # " + (i + 1) + ": ");
                    tempName = Console.ReadLine();
                    nameList[i] = tempName;
               }

               //Make a master copy of the name list for repeating the program
               Array.Copy(nameList, nameListMaster, numOfNames);

               //Transition message for user
               Console.WriteLine("\nName list complete.");

               //Initialize the random number generator
               Random selector = new Random();

               do
               {
                    //Reinitialize the name list array and variables
                    Array.Copy(nameListMaster, nameList, numOfNames);
                    int namesGenerated = 0;
                    sameListRepeat = "n";

                    //Generate random names until the user wants to quit
                    do
                    {
                         int result;

                         //Call the random number generator
                         result = selector.Next(0, (numOfNames - namesGenerated));

                         //Output the result
                         Console.WriteLine("\nRandom Name #" + (namesGenerated + 1) + ": " + nameList[result]);

                         //Delete the name generated from the array.
                         //Move the last name in the array to the position of the name
                         //that was selected this iteration (at index result).
                         nameList[result] = nameList[(numOfNames - 1) - namesGenerated];
                         namesGenerated++;

                         //Ask the user if they want to generate another random name
                         Console.Write("Generate another name? (y/n): ");
                         again = Console.ReadLine();

                    } while (String.Equals(again, runAgain) && (numOfNames != namesGenerated));

                    //If the user has generated all the names available, output a message.
                    if (String.Equals(again, runAgain) && numOfNames == namesGenerated)
                    {
                         Console.WriteLine("\nYou have used up all the names in the list!");
                         Console.Write("Would you like to restart with the same set of names? (y/n): ");
                         sameListRepeat = Console.ReadLine();
                    }

               } while (String.Equals(sameListRepeat, runAgain));

               //Gracefully terminate the program.
               Console.WriteLine();
               Console.WriteLine("Thanks for using the program! Press any key to quit.");
               Console.Read();
          }
     }
}
