using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject myHand;
    public GameObject error;
    public static bool haveStick=false;

    public void putItem(GameObject gameobject)
    {
        var item = gameobject.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(gameobject);
        
        }
    }
    public void useItem(GameObject gameobject)
    {
        var item = gameobject.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            item.GetComponent<Collider>().isTrigger = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.transform.SetParent(myHand.transform);
            item.transform.localPosition = new Vector3(0.006799746f, -0.03290001f, 0.02729985f);//put it under arms
            item.transform.localRotation = Quaternion.Euler(-8.024f,-159.681f,-360.021f);
            item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX |
                RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            haveStick = true;
        }
    }

    public void pickFish(GameObject gameobject)
    {
        var item = gameobject.GetComponent<Item>();
        if (item && haveStick)
        {
            inventory.AddItem(item.item, 1);
            item.GetComponent<Collider>().isTrigger = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.transform.SetParent(myHand.transform);
            item.transform.localPosition = new Vector3(0.009399922f, 0.01299987f, 0.03560022f);//put it under arms
            item.transform.localRotation = Quaternion.Euler(-8.024f, -519.681f, -0.021f);
            item.transform.localScale = new Vector3(0.008015299f, 0.004941517f, 0.005079972f);
            item.GetComponent<Rigidbody>().mass = 0;
            item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX |
                RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
        else if (item&&!haveStick)
        {
            messageState.messageNum = 1;
            error.SetActive(true);
        }
    }

    private void OnApplicationQuit()
    {
      inventory.Container.Clear();
    }
}
