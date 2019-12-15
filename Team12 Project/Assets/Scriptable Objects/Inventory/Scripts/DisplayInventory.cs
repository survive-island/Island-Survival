using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    void Start()
    {
        //세이브, 로드 고려해서 새로운 미션으로 넘어갈 때 인벤토리 비우기
        //if (LoadScene.loadcheck == true && PlayerInventory.saveCheck == skipBtn.missionNum)
        if (LoadScene.loadcheck == true) //(다원추가)
        {
            LoadScene.loadcheck = false;
        }
        else
        {
            inventory.Container.Clear();
        }

        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for(int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            //if item is in inventory
            {
                //itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, new Vector3(0f, 0f, 0f), Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f, 0f, 0f);
                //obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, new Vector3(0f,0f,0f), Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f,0f,0f);
            //obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }
    public Vector3 GetPosition(int i)
    {
        if (i < 6)
            return new Vector3(-4.37f + 2*i, 4.54f, 0f);
        else
            return new Vector3(-4.37f + 2*(i-6), 2.7f, 0f);
    }
}