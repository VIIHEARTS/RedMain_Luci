using UnityEngine;
using TMPro;

public class CardPickup : MonoBehaviour
{
    [SerializeField] private CardHolder playerCardHolder;
    [SerializeField] private Card cardData;

    public GameObject Interact;

    private void Start()
    {
        gameObject.SetActive(true);
        Interact.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {        

        if (other.gameObject.tag == "Player")
        {
            Interact.SetActive(true);

            if (Input.GetKey(KeyCode.F))
            {
                Interact.SetActive(false);
                playerCardHolder.AddCard(cardData);
                gameObject.SetActive(false);
                Debug.Log($"Picked up card: {cardData.cardType}");
            }
        
        }
    }
}
