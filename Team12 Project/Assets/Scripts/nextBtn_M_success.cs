using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class nextBtn_M_success : MonoBehaviour
{
    public GameObject nextBtn;
    public GameObject completeBtn;
    public Text msgText;

    public GameObject M1Obj;
    public GameObject M2Obj;
    public GameObject M3Obj;

    public Image canvasImg;
    public Sprite S1;
    public Sprite S2;
    public Sprite S3;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale=1;
        if(skipBtn.missionNum == 3) {
            nextBtn.SetActive(false);
            completeBtn.SetActive(true);
            msgText.text = "Mission Complete!";
            skipBtn.missionNum = 0;
        }

        switch(skipBtn.missionNum) {
            case 1 :
                M3Obj.SetActive(false);
                M1Obj.SetActive(true);
                canvasImg.sprite = S1;
                break;
            case 2 :
                M1Obj.SetActive(false);
                M2Obj.SetActive(true);
                canvasImg.sprite = S2;
                break;
            case 3 :
                M2Obj.SetActive(false);
                M3Obj.SetActive(true);
                canvasImg.sprite = S3;
                break;
            default :
                M1Obj.SetActive(true);
                canvasImg.sprite = S1;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}