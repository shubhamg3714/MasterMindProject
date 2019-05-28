﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************** Let's play Master-Mind **************\n");

            //string name = GetPlayerName();

            do
            {
                PlayGame();

                Console.Write("\nWould you like to play again (Y/N)? ");
            }
            while (Console.ReadLine().ToUpper() == "Y");
        }

        private static void PlayGame()
        {
            int numberCount = 4;// GetRandomNumberCount();
           
            int[] PCArray = GetRandomNumbers(numberCount);
            Console.WriteLine("A {0}-digit number has been chosen. Each possible digit may be the number 1 to 6.\n", numberCount);

          
            bool won = false;
            for (int allowedAttempts = 10; allowedAttempts > 0 && !won; allowedAttempts--)
            {
                Console.WriteLine("\nEnter your guess ({0} guesses remaining)", allowedAttempts);

                int[] userArray = GetUserGuess(numberCount);

                if (GetHitCount(PCArray, userArray) == numberCount)
                    won = true;
            }

            if (won)
                Console.WriteLine("Hurray...You won the Game!!!");
            else
                Console.WriteLine("You couldn't guess the right number. You Lost the Game!!!");

            Console.Write("The correct number is: ");
            for (int j = 0; j < numberCount; j++)
                Console.Write(PCArray[j] + " ");
            Console.WriteLine();
        }

        //private static string GetPlayerName()
        //{
        //    Console.Write("Please enter your name: ");
        //    string name = Console.ReadLine();
        //    Console.WriteLine("Welcome, {0}. Have fun!!\n", name);
        //    return name;
        //}

        //public static int GetRandomNumberCount()
        //{
        //    int number;

        //    Console.Write("How many numbers would you like to use in playing the game (4-10)? ");
        //    while (!int.TryParse(Console.ReadLine(), out number) || number < 4 || number > 10)
        //        Console.WriteLine("You must pick a number between 4 and 10. Choose again.");

        //    return number;
        //}
        

        public static int[] GetRandomNumbers(int PCSize)
        {
            int eachNumber;
            int[] randomNumber = new int[PCSize];
            Random rnd = new Random();
            string temp = string.Empty;
           
            for (int i = 0; i < PCSize; i++)
            {
                eachNumber = rnd.Next(1, 6);
                randomNumber[i] = eachNumber;
                temp = temp + eachNumber;               
            }

            Console.Write("PC number: "  + temp); //to display the randomly generated Number
            Console.WriteLine();
            return randomNumber;
        }

        public static int[] GetUserGuess(int userSize)
        {
            int number = 0;
            int[] userGuess = new int[userSize];
            
            GetNum:
            number = Convert.ToInt32(Console.ReadLine());
            string temp = Convert.ToString(number);
            if(temp.Length > 4)
            {
                Console.WriteLine("Invalid number. Please enter a 4 digit number.");
                goto GetNum;
            }               

            char[] userguess = temp.ToCharArray();
            for (int i = 0; i < userSize; i++)
            {
                userGuess[i] = Convert.ToInt32(userguess[i].ToString());
                if (userGuess[i] >6)
                {
                    Console.WriteLine("Invalid number. Please enter a number with each digit ranging from 1 to 6.");
                    goto GetNum;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Your guess: " + temp);          
            
            return userGuess;
        }

        public static int GetHitCount(int[] PCArray, int[] userArray)
        {
            int hits = 0;

            for (int i = 0; i < PCArray.Length; i++)
            {
                if (PCArray[i] == userArray[i])
                    hits++;
            }

            Console.WriteLine("Result: {0} , -{1} ", hits, PCArray.Length - hits);
            return hits;
        }
    }
}
