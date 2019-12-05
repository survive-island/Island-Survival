using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombination : MonoBehaviour
{
    public CombinationObject combi;
    public static bool invenItemClicked = false;

    public void putItem(GameObject gameobject)
    {
        if (pauseBtn.isCombination)
        {
            var item = gameobject.GetComponent<Item>();
            if (item){
                if(combi.Container.Count < 3) {
                    combi.AddItem(item.item, 1);
                    //Destroy(gameobject);
                    Debug.Log(gameobject.name);
                }
            }
            invenItemClicked = true;
        }
    }

    private void OnApplicationQuit()
    {
        combi.Container.Clear();
    }
}
