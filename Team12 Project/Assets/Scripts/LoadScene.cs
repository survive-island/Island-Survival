using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public InventoryObject inventory;
    public static bool loadcheck = false; //(다원추가)

    public void Loading1_Scene(string sceneName)
    {
        skipBtn.missionNum = 1;
        SceneManager.LoadScene(sceneName);
        inventory.Load();
        loadcheck = true; //(다원추가)
    }
    public void Loading2_Scene(string sceneName)
    {
        skipBtn.missionNum = 2;
        SceneManager.LoadScene(sceneName);
        inventory.Load();
        loadcheck = true; //(다원추가)
    }
    public void Loading3_Scene(string sceneName)
    {
        skipBtn.missionNum = 3;
        SceneManager.LoadScene(sceneName);
        inventory.Load();
        loadcheck = true; //(다원추가)
    }
}
