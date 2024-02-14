using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freez : PickUp
{
    public int freez = 5;

    public override void Picked()
    {
        GameManager.instance.FreezTime(freez);
        base.Picked();
    }

}
