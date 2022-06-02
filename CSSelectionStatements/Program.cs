using System;
using System.Collections.Generic;
using System.Text;

namespace CSSelectionStatements
{
    internal class Program
    {
        /*
         * Exercise 1:
         *  Create a program that allows a user to play a game where they must guess what your favorite number is:
         * Create an if-statement that if the guessed number is below the initial value, print out “too low”.
         * Create an else-if statement that if the number is higher than the initial value, print out “too high”.
         * Create an else statement that prints out some type of congratulations for guessing the correct number e.g. “You guessed it!!!”.
         *
         * Exercise 2:
         *  Make a new C# .NET Core Console App and name it SwitchStatements for switch/case practice
         *  Ask the user for their favorite school subject.
         *  Store their answer in a variable
         *  Pass the variable as the expression in a switch statement.
         *  Create 5 different cases for different subjects.Each case will print the subject chosen and a custom message of your choosing.
         *  Create a default case to handle any case not handled
        */

        static void GuessANumber()
        {
            bool bGiveup = false;
            bool bGreatJob = false;
            int iLowerLimit = 1;
            int iUpperLimit = 10;
            int numberGuesses = 0;
            string prevguess = "";
            var r = new Random();
            var favNumber = r.Next(iLowerLimit, iUpperLimit);
            while (!bGiveup && !bGreatJob){
                Console.Clear();
                Console.WriteLine($"Guess a number between {iLowerLimit} and {iUpperLimit}. \nEnter 0 to give up");
                if (numberGuesses > 0)
                    Console.WriteLine($"\ntotal number of guesses: {numberGuesses} \nprevious guesses: {prevguess}\n");
                Console.Write("user input: ");
                var userInput = int.Parse(Console.ReadLine());
                Console.Clear();
                numberGuesses++;
                prevguess += $"{userInput}, ";
                if (userInput < favNumber)
                {
                    if (userInput == 0)
                    {
                        bGiveup = true;
                        Console.WriteLine("Better luck next time! \n press enter to exit... ");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine($"you guessed {userInput}: too low!\npress enter to guess again...");
                        Console.ReadLine();
                    }
                }
                else if (userInput > favNumber)
                {
                    Console.WriteLine($"you guessed {userInput}: too high!\npress enter to guess again...");
                    Console.ReadLine();
                }
                else
                {
                    double guessrank = 1 / Convert.ToDouble(numberGuesses);
                    string rank;
                    if (guessrank > 50)
                        rank = "n awesome";
                    else if (guessrank > 25)
                        rank = " decent";
                    else
                        rank = " terrible";
                    Console.WriteLine($"you guessed the correct number {favNumber} in {numberGuesses} guesses! yay!");
                    Console.WriteLine($"your rank is {guessrank}, you are a{rank} guesser!");

                    Console.WriteLine("\npress enter to exit");
                    Console.ReadLine();
                    bGreatJob = true;
                }
            }
        }

        static string SubjectResponse(string subject)
        {
            //string response = "oh yeah thats nice";
            string response;
            switch (subject)
            {
                case "math":
                    response = "I was at a party the other night and I saw e^x sitting in the corner alone. " +
                        "\nI asked him why he wasnt integrating himself with the others and" +
                        "\nhe said because it wouldnt make a difference.";
                    break;
                case "science":
                    response = "two scientists walk into a bar. The first asks for some H2O. " +
                        "\nThe second says he will have some H2O too" +
                        "\nthe second one dies.";
                    break;
                case "lunch":
                    response = "scheduling a meeting with a guidance counselor now...";
                    break;
                case "english":
                    response = "what building has the most stories?" +
                        "\nthe library.";
                    break;
                case "history":
                    response = "what is a pilgrim's favorite type of music?" +
                        "\nplymouth rock.";
                    break;
                default:
                    response = "oh yeah thats nice.";
                    break;
            }
            return response;
        }

        static void FavoriteSubject()
        {
            Console.WriteLine("what is your favorite school subject?");
            string userInput = Console.ReadLine();
            Console.WriteLine(SubjectResponse(userInput));
            Console.WriteLine("\npress enter to continue...");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            bool bExit = false;
            while (!bExit)
            {
                Console.Clear();
                Console.WriteLine("select which exercise to run: \n\t(1) Exercise 1: Guess A Number \n\t(2) Exercise 2: Favorite Subject" +
                    "\n\t(0) Exit");
                int userSelect = int.Parse(Console.ReadLine());
                switch (userSelect)
                {
                    case 0:
                        bExit = true;
                        break;
                    case 1:
                        GuessANumber();
                        break;
                    case 2:
                        FavoriteSubject();
                        break;
                    default:
                        Console.WriteLine("thank you. please come again");
                        break;
                }

            }
        }
    }
}
