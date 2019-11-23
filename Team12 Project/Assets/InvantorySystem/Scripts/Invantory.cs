/*
Copyright 2016 Frederic Babord

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

*/

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Invantory : MonoBehaviour
{
    [Tooltip("Resets the entire invantory system to have 0 items picked up. This is useful for testing in editor and for restarting each game")]
    public bool resetInvantoryOnStart = true;
    private List<InvantoryObject> objectsInInvantory;
    private List<GameObject> invantorySlots;
    [Tooltip("Should be set, leave me alone please")]public GameObject invantoryRoot;
    private GameObject invantoryObjectTemplate;
    [Tooltip("The number of slots for the system to generate")]public int maxInvantorySlots = 8;
    private int currentlySelectedItem = 0;
    private List<InvantoryObject> invantoryItems = new List<InvantoryObject>();
    [Tooltip("Enables the tooltip text in the UI, otherwise this will be ignored")][SerializeField]private bool useTooltip;
    [Tooltip("Should be set, leave me alone please")][SerializeField]private Text tooltipText;

    void Start()
    {
        objectsInInvantory = new List<InvantoryObject>();
        invantorySlots = new List<GameObject>();
        invantoryObjectTemplate = GameObject.Find("InvantoryTemplate");
        Rect rect = invantoryObjectTemplate.GetComponent<RectTransform>().rect;
        rect.width = rect.height;
        invantoryObjectTemplate.GetComponent<RectTransform>().sizeDelta = new Vector2(rect.width, rect.height);
        invantoryObjectTemplate.GetComponent<RectTransform>().position = Vector3.zero;

        InitGUI();
        for (var i = 0; i < invantorySlots.Count; ++i)
            invantorySlots[i].GetComponent<InvantorySlot>().ToggleSlot(false);
        invantorySlots[currentlySelectedItem].GetComponent<InvantorySlot>().ToggleSlot(true);
        invantoryItems = Resources.LoadAll<InvantoryObject>("InvantoryItems").ToList();
        if(resetInvantoryOnStart)
            ResetInvantory();
        if(useTooltip)
        {
            tooltipText.gameObject.SetActive(true);
        }
    }

    // Update the input logic here to change how the the slots get toggled and the selected item is used.
    void Update()
    {
        // Cycle through the in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            ToggleSlot(true);
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            ToggleSlot(false);

        if (Input.GetButtonDown("Submit"))
            UseSelectedItem();
        
    }

    private void ToggleSlot(bool goUp)
    {
        invantorySlots[currentlySelectedItem].GetComponent<InvantorySlot>().ToggleSlot(false);
        if (goUp)
            currentlySelectedItem++;
        else
            currentlySelectedItem--;
        currentlySelectedItem = Mathf.Clamp(currentlySelectedItem, 0,invantorySlots.Count-1);
        invantorySlots[currentlySelectedItem].GetComponent<InvantorySlot>().ToggleSlot(true);
        if(useTooltip)
        {
            if(currentlySelectedItem >= 0 && currentlySelectedItem < objectsInInvantory.Count)
                tooltipText.text = objectsInInvantory[currentlySelectedItem].objectTooltip;
            else
                tooltipText.text = "";
        }
    }

    public void ToggleSlotAtID(int id)
    {
        invantorySlots[currentlySelectedItem].GetComponent<InvantorySlot>().ToggleSlot(false);
        currentlySelectedItem = id;
        currentlySelectedItem = Mathf.Clamp(currentlySelectedItem, 0,invantorySlots.Count-1);
        invantorySlots[currentlySelectedItem].GetComponent<InvantorySlot>().ToggleSlot(true);
        if(useTooltip)
        {
            if(currentlySelectedItem >= 0 && currentlySelectedItem < objectsInInvantory.Count)
                tooltipText.text = objectsInInvantory[currentlySelectedItem].objectTooltip;
            else
                tooltipText.text = "";
        }
    }

    private void InitGUI()
    {
        float padding = 5.0f;

        bool even = maxInvantorySlots%2 == 0;
        int slotCounter = 0;

        if (even)
        {
            GameObject tempGameObject = Instantiate(invantoryObjectTemplate);
            tempGameObject.transform.SetParent(invantoryRoot.transform);
            tempGameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
            var oldPos = tempGameObject.GetComponent<RectTransform>().position;
            oldPos.x -= (tempGameObject.GetComponent<RectTransform>().rect.width /2 + 2.5f);
            tempGameObject.GetComponent<RectTransform>().position = oldPos;
            invantorySlots.Add(tempGameObject);
            slotCounter++;
        }

        for (int i = 0; i < maxInvantorySlots / 2; i++)
        {
            GameObject tempGameObject = Instantiate(invantoryObjectTemplate);
            tempGameObject.transform.SetParent(invantoryRoot.transform);
            tempGameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;

            var oldPos = tempGameObject.GetComponent<RectTransform>().position;
            oldPos.x += 2 * i * tempGameObject.GetComponent<RectTransform>().rect.width + (i * padding) + (even ? (tempGameObject.GetComponent<RectTransform>().rect.width / 2) + 2.5f : 0);
            tempGameObject.GetComponent<RectTransform>().position = oldPos;
            int tempid = slotCounter;
            invantorySlots.Add(tempGameObject);
            slotCounter++;
        }

        for (int i = 1; i < maxInvantorySlots / 2; i++)
        {
            GameObject tempGameObject = Instantiate(invantoryObjectTemplate);
            tempGameObject.transform.SetParent(invantoryRoot.transform);
            tempGameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;

            var oldPos = tempGameObject.GetComponent<RectTransform>().position;
            oldPos.x -= 2 * ((i * tempGameObject.GetComponent<RectTransform>().rect.width) + (i * padding) + (even ? (tempGameObject.GetComponent<RectTransform>().rect.width / 2) + 2.5f : 0));
            tempGameObject.GetComponent<RectTransform>().position = oldPos;
            int tempid = slotCounter;
            invantorySlots.Add(tempGameObject);
            slotCounter++;
        }

        invantorySlots = invantorySlots.OrderBy(a => a.GetComponent<RectTransform>().position.x).ToList();
        for(int i = 0; i < invantorySlots.Count; ++i)
        {
            invantorySlots[i].GetComponent<InvantorySlot>().slotID = i;
            invantorySlots[i].GetComponent<InvantorySlot>().owningInvantory = this;
            AddListener(invantorySlots[i].GetComponent<Button>(), i);
        }
        invantoryObjectTemplate.SetActive(false);
    }

    void AddListener(Button b, int value) 
    {
        b.onClick.AddListener(() => UseItemAtID(value));
    }

    
    public void AddItemToInvanntory(CollectableObject obj)
    {
        if(objectsInInvantory.Count >= invantorySlots.Count)
            return;

        if (!objectsInInvantory.Find(x => x.itemLogic.name == obj.objectRefrence.name))
        {
            objectsInInvantory.Add(obj.objectRefrence);
            obj.objectRefrence.quantity = obj.quantity;
            invantorySlots[objectsInInvantory.Count - 1].GetComponent<InvantorySlot>().SetItem(obj.objectRefrence.objectImage, obj.quantity);
        }
        else
        {
            int idx = objectsInInvantory.FindIndex(x => x.itemLogic.name == obj.objectRefrence.name);
            objectsInInvantory[idx].quantity += obj.quantity;
            invantorySlots[idx].GetComponent<InvantorySlot>().SetItem(objectsInInvantory[idx].objectImage, objectsInInvantory[idx].quantity);
        }

        if(useTooltip)
        {
            if(currentlySelectedItem >= 0 && currentlySelectedItem < objectsInInvantory.Count)
                tooltipText.text = objectsInInvantory[currentlySelectedItem].objectTooltip;
            else
                tooltipText.text = "";
        }
    }

    public void UseSelectedItem()
    {
        if (currentlySelectedItem >= objectsInInvantory.Count || objectsInInvantory.Count == 0)
            return;

        objectsInInvantory[currentlySelectedItem].quantity--;
        objectsInInvantory[currentlySelectedItem].itemLogic.UseItem(transform, objectsInInvantory[currentlySelectedItem]);
        invantorySlots[currentlySelectedItem].GetComponent<InvantorySlot>().SetItem(objectsInInvantory[currentlySelectedItem].objectImage, objectsInInvantory[currentlySelectedItem].quantity);
        if (objectsInInvantory[currentlySelectedItem].quantity <= 0)
        {
            objectsInInvantory.RemoveAt(currentlySelectedItem);
            objectsInInvantory.TrimExcess();
            int i;
            
            for (i = currentlySelectedItem; i < objectsInInvantory.Count; i++)
            {
                invantorySlots[i].GetComponent<InvantorySlot>().SetItem(objectsInInvantory[i].objectImage, objectsInInvantory[i].quantity);
            }
            for (var i1 = i; i1 < invantorySlots.Count; i1++)
            {
                invantorySlots[i1].GetComponent<InvantorySlot>().SetItem(null, 0);
            }
        }
        if(useTooltip)
        {
            if(currentlySelectedItem >= 0 && currentlySelectedItem < objectsInInvantory.Count)
                tooltipText.text = objectsInInvantory[currentlySelectedItem].objectTooltip;
            else
                tooltipText.text = "";
        }
    }

    public void UseItemAtID(int id)
    {
        Debug.Log(id);
        if (id >= objectsInInvantory.Count || objectsInInvantory.Count == 0)
            return;

        objectsInInvantory[id].quantity--;
        objectsInInvantory[id].itemLogic.UseItem(transform, objectsInInvantory[id]);
        invantorySlots[id].GetComponent<InvantorySlot>().SetItem(objectsInInvantory[id].objectImage, objectsInInvantory[id].quantity);
        if (objectsInInvantory[id].quantity <= 0)
        {
            objectsInInvantory.RemoveAt(id);
            objectsInInvantory.TrimExcess();
            int i;
            
            for (i = id; i < objectsInInvantory.Count; i++)
            {
                invantorySlots[i].GetComponent<InvantorySlot>().SetItem(objectsInInvantory[i].objectImage, objectsInInvantory[i].quantity);
            }
            for (var i1 = i; i1 < invantorySlots.Count; i1++)
            {
                invantorySlots[i1].GetComponent<InvantorySlot>().SetItem(null, 0);
            }
        }
        if(useTooltip)
        {
            if(id >= 0 && id < objectsInInvantory.Count)
                tooltipText.text = objectsInInvantory[id].objectTooltip;
            else
                tooltipText.text = "";
        }
    }

    void ResetInvantory()
    {
        foreach (InvantoryObject invantoryObject in invantoryItems)
        {
            invantoryObject.quantity = 0;
        }
    }
}