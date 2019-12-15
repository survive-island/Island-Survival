using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class messageState : MonoBehaviour
{
    public Text text;

    void Start()
    {
        text.text = "You can't get this fish \nwithout a <color=red>Spear!</color>\nSpears : <color=blue>blue</color> on minimap!\nClick the message to skip.";
    }
}
