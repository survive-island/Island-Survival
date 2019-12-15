using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playMissionSummary : MonoBehaviour
{
    public Image numberImg;
    public Text summary;
    public Sprite[] imgSlots;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInventory.haveStick = false;
        switch(skipBtn.missionNum) {
            case 1 :
                summary.text = "\nYou need a place to live. \nMake a tree house and take a rest.";
                break;
            case 2 :
                summary.text = "\nYou are shivering in the cold. \nMake a fire and try to become warm!";
                break;
            case 3 :
                summary.text = "\nYou're starting to get hungry. \nBake the food, and fill up your hunger!";
                break;
        }
        numberImg.sprite = imgSlots[skipBtn.missionNum - 1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
