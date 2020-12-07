
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "item name";

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

    public virtual void Use()
    {
        Debug.Log("using " + name);
    }
}
