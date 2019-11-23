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
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InvantorySlot : MonoBehaviour,IPointerEnterHandler 
{

    [Tooltip("Change this to alter the normal and selected apperance of the invantory slot")]public Sprite baseSoltImage, activeSlotImage;
    [Tooltip("Should be set, leave me alone please")]public Image itemImage;
    [Tooltip("Should be set, leave me alone please")]public Text slotText;
    [Tooltip("Should be set, leave me alone please")]public int slotID;
    [HideInInspector]public Invantory owningInvantory;
    
	// Use this for initialization
	void Start ()
	{
	    slotText = GetComponentInChildren<Text>();
	    SetItem(null, 0);
	}
	
    public void ToggleSlot(bool active)
    {
        if (active)
            GetComponent<Image>().sprite = activeSlotImage;
        else
            GetComponent<Image>().sprite = baseSoltImage;
    }

    public void SetItem(Sprite image, int quantity)
    {
        if (image == null)
            itemImage.enabled = false;
        else if (itemImage.enabled == false)
            itemImage.enabled = true;
        itemImage.sprite = image;
        slotText.text = quantity == 0 ? "" : quantity.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
     {
         owningInvantory.ToggleSlotAtID(slotID);
     }
}
