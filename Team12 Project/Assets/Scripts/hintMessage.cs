using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hintMessage : MonoBehaviour
{
    public TextMeshProUGUI leveltext;
    public TextMeshProUGUI contentText;

    public void EasyText(GameObject panel)
    {
        Debug.Log("hint num : " + skipBtn.missionNum);
        panel.SetActive(true);
        leveltext.text = "Easy Hint";
        if (skipBtn.missionNum == 1) //1-easy
        {
            contentText.text = "<color=black>You must get a </color><color=red>wood</color><color=black> to build a tree house !!\n(You can get wood from: fence, board, log, crate)</color> ";
        }
        else if (skipBtn.missionNum == 2) //2-easy
        {
            contentText.text = "<color=black>We need </color><color=red>tools to make a fire.</color>\n<color=black>You can use: lighter, match box, 2-flint stones</color>";
        }
        else if (skipBtn.missionNum == 3) //3-easy
        {
            contentText.text = "<color=black>You need some </color><color=red>food to roast.</color>\n<color=black>food: mushroom, fish</color>";
        }
        else
        {
            contentText.text = "";
        }
    }

    public void NormalText(GameObject panel)
    {
        Debug.Log("hint num : " + skipBtn.missionNum);
        panel.SetActive(true);
        leveltext.text = "Normal Hint";
        if (skipBtn.missionNum == 1) //1-normal
        {
            contentText.text = "<color=black>If you have some trees,\n you need </color><color=red>objects to fix them.</color>\n <color=black>You can fix tree with: Nail and Hammer, rope</color>";
        }
        else if (skipBtn.missionNum == 2) //2-normal
        {
            contentText.text = "<color=black>We need </color><color=red>trees to make a fire on them.</color> \n<color=black>Trees : Twig, Log</color>";
        }
        else if (skipBtn.missionNum == 3) //3-normal
        {
            contentText.text = "<color=black>You need the </color><color=red>tools to grill food on fire. </color>\n <color=black>tools : spear, can, bucket</ color>";
        }
        else
        {
            contentText.text = "";
        }
    }

    public void HardText(GameObject panel)
    {
        Debug.Log("hint num : " + skipBtn.missionNum);
        panel.SetActive(true);
        leveltext.text = "Hard Hint";
        if (skipBtn.missionNum == 1) //1-hard
        {
            contentText.text = "<color=black>These are possible combinations.\n </color><color=red>tree + rope \n tree + nail + hammer \n tree + rope + leaf \n</color><color=black>=> nail and hammer should be together to use.</color>";
        }
        else if (skipBtn.missionNum == 2) //2-hard
        {
            contentText.text = "<color=black>These are possible combinations.\n </color><color=red>fire + tree + leaves \n fire + tree\n </color><color=black>=> you need two flint stones to make fire.\n=> you may make larger fire when you use leaves!</color>";
        }
        else if (skipBtn.missionNum == 3) //3-hard
        {
            contentText.text = "<color=black>These are possible combinations.\n </color><color=red>food + fire + tool</color>";
        }
        else
        {
            contentText.text = " ";
        }
    }
}
