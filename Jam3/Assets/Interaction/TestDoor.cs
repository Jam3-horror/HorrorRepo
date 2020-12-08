using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDoor : MonoBehaviour
{
    public Item requiredItem;

    bool opened = false;

    public Transform target;
    public Transform door;
    public float speed = 1;
    private void OnTriggerStay(Collider other)
    {
        if (Inventory.instance.items.Contains(requiredItem))
        {
            opened = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(opened)
        {
            float step = speed * Time.deltaTime;
            door.position = Vector3.MoveTowards(door.position, target.position, step);
        }
    }
}
