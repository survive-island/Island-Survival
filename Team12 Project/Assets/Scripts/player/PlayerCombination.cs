using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombination : MonoBehaviour
{
    public CombinationObject combi;
    public static bool invenItemClicked = false;

    public void Start()
    {
        combi.Container.Clear(); //(다원추가)
        CombinationObject.ContList.Clear();
    }

    public void putItem(GameObject gameobject)
    {
        if (pauseBtn.isCombination)
        {
            var item = gameobject.GetComponent<Item>();
            if (item){
                if(combi.Container.Count < 3) {
                    SoundManager.instance.PlayClickSound();
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
