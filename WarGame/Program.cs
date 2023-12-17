using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

/* 
   Author: Maria Esteban
   Date Modified: Oct 27 2023
   Description: a standard 52 card deck is randomly divided between two players (computer and player). 
   One card for each player is reveal at a time. Award 2 points to the player who has the card with highest value and if they
   are tied one point for each one. 
*/

namespace WarGame
{
    class Program
    {
        static readonly List<int> VALUES = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        static readonly List<string> SYMBOLS = new List<string>() {"diamonds", "hearts", "spades", "clubs"};

        static List<Card> deck = new List<Card>();

        static void Main(string[] args)
        {
            Random generator = new Random();

            int playerScore = 0;
            int computerScore = 0;
            string flag = "A";

            FillDeck();

            int turn = 1;

            do
            {
                
                int randomPosition1 = generator.Next(0, deck.Count());
                Card playerCard = SelectCard(randomPosition1);

                int randomPosition2 = generator.Next(0, deck.Count());
                Card computerCard = SelectCard(randomPosition2);

                if (playerCard.getValue() > computerCard.getValue())
                {
                    playerScore += 2;
                }
                else if (playerCard.getValue() < computerCard.getValue())
                {
                    computerScore += 2;
                }
                else
                {
                    playerScore++;
                    computerScore++;
                }
                WriteLine("Deal #{0}", turn);

                string computerValue = "";
                if (computerCard.getValue() > 10 || computerCard.getValue() == 1)

                {
                    if (computerCard.getValue() == 1)
                        computerValue = "Ace";
                    else if (computerCard.getValue() == 11)
                        computerValue = "Jack";
                    else if (computerCard.getValue() == 12)
                        computerValue = "Queen";
                    else if (computerCard.getValue() == 13)
                        computerValue = "King";
                    WriteLine("Computer has {0} of {1}", computerValue, computerCard.getSymbol());
                }
                else
                    WriteLine("Computer has {0} of {1}", computerCard.getValue(), computerCard.getSymbol());

                string playerValue = "";
                if (playerCard.getValue() > 10 || computerCard.getValue() == 1)

                {
                    if (computerCard.getValue() == 1)
                        computerValue = "Ace";
                    else if (playerCard.getValue() == 11)
                        playerValue = "Jack";
                    else if (playerCard.getValue() == 12)
                        playerValue = "Queen";
                    else if (playerCard.getValue() == 13)
                        playerValue = "King";
                    WriteLine("Player has {0} of {1},", playerValue, playerCard.getSymbol());
                }
                else
                    WriteLine("Player has {0} of {1},", playerCard.getValue(), playerCard.getSymbol());

                WriteLine("Computer score is {0}", computerScore);
                WriteLine("Player score is {0}", playerScore);
                WriteLine();

                turn++;
                flag = ReadLine().ToUpper();
                if (flag.Equals("Q"))
                {
                    break;
                }
            } while (turn <= 26);
            WriteLine();
            Winner(playerScore, computerScore);
            WriteLine("Thank you for playing!");

        }

        static void FillDeck()
        {
            for(int i = 0; i < SYMBOLS.Count(); ++i)
            {
                for (int j = 0; j < VALUES.Count(); ++j)
                {
                    deck.Add(new Card(VALUES[j], SYMBOLS[i]));
                }
            }
        }

        static Card SelectCard(int position)
        {
            Card result = deck[position];
            deck.Remove(result);

            return result;
        }

        static void Winner(int playerScore, int computerScore)
        {
            if (playerScore > computerScore)
                WriteLine("The winner is the player!");
            else if (playerScore < computerScore)
                WriteLine("The winner is the computer!");
            else
                WriteLine("There was a tie!");
        }
    }
}
