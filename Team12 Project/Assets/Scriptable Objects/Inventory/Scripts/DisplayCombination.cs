using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCombination : MonoBehaviour
{
    public CombinationObject combi;
    Dictionary<CombinationSlot, GameObject> itemsDisplayed = new Dictionary<CombinationSlot, GameObject>();
    bool isClickedReset = false;

    // Update is called once per frame
    void Update()
    {   
        if(PlayerCombination.invenItemClicked) {
            UpdateDisplay();
            PlayerCombination.invenItemClicked = false;
        }
    }

    public void UpdateDisplay()
    {   
        if(isClickedReset) {
            Debug.Log("clicked reset boolean = ");
            Debug.Log(isClickedReset);
            isClickedReset = false;
            int cnt = itemsDisplayed.Count;
            Debug.Log("start!");
            
            for(int i = 0; i < cnt; i++) {
                Debug.Log("combi container count = ");
                Debug.Log(combi.Container.Count);
                Destroy(itemsDisplayed[combi.Container[0]]);
                combi.Container.RemoveAt(0);
            }

            Debug.Log(isClickedReset);
        } else {
            Debug.Log("container add?");
            if(combi.Container.Count != 0) {
                for (int i = 0; i < combi.Container.Count; i++) //combi.Container.Count = 3
                {
                    if (itemsDisplayed.ContainsKey(combi.Container[i])) {
                        itemsDisplayed[combi.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = combi.Container[i].amount.ToString("n0");
                    } else {
                        var obj = Instantiate(combi.Container[i].item.prefab, new Vector3(0f, 0f, 0f), Quaternion.identity, transform);
                        obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                        obj.GetComponent<RectTransform>().localScale = new Vector3(16.5f, 14f, 1f);
                        obj.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f, 0f, 0f);
                    // obj.GetComponentInChildren<TextMeshProUGUI>().text = combi.Container[i].amount.ToString("n0");
                        itemsDisplayed.Add(combi.Container[i], obj);
                    }
                }
            }
        }
    }

    public void clickResetBtn() {
        Debug.Log("here");
        isClickedReset = true;
        UpdateDisplay();
    }

    public Vector3 GetPosition(int i)
    {
        //if (i < 3)
            return new Vector3(-63f + 62 * i, 18f, 0f);
        //else
           //return new Vector3(-5.07f + 2 * (i - 6), -1f, 0f);
    }
}

