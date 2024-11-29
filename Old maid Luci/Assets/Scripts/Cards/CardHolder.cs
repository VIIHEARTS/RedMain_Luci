using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageDisplay;
    [SerializeField] private TextMeshProUGUI pairDisplay;
    private List<Card> cards = new List<Card>();   

    public void AddCard(Card newCard)
    {
        cards.Add(newCard);
        DisplayMessage($"Card added: {newCard.cardType}");
        CheckForPairs();
    }

    private void CheckForPairs()
    {
        Dictionary<string, int> cardCount = new Dictionary<string, int>();

        foreach (var card in cards) 
        {
            if (cardCount.ContainsKey(card.cardType))
            {
                cardCount[card.cardType]++;
            }
                
            else
                cardCount[card.cardType] = 1;
        }

        foreach (var pair in cardCount)
        {
            if (pair.Value > 1)
                DisplayMessage($"You have a pair of {pair.Key}");
        }
    }

    public void DiscardPair(string cardType)
    {
        int discardCount = 0;

        cards.RemoveAll(card =>
        {
            if (discardCount < 2 && card.cardType == cardType)
            {
                discardCount++;
                DisplayMessage($"Discarded: {card.cardType}");
                return true;
            }
            return false;
        });

        if (discardCount < 2)
        {
            DisplayMessage($"Not enough cards to discard a pair of {cardType}");
        }

        UpdatePairsDisplay();
    }

    public List<Card> GetCards()
    {
        return new List<Card>(cards);
    }

    private void UpdatePairsDisplay()
    {
        if (pairDisplay == null)
        {
            Debug.LogWarning("PairDisplay is not assigned in the inspector!");
            return;
        }

        Dictionary<string, int> cardCount = new Dictionary<string, int>();

        foreach (var card in cards)
        {
            if (cardCount.ContainsKey(card.cardType))
            {
                cardCount[card.cardType]++;
            }
            else
            {
                cardCount[card.cardType] = 1;
            }
        }

        List<string> pairs = new List<string>();
        foreach (var pair in cardCount)
        {
            if (pair.Value > 1)
            {
                pairs.Add($"{pair.Key} x{pair.Value}");
            }
        }

        if (pairs.Count > 0)
        {
            pairDisplay.text = "Pairs:\n" + string.Join("\n", pairs);
        }
        else
        {
            pairDisplay.text = "Pairs: None";
        }
    }

    private void DisplayMessage(string message)
    {
        if (messageDisplay != null)
        {
            messageDisplay.text = message;
        }
        else
        {
            Debug.LogWarning("MessageDisplay is not assigned in the inspector!");
        }
    }
}
