using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum KeyColor
{
    Red,
    Green,
    Gold
}

public class Key : PickUp
{
    public KeyColor color;

    public override void Picked()
    {
        GameManager.instance.AddKey(color);
        base.Picked();
    }
}
