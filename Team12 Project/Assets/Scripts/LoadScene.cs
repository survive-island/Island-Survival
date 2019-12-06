using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public InventoryObject inventory;

    public void LoadingScene(string sceneName)
    {
        skipBtn.missionNum = 2;
        SceneManager.LoadScene(sceneName);
        inventory.Load();
    }
}
