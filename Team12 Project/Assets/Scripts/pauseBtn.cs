using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseBtn : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool isSettings = false;
    public static bool isCombination = false;

    public GameObject pauseMenuUI;
    public GameObject defaultPanelUI;
    public GameObject settingCanvasUI;
    public GameObject combiPanelUI;
 
    // Use this for initialization
    void Start () {

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Resume();
    }

    public void changeSettings() {
        if(isSettings) {
            playMode();
        }
        else {
            settingMode();
        }
    }

    void settingMode() {
        defaultPanelUI.SetActive(false);
        settingCanvasUI.SetActive(true);
        Time.timeScale = 0f;
        isSettings = true;

    }

    void playMode() {
        defaultPanelUI.SetActive(true);
        settingCanvasUI.SetActive(false);
        combiPanelUI.SetActive(false);
        Time.timeScale = 1f;
        isSettings = false;
        isCombination = false;
    }

    public void pausePlay() {
            if(GameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
    }

    void Resume() {
        defaultPanelUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() {
        defaultPanelUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void combinationStart()
    {
        if(isCombination)
        {
            playMode();
        }
        else
        {
            combiMode();
        }
    }
    void combiMode()
    {
        defaultPanelUI.SetActive(false);
        combiPanelUI.SetActive(true);
        Time.timeScale = 0f;
        isCombination = true;
    }
}