using System;
using UnityEngine;
using Unity.VisualScripting;

[Serializable, Inspectable]
public class Card
{
    [Inspectable]
    public string name = "";
    [Inspectable]
    public string type = "";
    [Inspectable]
    public string color = "";
    [Inspectable]
    public int grade = 0;

    [Inspectable]
    public Sprite iconArt = null;

    [Inspectable]
    public Sprite fullArt = null;

    // Copy constructor
    public Card(Card other=null)
    {
        if (other != null)
        {
            name = other.name;
            type = other.type;
            color = other.color;
            grade = other.grade;
            iconArt = other.iconArt;
            fullArt = other.fullArt;
        }
    }
}