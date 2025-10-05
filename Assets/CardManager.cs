using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/////
/// Data object to store all cards in the game
///
[CreateAssetMenu(fileName = "New Card Manager", menuName = "Game/Card Manager")]
public class CardManager : ScriptableObject
{
    [SerializeField]
    private Card[] cards;
    public Card[] GetCards => cards;
}
