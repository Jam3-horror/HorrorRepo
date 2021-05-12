using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory.");

            return;
        }

        instance = this;
    }

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if(!items.Contains(item))
        {
            items.Add(item);
            return true;
        }
        return false;
    }

    public void Remove(Item item)
    {
        if(items.Contains(item))
        {
            items.Remove(item);
        }
    }
}
