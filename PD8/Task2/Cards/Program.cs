using System;
using System.Collections.Generic;
using System.Linq;

public class Card
{
    private int value;
    private int suit;

    public Card(int theValue, int theSuit)
    {
        value = theValue;
        suit = theSuit;
    }

    public string GetSuitAsString()
    {
        switch (suit)
        {
            case 1: return "Clubs";
            case 2: return "Diamonds";
            case 3: return "Spades";
            case 4: return "Hearts";
            default: return "Unknown";
        }
    }

    public string GetValueAsString()
    {
        if (value >= 2 && value <= 10)
        {
            return value.ToString();
        }
        else
        {
            switch (value)
            {
                case 1: return "Ace";
                case 11: return "Jack";
                case 12: return "Queen";
                case 13: return "King";
                default: return "Unknown";
            }
        }
    }

    public int GetValue()
    {
        return value;
    }

    public override string ToString()
    {
        return GetValueAsString() + " of " + GetSuitAsString();
    }
}

public class Deck
{
    private List<Card> cards;

    public Deck()
    {
        cards = new List<Card>();
        for (int suit = 1; suit <= 4; suit++)
        {
            for (int value = 1; value <= 13; value++)
            {
                cards.Add(new Card(value, suit));
            }
        }
    }

    public void Shuffle()
    {
        Random random = new Random();
        cards = cards.OrderBy(c => random.Next()).ToList();
    }

    public int CardsLeft()
    {
        return cards.Count;
    }

    public Card DealCard()
    {
        if (cards.Count == 0)
        {
            return null; // No more cards left
        }
        else
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }
}

public class HighLow
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to HighLow!");
        int totalScore = 0;
        int gamesPlayed = 0;

        while (true)
        {
            int score = PlayGame();
            totalScore += score;
            gamesPlayed++;
            Console.WriteLine($"Your score for this game: {score}");
            Console.Write("Do you want to play again? (yes/no): ");
            string playAgain = Console.ReadLine().ToLower();
            if (playAgain != "yes")
            {
                break;
            }
        }

        double averageScore = (double)totalScore / gamesPlayed;
        Console.WriteLine($"Average score across all games: {averageScore:F2}");
    }

    private static int PlayGame()
    {
        Deck deck = new Deck();
        deck.Shuffle();

        int score = 0;
        Card currentCard = deck.DealCard();
        Console.WriteLine($"First card: {currentCard}");

        while (true)
        {
            Console.Write("Will the next card be higher or lower? (h/l): ");
            string guess = Console.ReadLine().ToLower();

            Card nextCard = deck.DealCard();
            if (nextCard == null)
            {
                Console.WriteLine("No more cards left.");
                break;
            }

            Console.WriteLine($"Next card: {nextCard}");

            if ((guess == "h" && nextCard.GetValue() > currentCard.GetValue()) ||
                (guess == "l" && nextCard.GetValue() < currentCard.GetValue()))
            {
                Console.WriteLine("Correct!");
                score++;
                currentCard = nextCard;
            }
            else
            {
                Console.WriteLine("Incorrect!");
                break;
            }
        }

        return score;
    }
}
