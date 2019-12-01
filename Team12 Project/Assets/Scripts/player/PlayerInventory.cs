using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public void putItem(GameObject gameobject)
    {
        var item = gameobject.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(gameobject);
            Debug.Log(gameobject.name);
        }
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
