using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDoor : MonoBehaviour
{
    public Item requiredItem;

    bool opened = false;

    Transform target;
    public float speed = 1;
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.transform.name == "player")
        {
            Debug.Log("player here");
            
        }*/
        if (Inventory.instance.items.Contains(requiredItem))
        {
            Debug.Log("you have key");
            opened = true;
        }
        Debug.Log("entered trigger");
    }
    // Start is called before the first frame update
    void Start()
    {
        target = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(opened)
        {
            // Move our position a step closer to the target.
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            Debug.Log("door moving");
        }
    }
}
