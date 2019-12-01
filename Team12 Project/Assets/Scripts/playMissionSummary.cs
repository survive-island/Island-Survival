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
        switch(skipBtn.missionNum) {
            case 1 :
                summary.text = "A cold wave is coming.\nProtect yourself from the cold!";
                break;
            case 2 :
                summary.text = "mission 2 summary";
                break;
            case 3 :
                summary.text = "mission 3 summary";
                break;
        }
        numberImg.sprite = imgSlots[skipBtn.missionNum - 1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
