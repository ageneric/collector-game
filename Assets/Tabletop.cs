using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabletop : MonoBehaviour
{
    public bool hasCard;
    public Card card;  // last held card

    private PlayerInteraction interactionController;
    private Collider2D myCollider;
    public GameObject displayObject;
    public GameObject bubbleObject;

    // Start is called before the first frame update
    void Start()
    {
        card = new Card();
        interactionController = PlayerController.Instance.playerInteraction;
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        displayObject.SetActive(hasCard);

        if (interactionController.selectedCollider == myCollider)
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
