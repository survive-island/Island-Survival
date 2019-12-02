using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fuse : MonoBehaviour
{
    public static bool isResetting = false;
    public static bool isFusing = false;

    public GameObject failUI;
    public GameObject successUI;
    public CombinationObject combi;

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Reset()
    {
        if (isResetting)
        {
            Time.timeScale = 1f;
            isResetting = false;
        }
        else
        {
            ClearAll();
        }
    }

    public void Compose()
    {
        if (isFusing)
        {
            Time.timeScale = 1f;
            isFusing = false;
        }
        else
        {
            //조건문에 따라 판별해
            Time.timeScale = 0f;
            isFusing = true;
        }
    }

    private void ClearAll()
    {
        // 아까 만든거 저장해둔 리스트에서 모두 삭제해줍니다.
        for (int i = 0; i < 3; i++)
        {
            Destroy(combi.Container[i].item);
            combi.Container.RemoveAt(i);
        }
        combi.Container.Clear();

        Time.timeScale = 0f;
        isResetting = true;
    }
}