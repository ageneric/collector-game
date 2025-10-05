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
}