using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/MissionDatabase")]
public class MissionDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public int mission_num;

    public void OnAfterDeserialize()
    {
        mission_num = skipBtn.missionNum;
    }
    public void OnBeforeSerialize()
    {
    }
}
