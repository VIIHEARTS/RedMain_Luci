using UnityEngine;

public class FirePlace : MonoBehaviour
{
    [SerializeField] private CardHolder playerCardHolder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCardHolder.DiscardPair("Hearts");
            playerCardHolder.DiscardPair("Diamonds");
            playerCardHolder.DiscardPair("Spades");
        }
    }
}
