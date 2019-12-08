using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fuse : MonoBehaviour
{
    public static int[][] One = new int[12][]
    {
    new int[] {0, 16, 18} , new int[] {6, 16, 18} , new int[] {2, 16, 18} ,
    new int[] {13, 16, 18}, new int[] {4, 19, 13}, new int[] {0, 16}, new int[] {6, 16},
    new int[] {0, 4, 19} , new int[] {4, 6, 19} , new int[] {2, 4, 19} , 
    new int[] {2, 16}, new int[] {13, 16}
    };
    public static int[][] Two = new int[10][]
    {
    new int[] {18, 20, 21} , new int[] {18, 20, 22} , new int[] {20, 21} ,
    new int[] {20, 22} , new int[] {20, 23, 24}, new int[] {6, 18, 21}, new int[] {6, 18, 22},
    new int[] {21}, new int[] {6, 22}, new int[] {6, 23, 24}
    };
    public static int[][] Three = new int[7][]
    {
    new int[] {3, 8, 9} , new int[] {3, 7, 9} , new int[] {8, 9, 25} , new int[] {8, 9, 25},
    new int[] {3, 9, 26}, new int[] {9, 25, 26}, new int[] {16}
    };

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
            if (skipBtn.missionNum == 1) //소망이가 바꿔쓰면되는 부분
            {
                for (int i = 0; i < 12; i++)
                {
                    pass = CheckListEquals(CombinationObject.ContList, One[i]);
                    if (pass == true)
                    {
                        Debug.Log("success @ O @");
                        isMissionSuccess = true;
                        break;
                    }
                }
                if (pass == false)
                {
                    Debug.Log("fail T _ T");
                    isMissionFail = true;
                }
            }
            else if (skipBtn.missionNum == 2) //소망이가 바꿔쓰면되는 부분
            {
                for (int i = 0; i < 10; i++)
                {
                    pass = CheckListEquals(CombinationObject.ContList, Two[i]);
                    if (pass == true)
                    {
                        Debug.Log("success @ O @");
                        isMissionSuccess = true;
                        break;
                    }
                }
                if (pass == false)
                {
                    Debug.Log("fail T _ T");
                    isMissionFail = true;
                }
            }
            else if (skipBtn.missionNum == 3) //소망이가 바꿔쓰면되는 부분
            {
                for (int i = 0; i < 7; i++)
                {
                    pass = CheckListEquals(CombinationObject.ContList, Three[i]);
                    if (pass == true)
                    {
                        Debug.Log("success @ O @");
                        isMissionSuccess = true;
                        break;
                    }
                }
                if (pass == false)
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

    bool CheckListEquals(List<int> value, int[] tempValue)
    {
        bool isEqual = true;

        if (object.ReferenceEquals(value, tempValue))
        {
            isEqual = true; //같은 인스턴스면 true
        }
        else if (value == null || tempValue == null || value.Count != tempValue.Length)
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
