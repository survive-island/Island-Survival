using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseBtn : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject Button;
 
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
        pauseMenuUI.SetActive(false);
        Button.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Button.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
