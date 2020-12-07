using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    void Pickup()
    {

        bool successfulPickup = Inventory.instance.Add(item);
        if (successfulPickup)
        {
            Destroy(gameObject);
        }
        

    }
}
