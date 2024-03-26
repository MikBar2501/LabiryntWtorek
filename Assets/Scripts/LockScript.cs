using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : MonoBehaviour
{
    public DoorScript[] doors;
    public KeyColor myColor;
    bool iCanOpen = false;
    bool locked = false;
    Animator key;




    // Start is called before the first frame update
    void Start()
    {
        key = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && iCanOpen && !locked)
        {
            key.SetBool("useKey", CheckTheKey());
        }
    }

    public void UseKey()
    {
        foreach(DoorScript door in doors)
        {
            door.Open();
        }
    }

    public bool CheckTheKey()
    {
        if(GameManager.instance.redKey > 0 && myColor == KeyColor.Red)
        {
            GameManager.instance.redKey--;
            locked = true;
            return true;
        }
        else if(GameManager.instance.greenKey > 0 && myColor == KeyColor.Green)
        {
            GameManager.instance.greenKey--;
            locked = true;
            return true;
        }
        else if (GameManager.instance.goldKey > 0 && myColor == KeyColor.Gold)
        {
            GameManager.instance.goldKey--;
            locked = true;
            return true;
        } else
        {
            Debug.Log("You don't have a key!");
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = true;
            Debug.Log("You Can Use Lock");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = false;
            Debug.Log("You Can not Use Lock");
        }
    }

}
