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
        if (skipBtn.missionNum == 1)
        {
            contentText.text = "<color=black>You must get a [wood] to build a tree house !!\n(You can get wood from: fence, board, log, crate)</color> ";
        }
        else if (skipBtn.missionNum == 2)
        {
            contentText.text = "<color=black>If you have some trees,\n you need [objects to fix them].\n (You can fix tree with: Nail and Hammer, Wood)</color>";
        }
        else if (skipBtn.missionNum == 3)
        {
            contentText.text = "<color=black>These are possible combinations.\n tree + rope \n tree + nail + hammer \n tree + rope + leaf \n=> nail and hammer should be together to use.</color>";
        }
        else
        {
            contentText.text = "else mission ";
        }
    }

    public void NormalText(GameObject panel)
    {
        Debug.Log("hint num : " + skipBtn.missionNum);
        panel.SetActive(true);
        leveltext.text = "Normal Hint";
        if (skipBtn.missionNum == 1)
        {
            contentText.text = "<color=black>If you have some trees,\n you need [objects to fix them].\n (You can fix tree with: Nail and Hammer, Wood)</color>";
        }
        else if (skipBtn.missionNum == 2)
        {
            contentText.text = "<color=black>If you have some trees, you need [objects to fix them[.\n (You can fix tree with: Nail and Hammer, Wood)</color>";
        }
        else if (skipBtn.missionNum == 3)
        {
            contentText.text = "<color=black>These are possible combinations.\n tree + rope \n tree + nail + hammer \n tree + rope + leaf \n=> nail and hammer should be together to use.</color>";
        }
        else
        {
            contentText.text = "else mission ";
        }
    }

    public void HardText(GameObject panel)
    {
        Debug.Log("hint num : " + skipBtn.missionNum);
        panel.SetActive(true);
        leveltext.text = "Hard Hint";
        if (skipBtn.missionNum == 1)
        {
            contentText.text = "<color=black>These are possible combinations.\n* tree + rope \n*  tree + nail + hammer \n*  tree + rope + leaf \n=> nail and hammer should be together to use.</color>";
        }
        else if (skipBtn.missionNum == 2)
        {
            contentText.text = "<color=black>If you have some trees,\n you need [objects to fix them].\n (You can fix tree with: Nail and Hammer, Wood)</color>";
        }
        else if (skipBtn.missionNum == 3)
        {
            contentText.text = "<color=black>These are possible combinations.\n* tree + rope \n*  tree + nail + hammer \n*  tree + rope + leaf \n=> nail and hammer should be together to use.</color>";
        }
        else
        {
            contentText.text = "else mission ";
        }
    }
}
