using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {
        static void HangMan()
        {
            // Declare variables
            List<string> letters = new List<string>(); //list of wrong letters
            List<string> wrongWords = new List<string>(); //list of wrong words
            int guesses = 10; // number of guesses
            string word = string.Empty;
            string hiddenWord = string.Empty;
            string [] words = new string[] {"banana", "apple", "orange","grape","pear","grapefruit","peach","watermelon", 
                                             "plum","pineapple", "apricot","lemon","lime","mango", "papaya","kiwi","cantaloupe","nectarine"};  //word Bank
            Random rnd = new Random();
            hiddenWord = words[rnd.Next(1,words.Length+1)-1];

            // construct the our word with underscores - to this word we gonna add right letters
            for (int i = 0; i < hiddenWord.Length; i++)
            {
                word += "_";
            }

            while (hiddenWord!=word && guesses>0)  //until we guess the word or use all guesses
            {
                PrintLettersAndWords(letters, wrongWords, word); // print our word, print lists of wrong letters and words
                Console.WriteLine("Enter word or letter");
                string input = Console.ReadLine().ToLower();  //Take input from user
                
                if (input.Length > 1) // Check if input is word
                {
                    if (input == hiddenWord) // check if we guess the word
                    {
                        word = hiddenWord;
                    }
                    else
                    {
                        wrongWords.Add(input); // if word is wrong - add it to wrongwords list
                        guesses--;
                        Console.WriteLine("Word is wrong, you have " + guesses + " guesses left, try to guess letters first");
                    }
                }
                else //or inout is letter
                {
                    if (hiddenWord.Contains(input))
                    {
                        word = ChangeWord(input, word, hiddenWord); // if we got the rigth letter - add it to our word
                        Console.WriteLine("Correct! Keep going. You still have " + guesses + " guesses left" );
                    }
                    else
                    {
                        letters.Add(input); // if word is wrong - add it to wrongletters list
                        guesses--;
                        Console.WriteLine("Letter is wrong, you have " + guesses + " guesses left");
                       
                    }
                }
            }

            // In the end of while loop we check the reason why we left the loop
            if (hiddenWord == word)
            {
                Console.WriteLine("YOU WIN! The word is " + word);
            }
            else // we have no guesses left
                Console.WriteLine("YOU LOSE! The word was " + hiddenWord);
           
            
            // Final code, ask user if userr wanna play again
            Console.WriteLine("Do you want to play again? Y/N:");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "yes" || answer.ToLower() == "y")
            {
                Console.Clear();
                HangMan(); 
            }
        }

        // Chnages the word with already guessed letters
        static string ChangeWord(string letter, string word, string hiddenWord)
        {
            string output = "";
            for (int i = 0; i < hiddenWord.Length; i++)
            {
                if (hiddenWord[i].ToString() == letter)
                {
                    output += hiddenWord[i]; // Fill the word with letter
                }
                else
                {
                    output += word[i];//.. or with letter already existing in the word
                }
            }
            return output;
        }

        // Print out the letter and words we already guessed
        static void PrintLettersAndWords(List<string> letters, List<string> words, string word)
        {
            string message = "Letters guessed: "; // Construct the message to print it out
            foreach (var item in letters)
            {
                message += item + " "; // Add letters to message
            }
            message += " Words guessed: ";
           
            foreach (var item in words)
            {
                message += item + " "; // Add words to messsage
            }

            Console.WriteLine(message);

            // Print our word with spaces between letters
            message = "Your word is: ";
            for (int i = 0; i < word.Length; i++)
            {
                message += word[i] + " ";
            }
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            string username = Console.ReadLine();
            Console.WriteLine("Welcome, " + username);
            Console.WriteLine("You will be guessing letters or the word until you get it correct");
            
            HangMan();
            
        }
    }
}
