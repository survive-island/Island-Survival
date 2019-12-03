using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class messageState : MonoBehaviour
{
    public static int messageNum=0;
    public TextMeshProUGUI text;

    void Start()
    {
        switch (messageNum)
        {
            case 0:
                text.text = "";
                break;
            case 1:
                text.text = "You can't get this fish \nwithout any equipment!\n\nClick the message to skip.";
                break;
            case 2:
                text.text = "Your HP gets down in water!";
                break;
            case 3:
                text.text = "You only have one object to combinate!";
                break;
        }
    }
}
