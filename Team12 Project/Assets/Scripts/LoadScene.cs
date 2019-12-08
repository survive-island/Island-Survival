using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public InventoryObject inventory;
    public static bool loadcheck = false; //(다원추가)

    public void LoadingScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        loadcheck = true; //(다원추가)
        Debug.Log(skipBtn.missionNum);
        inventory.Load();
    }
}
