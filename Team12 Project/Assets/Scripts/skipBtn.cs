using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class skipBtn : MonoBehaviour
{
    static public int missionNum = 0;
    static public int tutorialNum = 0;
    int tutorialCnt = 5;

    public GameObject instInven;
    public GameObject instItemsGrab;
    public GameObject instCombination;
    public GameObject instLife;
    public GameObject hintPanel;
    public GameObject missionInstPanel;
    public Text missionInstText;

    string[] missionExplain = {
        "\nMISSION 1\nYou drifted on an uninhabited island.\nTry your best to survive here!",
        "\nMISSION 2\nYou built a house, but a sudden storm destroyed the house. T_T\nYou went into a nearby cave to avoid the rain.",
        "\nMISSION 3\nNow you got a fire and can use it. \nThe rain stopped, and you got out of the cave!"
    };

    void Start()
    {
        Debug.Log("start mission num = " + missionNum);
        if (missionNum == 0)
        { 
            missionNum += 1;
            Debug.Log("tutorial call");
            showTutorial(tutorialNum);
            // Debug.Log("mission Num = " + missionNum);
        }
        else {
            missionNum += 1;
            showMission(missionNum);
        }
        Debug.Log("end mission num = " + missionNum);
    }

    void showMission(int i) {
        // missionInstText = missionInstPanel.GetComponent<Text>();
        instInven.SetActive(false);
        missionInstPanel.SetActive(true);
        missionInstText.text = missionExplain[i - 1];
    }

    void showTutorial(int i) {
        switch(i) {
            case 0 :
                instInven.SetActive(true);
                break;
            case 1:
                instInven.SetActive(false);
                instItemsGrab.SetActive(true);
                break;
            case 2:
                instItemsGrab.SetActive(false);
                instCombination.SetActive(true);
                break;
            case 3:
                instCombination.SetActive(false);
                instLife.SetActive(true);
                break;
            case 4:
                instLife.SetActive(false);
                hintPanel.SetActive(true);
                break;
        }
        tutorialNum += 1;
    }

    public void tutorialBtn() {
        if(tutorialNum == tutorialCnt) {
            hintPanel.SetActive(false);
            instInven.SetActive(false);
            missionInstPanel.SetActive(true);
            showMission(missionNum);
        }
        else {
            showTutorial(tutorialNum);
        }
    }

    public void ChangeScene(string sceneName) {
        // go to play scene!
        SceneManager.LoadScene(sceneName);
    }
}