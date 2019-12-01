using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class skipBtn : MonoBehaviour
{
    static public int missionNum = 0;
    int tutorialNum = 0;
    int tutorialCnt = 4;

    public GameObject instInven;
    public GameObject instItemsGrab;
    public GameObject instCombination;
    public GameObject instLife;
    public GameObject missionInstPanel;
    public Text missionInstText;

    string[] missionExplain = {
        "mission 1",
        "mission 2",
        "mission 3"
    };

    void Start()
    {
        if(missionNum == 0) {
            missionNum += 1;
            showTutorial(tutorialNum);
        }
        else {
            showMission(missionNum);
            missionNum += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void showMission(int i) {
        // missionInstText = missionInstPanel.GetComponent<Text>();
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
        }
        tutorialNum += 1;
    }

    public void tutorialBtn() {
        if(tutorialNum == tutorialCnt) {
            instLife.SetActive(false);
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
