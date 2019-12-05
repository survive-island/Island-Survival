using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory",menuName ="Inventory System/Inventory")]
public class CombinationObject : ScriptableObject
{
    public List<CombinationSlot> Container = new List<CombinationSlot>();
    public static List<int> ContList = new List<int>();
    public ItemDatabaseObject database;

    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false; //first assume not to have items
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            Container.Add(new CombinationSlot(database.GetId[_item], _item, _amount));
            ContList.Add(database.GetId[_item]);
        }
    }
}

[System.Serializable]
public class CombinationSlot 
{
    public int ID;
    public ItemObject item;
    public int amount;
    public CombinationSlot(int _id,ItemObject _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}