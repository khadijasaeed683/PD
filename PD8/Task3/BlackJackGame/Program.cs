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
        if (value > 10)
        {
            return 10; // For Jack, Queen, and King
        }
        else
        {
            return value;
        }
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

public class Hand
{
    protected List<Card> cards;

    public Hand()
    {
        cards = new List<Card>();
    }

    public void Clear()
    {
        cards.Clear();
    }

    public void AddCard(Card c)
    {
        cards.Add(c);
    }

    public int GetCardCount()
    {
        return cards.Count;
    }

    public Card GetCard(int position)
    {
        if (position >= 0 && position < cards.Count)
        {
            return cards[position];
        }
        else
        {
            return null;
        }
    }

    public override string ToString()
    {
        string handString = "";
        foreach (Card card in cards)
        {
            handString += card.ToString() + "\n";
        }
        return handString;
    }
}

public class BlackjackHand : Hand
{
    public int GetBlackjackValue()
    {
        int val = 0;
        bool ace = false;

        foreach (Card card in cards)
        {
            int cardValue = card.GetValue();
            if (cardValue == 1)
            {
                ace = true;
            }
            val += cardValue;
        }

        // If hand contains Ace and total value <= 11, count Ace as 11
        if (ace && val + 10 <= 21)
        {
            val += 10;
        }

        return val;
    }
}

public class BlackjackGame
{
    private Deck deck;
    private BlackjackHand playerHand;
    private BlackjackHand dealerHand;

    public BlackjackGame()
    {
        deck = new Deck();
        playerHand = new BlackjackHand();
        dealerHand = new BlackjackHand();
    }

    public void StartGame()
    {
        Console.WriteLine("Welcome to Blackjack!");

        // Shuffle the deck before starting the game
        deck.Shuffle();

        // Deal initial cards to player and dealer
        playerHand.AddCard(deck.DealCard());
        playerHand.AddCard(deck.DealCard());
        dealerHand.AddCard(deck.DealCard());
        dealerHand.AddCard(deck.DealCard());

        Console.WriteLine("Your cards:");
        Console.WriteLine(playerHand);

        Console.WriteLine("Dealer's cards:");
        Console.WriteLine(dealerHand.GetCard(0)); // Only show dealer's first card
    }

    public void PlayerTurn()
    {
        while (playerHand.GetBlackjackValue() < 21)
        {
            Console.Write("Do you want to Hit (H) or Stand (S)? ");
            string choice = Console.ReadLine().ToUpper();

            if (choice == "H")
            {
                Hit(playerHand);
                Console.WriteLine("Your cards:");
                Console.WriteLine(playerHand);
            }
            else if (choice == "S")
            {
                Console.WriteLine("You chose to Stand.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 'H' to Hit or 'S' to Stand.");
            }
        }
    }

    public void DealerTurn()
    {
        Console.WriteLine("Dealer's turn:");

        while (dealerHand.GetBlackjackValue() < 17)
        {
            Hit(dealerHand);
            Console.WriteLine("Dealer draws a card.");
        }

        Console.WriteLine("Dealer's cards:");
        Console.WriteLine(dealerHand);
    }

    public void DetermineWinner()
    {
        int playerValue = playerHand.GetBlackjackValue();
        int dealerValue = dealerHand.GetBlackjackValue();

        Console.WriteLine($"Your hand value: {playerValue}");
        Console.WriteLine($"Dealer's hand value: {dealerValue}");

        if (playerValue > 21)
        {
            Console.WriteLine("You bust. Dealer wins.");
        }
        else if (dealerValue > 21 || playerValue > dealerValue)
        {
            Console.WriteLine("You win!");
        }
        else if (playerValue == dealerValue)
        {
            Console.WriteLine("It's a tie.");
        }
        else
        {
            Console.WriteLine("Dealer wins.");
        }
    }

    private void Hit(BlackjackHand hand)
    {
        Card card = deck.DealCard();
        hand.AddCard(card);
    }
}

class Program
{
    static void Main(string[] args)
    {
        BlackjackGame game = new BlackjackGame();
        game.StartGame();
        game.PlayerTurn();
        game.DealerTurn();
        game.DetermineWinner();
        Console.ReadKey();
    }
}
