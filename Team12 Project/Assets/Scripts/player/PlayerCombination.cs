using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombination : MonoBehaviour
{
    public CombinationObject combi;

    public void putItem(GameObject gameobject)
    {
        var item = gameobject.GetComponent<Item>();
        if (item)
        {
            combi.AddItem(item.item, 1);
            //Destroy(gameobject);
            Debug.Log(gameobject.name);
        }
    }
    private void OnApplicationQuit()
    {
        combi.Container.Clear();
    }
}
