using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.IO.Pipes;
using UnityEditor;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    public string savePath;//maybe multiple locations
    public string saveMissionPath;

    public ItemDatabaseObject database;
    public MissionDatabaseObject missionDB;

    public List<InventorySlot> Container = new List<InventorySlot>();

    private void OnEnable()
    {
#if UNITY_EDITOR
        database = (ItemDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Database.asset", typeof(ItemDatabaseObject));
        missionDB = (MissionDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/MissionDatabase.asset", typeof(MissionDatabaseObject));
#else
        database = Resources.Load<ItemDatabaseObject>("Database");
        missionDB = Resources.Load<MissionDatabaseObject>("MissionDatabase");
#endif
    }


    public void AddItem(ItemObject _item, int _amount)
    {
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                return;
            }
        }
        Container.Add(new InventorySlot(database.GetId[_item], _item, _amount));
    }

    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        string saveMission = JsonUtility.ToJson(this, true);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        FileStream file2 = File.Create(string.Concat(Application.persistentDataPath, saveMissionPath));
        //to save files
        bf.Serialize(file, saveData);
        bf.Serialize(file2, saveMission);
        file.Close();
    }
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)) && File.Exists(string.Concat(Application.persistentDataPath, saveMissionPath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            FileStream file2 = File.Open(string.Concat(Application.persistentDataPath, saveMissionPath), FileMode.Open);

            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file2).ToString(), this);
            file.Close();
        }
    }

    public void OnBeforeSerialize()
    {
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Container.Count; i++)
        {
            Container[i].item = database.GetItem[Container[i].ID];
        }
        missionDB.mission_num = skipBtn.missionNum;
    }
}

[System.Serializable]
public class InventorySlot
{
    public int ID;
    public ItemObject item;
    public int amount;
    public InventorySlot(int _id, ItemObject _item, int _amount)
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