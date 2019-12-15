using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SoundManager.instance.ButtonClickSound();
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApp()
    {
        SoundManager.instance.ButtonClickSound();
        Application.Quit();
    }
}
