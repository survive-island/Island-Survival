using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fuse : MonoBehaviour
{
    public static List<int> oneList = new List<int>{ 0, 2 }; //board, fence
    public static List<int> twoList = new List<int> { 2, 3, 8 };  //fence, fish, spear

    public GameObject failUI;
    public GameObject successUI;
    public CombinationObject combi;
    public GameObject combiPanel;
    public static bool isMissionFail = false;
    public static bool isMissionSuccess = false;

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
  
    public void Compose()
    {
        bool pass = false;
        CombinationObject.ContList.Sort(); //순서대로 정렬

        if (CombinationObject.ContList.Count != 0)
        {
            pass = CheckListEquals(CombinationObject.ContList, oneList);
            if (pass == true)
            {
                Debug.Log("success @ O @");
                isMissionSuccess = true;
            }
            else
            {
                pass = CheckListEquals(CombinationObject.ContList, twoList);
                if (pass == true)
                {
                    Debug.Log("success @ O @");
                    isMissionSuccess = true;
                }
                else
                {
                    Debug.Log("fail T _ T");
                    isMissionFail = true;
                }
            }
        }
        else
        {
            Debug.Log("------------nothing");
        }
    }

    bool CheckListEquals(List<int> value, List<int> tempValue)
    {
        bool isEqual = true;

        if (object.ReferenceEquals(value, tempValue))
        {
            isEqual = true; //같은 인스턴스면 true
        }
        else if (value == null || tempValue == null || value.Count != tempValue.Count)
        {
            isEqual = false; //어느 한 쪽이 null이거나, 요소의 수가 다를 때는 false
        }
        else
        {
            for (int i = 0; i < value.Count; i++)
            {
                if (!value[i].Equals(tempValue[i]))
                {
                    isEqual = false; //1개라도 같지 않은 요소가 있으면 false
                    break;
                }
            }
        }
        return isEqual;
    }
}