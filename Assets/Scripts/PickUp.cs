using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public AudioClip pickClip;
   
    public void Update()
    {
        Rotation();
    }

    public virtual void Picked()
    {
        GameManager.instance.PlayClip(pickClip);
        Debug.Log("Podnios³em");
        Destroy(this.gameObject);
    }

    public void Rotation()
    {
        transform.Rotate(new Vector3(0f, 5f, 0) * Time.deltaTime);
    }
}
