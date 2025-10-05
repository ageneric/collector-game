using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] CardManager cardManager;
    public Card[] cardCollection;

    [SerializeField] Card givenCard = null;

    [SerializeField] Card desiredCard = null;

    private PlayerInteraction interactionController;
    private Collider2D myCollider;
    public GameObject displayObject;
    public GameObject bubbleObject;
    SpriteRenderer bubbleSprite;

    public bool isGiving = false;
    bool finishInteractions = false;

    // Start is called before the first frame update
    void Start()
    {
        cardCollection = null;
        interactionController = PlayerController.Instance.playerInteraction;
        myCollider = GetComponent<Collider2D>();
        bubbleSprite = bubbleObject.GetComponent<SpriteRenderer>();
        
        archetypeActions = new Dictionary<string, System.Action>
        {
            { "Vendor", () => generateVendor() }
        };
        
        determineArchetype();
    }

    void Interact(PlayerController player)
    {
        Debug.Log("Interacted!", player);
        if (isGiving)
        {
            player.card = givenCard;
            finishInteractions = true;
            isGiving = false; // Reset the giving state
            HideInteraction();
        }
    }

    void setBubble(Sprite icon, bool isGiving) {
        // todo: show icon art of card
        this.isGiving = isGiving;
        bubbleSprite.color = isGiving ? Color.green : Color.red;
    }

    void generateVendor()
    {
        int cardIndex = Random.Range(0, cardManager.GetCards.Length);
        givenCard = cardManager.GetCards[cardIndex];
        setBubble(givenCard.iconArt, true);
    }
    private Dictionary<int, string> archetypeLookup = new Dictionary<int, string>
    {
        { 0, "Vendor" }
    };

    private Dictionary<string, System.Action> archetypeActions;

    void determineArchetype()
    {
        int num = Random.Range(0, archetypeLookup.Count);
        archetypeActions[archetypeLookup[num]].Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        bool colliderMatch = (interactionController.selectedCollider == myCollider);
        // Only show interaction if we're giving and have a card to give
        
        if (colliderMatch && !finishInteractions)
        {
            ShowInteraction();
        }
        else
        {
            HideInteraction();
        }
    }

    public void ShowInteraction()
    {
        bubbleObject.SetActive(true);
    }

    public void HideInteraction()
    {
        bubbleObject.SetActive(false);
    }
}
