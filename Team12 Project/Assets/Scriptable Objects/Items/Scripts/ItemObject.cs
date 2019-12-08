using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment,
    Default
}


public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    public string ItemName;
    [TextArea(15,20)]
    public string description;

    public string GetTooltip()
    {
        string newLine = string.Empty;
        if (description != string.Empty)
        {
            newLine = "\n";
        }
        return string.Format("<color=red><size=1>{0}</size></color><size=0.5><i><color=white>"
            +newLine+"{1}</color></i></size>",ItemName,description);
    }
}
