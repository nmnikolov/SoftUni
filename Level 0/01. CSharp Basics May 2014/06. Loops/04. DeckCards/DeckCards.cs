using System;

//Write a program that generates and prints all possible cards from a standard deck of 52 cards (without the jokers). The cards should be printed using the 
//classical notation (like 5♠, A♥, 9♣ and K♦). The card faces should start from 2 to A. Print each card face in its four possible suits: clubs, diamonds, hearts and spades. 
//Use 2 nested for-loops and a switch-case statement.
// | output      |
// | 2♣ 2♦ 2♥ 2♠ |
// | 3♣ 3♦ 3♥ 3♠ |
// | …           |
// | K♣ K♦ K♥ K♠ |
// | A♣ A♦ A♥ A♠ |

class DeckCards
{
    static void Main()
    {
        for (int i = 2; i <= 10; i++)
        {
            Console.WriteLine(i + "♣ " + i + "♦ " + i + "♥ " + i + "♠");                     
        }

        for (int j = 1; j <= 4; j++)
        {
            switch (j)
            {
                case 1:
                    Console.WriteLine("J♣ J♦ J♥ J♠"); break;
                case 2:
                    Console.WriteLine("Q♣ Q♦ Q♥ Q♠"); break;
                case 3:
                    Console.WriteLine("K♣ K♦ K♥ K♠"); break;
                case 4:
                    Console.WriteLine("A♣ A♦ A♥ A♠"); break;
                default:
                    break;
            }
        }
    }
}