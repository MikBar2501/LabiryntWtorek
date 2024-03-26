using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool open = false;
    public Transform closePosition;
    public Transform openPosition;
    public Transform door;
    float speed = 5;


    // Start is called before the first frame update
    void Start()
    {
        door.position = closePosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(open && Vector3.Distance(door.position, openPosition.position) > 0.001f)
        {
            door.position = Vector3.MoveTowards(door.position, openPosition.position, Time.deltaTime * speed);
        }
    }

    public void Open()
    {
        open = true;
    }
}
