using System;
using System.Collections.Generic;

namespace RailWay
{
    class Program
    {
        static int GetIntInput(string msg, int lowerBound, int upperBound)
        {
            int userIntput = 0;                                                          // instiltise the vairble userIntput an assigns it to 0
            bool valid = false;                                                             // instiltise the bool valid to be the while loop variable 

            while (valid == false){                                                         // runs for ever unitill conditions are met
                try{
                    Console.Write(msg);                                                 // out puts the argument msg which will ask the user to input an int
                    userIntput = int.Parse(Console.ReadLine());                             // gets the user input as a string and parses it to an int

                    if (userIntput >= lowerBound && userIntput <= upperBound)               // checks weather the users int is within the correct upper and lower bounds
                        valid = true;                                                       // the int is valid so valid is set to true to end the loop
                    else
                        Console.Write($"invlaid input must be more than {lowerBound} and less than {upperBound}");  // outputs the message to tell the users the bounds needed for the input
                }
                catch{
                    Console.WriteLine("You input was not an int");                          // printed when the input is not an int
                }
            }

            return userIntput;                                                              // returns the int that the user inputed
        }
        static void Display(Dictionary<int, string> cipher, int numberOfTacks){
            Console.WriteLine("\nRails:");
            for(int i = 1; i <= numberOfTacks; i++){
                Console.Write(cipher[i]);
                Console.WriteLine("");
            }
            Console.WriteLine("\nWhole cipher text:");
            for (int i = 1; i <= numberOfTacks; i++)
                Console.Write(cipher[i].ToUpper());
        }
        static Dictionary<int, string> RailFence(string plainText, int trackCount){
            int currentTrack = 1;
            Dictionary<int, string> cipher = new Dictionary<int, string>();
            for (int index = 0; index < plainText.Length; index++)
            {
                char currentchar = plainText[index];
                if(currentchar != ' '){
                    if(cipher.ContainsKey(currentTrack) == true){
                        string old = cipher[currentTrack].ToString();
                        cipher[currentTrack] = (old + currentchar).ToString();
                    }
                    else
                        cipher[currentTrack] = currentchar.ToString();
                    
                    currentTrack = (currentTrack % trackCount) + 1;
                }
            }
            return cipher;
        }
        static void Main(string[] args)
        {
            Console.Write("plaintext: "); string plainText = Console.ReadLine();
            int numberOfTacks = GetIntInput("railfence: ", 2, plainText.Length);

            Display(RailFence(plainText, numberOfTacks), numberOfTacks);
        }
    }
}