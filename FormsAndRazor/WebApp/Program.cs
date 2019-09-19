using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

/*
 * Author Jester Cornejo
 *
 * Program v2.0
 *
 * June 26, 2019 10:53PM
 *
 */

namespace CORE_3
{ }
//this class is a clearfix concept that resets the background and sets the font foreground to black
class DefaultConsole
{
    public static void clearfix()
    {
        BackgroundColor = ConsoleColor.White;
        Clear();
        ForegroundColor = ConsoleColor.Black;
    }
    public static void DoorFeature()
    {
        clearfix();
        bool play = true;
        WriteLine("Hello And Welcome to Master Mind");
        play = GetInput.Insurance("---Would You like to Play?---", false);

        switch (play)
        {
            case true:
                MasterMind.AskForSettings();
                break;
            case false:
                Environment.Exit(0);
                break;
        }
    }

}
// i will make the most flexible, most sophisticated helper class.
// this will include a valid int, a range, and an insurance option
class Prompts
{
    //this method is for displaying error messages with a red foreground and an option for clearing the background.
    public static void Error(string prompt, bool Clearfix)
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(prompt + " Please try again.");
        ForegroundColor = ConsoleColor.Black;
        if (Clearfix == true)
        {
            DefaultConsole.clearfix();
        }
    }
}
class GetInput
{
    //this method asks for yes or no options;
    public static bool Insurance(string prompt, bool ClearBackground)
    {
    Retry:
        if (ClearBackground == true)
        {
            DefaultConsole.clearfix();
        }
        bool decision = false;
        WriteLine(prompt + " Y/N");

        ConsoleKeyInfo key = ReadKey(true);

        if (key.KeyChar == 'y' || key.KeyChar == 'Y')
        {
            decision = true; // true is yes
        }
        else if (key.KeyChar == 'n' || key.KeyChar == 'N')
        {
            decision = false; // false is no;
        }
        else
        {
            Prompts.Error("Invalid entry", false);
            goto Retry;
        }
        return decision;

    }
    //this method is for getting inputs
    //this includes range, and insurance
    public static int GetInt(string prompt, string error, int min, int max, bool range, bool insurance)
    {
    TryAgain:
        // we ask and validate the result.
        int result;
        bool Accept = false;
        Write(prompt);
        while (!int.TryParse(ReadLine(), out result))
        {
            Prompts.Error(error, false);
            Write(prompt);
        }
        // we check for the range if its enabled
        if (range == true)
        {
            //if our result by passes the range:
            if (result < min || result > max)
            {
                // we tell them that they're wrong and try again
                Prompts.Error($"{result} is not valid. the range is from {min} to {max}", false);
                goto TryAgain;
            }
        }
        //now we check for insurance
        if (insurance == true)
        {
            //we ask the user if they want to proceed
            Accept = Insurance($"You entered {result}. Do you accept?", false);
            switch (Accept)
            {
                case true:
                    break;
                case false:
                    goto TryAgain;
            }
        }
        return result;

    }
    // this next method is for getting strings
    public static string GetString(string prompt, string error, bool insurance, bool ClearBackground, bool ExitCode, string ExitCommand, ref bool DebugMode)
    {
    TryAgain:
        //check for clearfix
        if (ClearBackground == true)
        {
            DefaultConsole.clearfix();
        }
        DebugMode = false;
        string result = "";
        bool Accept = false;
        bool Exit = false;
        string CheatCode = "TEST";

        //we ask for input
        Write(prompt);
        result = ReadLine();
        if (result == "")
        {
            Prompts.Error("Please enter something.", false);
            ReadKey();
            goto TryAgain;
        }
        //we check for an exit program:
        if (result == ExitCommand)
        {
            Exit = Insurance("Are you sure you want to exit?", false);
            switch (Exit)
            {
                case true:// yes, accept the input
                    DefaultConsole.DoorFeature();
                    break;
                case false:// no try again
                    goto TryAgain;
            }
        }
        //we check for debug mode by cheat code input
        if (result == CheatCode)
        {
            DebugMode = true;
            if (insurance == true)
            {
                ForegroundColor = ConsoleColor.DarkGreen;
                Accept = Insurance("Debug Mode, Do you wish to proceed?", false);
                ForegroundColor = ConsoleColor.Black;
                switch (Accept)
                {
                    case true:// yes, accept the input
                        break;
                    case false:// no try again
                        goto TryAgain;
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.DarkGreen;
                WriteLine("DebugMode");
                ForegroundColor = ConsoleColor.Black;
            }

        }
        else
        {
            //DebugMode = false;
            //we check for insurance
            if (insurance == true)
            {
                Accept = Insurance($"Welcome {result} Would you like to Proceed?", false);
                switch (Accept)
                {
                    case true:// yes, accept the input
                        break;
                    case false:// no try again
                        goto TryAgain;
                }
            }
        }
        return result;
    }
}
class MasterMind
{
    public static void AskForSettings()
    {


        string name;
        string error = "Invalid Input";
        string DifficultyMode = "";
        string Exit = "EXIT";

        const int MINNumbersToPlay = 4;
        const int MAXNumbersToPlay = 10;
        const int MINDifficulty = 1;
        const int MAXDifficulty = 3;
        const int MINNumbersToGuess = 1;// this is for each section of the list to be guessed
        const int MAXNumbersToGuess = 4;

        int NumberOfTheGame;
        int Difficulty;
        int Attempts;

        bool debugMode = false;

        DefaultConsole.clearfix();
        // First we ask for the name:
        name = GetInput.GetString("Enter your Name: ", error, true, true, true, Exit, ref debugMode);

        //Then We ask for the amount of numbers to be guessed:
        NumberOfTheGame = GetInput.GetInt($"\nEnter The Amount of number you want to guess ({MINNumbersToPlay} to {MAXNumbersToPlay}): ", error, MINNumbersToPlay, MAXNumbersToPlay, true, true);

        //Now we ask for the difficulty
        Difficulty = GetInput.GetInt($"\nDifficulty -- 1.) Imposible | 2.) Veteran | 3.) Easy --", error, MINDifficulty, MAXDifficulty, true, true);


        //lets declare the difficulties so that we can call them out.
        switch (Difficulty)
        {
            case 1:
                DifficultyMode = "Impossible";
                break;
            case 2:
                DifficultyMode = "Veteran";
                break;
            case 3:
                DifficultyMode = "Easy";
                break;
        }

        //We calculate the number of attempts
        Attempts = NumberOfTheGame * Difficulty;

        //we check for debug mode:
        switch (debugMode)
        {
            case false:
                TellUser(name, DifficultyMode, MINNumbersToGuess, MAXNumbersToGuess, Attempts, NumberOfTheGame, Difficulty);
                break;
            case true:
                PlayTheGame(MINNumbersToGuess, MAXNumbersToGuess, NumberOfTheGame, Attempts, debugMode, name);
                break;

        }



    }
    private static void TellUser(string name, string DifficultyMode, int MINNumbersToGuess, int MAXNumbersToGuess, int Attempts, int NumberOfTheGame, int Difficulty)
    {
        DefaultConsole.clearfix();


        bool TryAgain = false;

        //then we tell the user what they have
        WriteLine($"Alright {name}");
        WriteLine($"The difficulty you have choosen is {DifficultyMode}");
        WriteLine($"You are to guess {NumberOfTheGame} numbers that ranges from {MINNumbersToGuess} to {MAXNumbersToGuess}");
        WriteLine($"You must Guess The correct sequence of numbers generated randomly by the computer");
        WriteLine($"You Have {Attempts} Attempts.");

        //then we ask if they are sure of their answers
        TryAgain = GetInput.Insurance("Do you wish to proceed?", false);
        switch (TryAgain)
        {
            case false:
                AskForSettings();
                break;
            case true:
                PlayTheGame(MINNumbersToGuess, MAXNumbersToGuess, NumberOfTheGame, Attempts, false, name);
                break;

        }
    }
    public static void PlayTheGame(int minGuess, int maxGuess, int NumberToPlay, int Attempts, bool DebugMode, string name)
    {

        // alright this is where the fun begins
        // first we make a random agent
        Random r = new Random();
        // then a list for what needs to be guessed
        List<int> Guesses = new List<int>();
        // and the list for the answer
        List<int> CorrectAnswer = new List<int>();

        bool ReTry = false;

        int misses = 0;
        int hits = 0;
        int NumberOfAttempts = 0;

        // First we generate a random answer
        for (int i = 0; i < NumberToPlay; i++)
        {
            //say the user chooses to guess 6 numbers, this generator assigns a random number from minimum to maximum for each item for the correct answer list
            CorrectAnswer.Add(r.Next(minGuess, maxGuess + 1));
        }
        //--------------------------------------------------------The Guessing Game----------------------------------\\


        //then for the number of attempts, we ask the user for their guesses:
        do// when there are no more attempts, we end the loop.
        {
        GuessAgain:
            //WE CHECK first if victory is true
            if (Attempts == 0)// lose
            {
                WriteLine();
                Write("The answer was: ");
                foreach (var item in CorrectAnswer)
                {
                    Write(item);
                    Write(" ");
                }
                WriteLine();
                Lost(name, DebugMode);

            }
            if (hits == NumberToPlay)//win
            {
                WriteLine();
                Write("The answer was: ");
                foreach (var item in CorrectAnswer)
                {
                    Write(item);
                    Write(" ");
                }
                WriteLine();
                Win(name, NumberOfAttempts, DebugMode);
            }
            // if we go back to the begining, this means that the player has not gueesed the coorect answer. This means that we must clear all for another guessing attempt
            Guesses.Clear();
            misses = 0;
            hits = 0;
            // this also means that we should decrease the number of attempts that the have left.
            WriteLine();

            //We display These attempts remaining.

            // if debug mode is enabled, we want to reveal to the player, the result.
            if (DebugMode == true)
            {
                //display the items in the list for correct answer
                WriteLine($"Attempts: {Attempts}");
                WriteLine();
                Write("DIAGNOSTIC: ");
                foreach (var item in CorrectAnswer)
                {
                    Write(item);
                    Write(" ");
                }
                WriteLine();
            }
            else
            {
                WriteLine($"There are {NumberToPlay} numbers that you have to guess. GoodLuck {name}");
                WriteLine();
                WriteLine($"Attempts: {Attempts}");
            }
            //---------------------------------------------then we ask for their guesses
            for (int i = 0; i < NumberToPlay; i++)
            {
                Guesses.Add(GetInput.GetInt($"Digit {i + 1}: ", "Invalid", minGuess, maxGuess, true, false));
            }
            //After testing the program i encountered with imstake and that messes up with my strategy so lets give the user the option to try again
            //-----------------------------------------------Insurance

            ReTry = GetInput.Insurance("Are You Sure of your answer?", false);
            switch (ReTry)
            {
                case false:
                    goto GuessAgain;
                case true:
                    break;
            }

            BackgroundColor = ConsoleColor.Cyan;
            WriteLine();
            Write("Your Guess is:");
            foreach (var item in Guesses)
            {
                Write(item + " ");
            }
            WriteLine();
            BackgroundColor = ConsoleColor.White;
            Write("\t     ");
            for (int i = 0; i < NumberToPlay; i++)
            {
                if (CorrectAnswer.ElementAt(i).Equals(Guesses.ElementAt(i)))
                {
                    if (DebugMode == true)
                    {
                        Write("-H");
                    }
                    hits++;


                }
                else if (!CorrectAnswer.ElementAt(i).Equals(Guesses.ElementAt(i)))
                {
                    if (DebugMode == true)
                    {
                        Write("-M");
                    }
                    misses++;
                }

            }
            WriteLine();
            WriteLine("Miss = " + misses);
            WriteLine("Hits = " + hits);
            Attempts--; // ------------ decrease attempts by 1
            NumberOfAttempts++;
        } while (Attempts != 0);
        WriteLine();
        Write("The answer was: ");
        foreach (var item in CorrectAnswer)
        {
            Write(item);
            Write(" ");
        }
        WriteLine();
        Lost(name, DebugMode);
    }
    public static void Lost(string name, bool DebugMode)
    {
        bool TryAgain = false;
        if (DebugMode == true)
        {
            WriteLine("The Lost Program Protocol");
        }
        else
        {
            WriteLine($"{name} Lost");
        }
        TryAgain = GetInput.Insurance("Would you like to try again?", false);
        switch (TryAgain)
        {
            case true:
                AskForSettings();
                break;
            case false:
                DefaultConsole.DoorFeature();
                break;
        }

    }
    public static void Win(string name, int numberOfAttempts, bool DebugMode)
    {
        bool TryAgain = false;
        if (DebugMode == true)
        {
            WriteLine($"The Win Program Protocol {numberOfAttempts} ATTEMPTS");
        }
        else
        {
            WriteLine($"{name}! You won Congratulations!");
            WriteLine($"After {numberOfAttempts} Attempt/s, you have guessed the number");
            WriteLine("YOU WIN NOTHING");

        }
        TryAgain = GetInput.Insurance("Would you like to Play again?", false);
        switch (TryAgain)
        {
            case true:
                AskForSettings();
                break;
            case false:
                DefaultConsole.DoorFeature();
                break;
        }

    }


}


class Program
{
    static void Main(string[] args)
    {
        DefaultConsole.DoorFeature();
    }
}