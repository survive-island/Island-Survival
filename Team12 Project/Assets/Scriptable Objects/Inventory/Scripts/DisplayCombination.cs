﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCombination : MonoBehaviour
{
    public CombinationObject combi;
    Dictionary<CombinationSlot, GameObject> itemsDisplayed = new Dictionary<CombinationSlot, GameObject>();

    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < 3; i++) //combi.Container.Count = 3
        {
            if (itemsDisplayed.ContainsKey(combi.Container[i]))
            //if item is in combination box
            {
               // itemsDisplayed[combi.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = combi.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(combi.Container[i].item.prefab, new Vector3(0f, 0f, 0f), Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponent<RectTransform>().localScale = new Vector3(16.5f, 14f, 1f);
                obj.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f, 0f, 0f);
               // obj.GetComponentInChildren<TextMeshProUGUI>().text = combi.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(combi.Container[i], obj);
            }
        }
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < 3; i++)
        {
            var obj = Instantiate(combi.Container[i].item.prefab, new Vector3(0f, 0f, 0f), Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponent<RectTransform>().localScale = new Vector3(16.5f, 14f, 1f);
            obj.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f, 0f, 0f);
           // obj.GetComponentInChildren<TextMeshProUGUI>().text = combi.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(combi.Container[i], obj);
        }
    }
    public Vector3 GetPosition(int i)
    {
        //if (i < 3)
            return new Vector3(-63f + 62 * i, 18f, 0f);
        //else
           //return new Vector3(-5.07f + 2 * (i - 6), -1f, 0f);
    }
}
