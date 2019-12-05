using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fuse : MonoBehaviour
{
    public static List<int> oneList = new List<int>();
    public static List<int> twoList = new List<int>();

    public GameObject failUI;
    public GameObject successUI;
    public CombinationObject combi;
    public GameObject combiPanel;

    public void Start()
    {
        //board, fence
        oneList.Add(0);
        oneList.Add(2);
        //fence, fish, spear
        twoList.Add(2);
        twoList.Add(3);
        twoList.Add(8);
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
  
    public void Compose()
    {
        bool pass = false;
        
        pass = CheckListEquals(CombinationObject.ContList, oneList);
        if (pass == true)
        {
            Debug.Log("success!");
        }
        else
        {
            pass = CheckListEquals(CombinationObject.ContList, twoList);
            if (pass == true)
            {
                Debug.Log("success!!");
            }
            else
            {
                Debug.Log("fail......");
            }
        }
    }

    bool CheckListEquals(List<int> value, List<int> tempValue)
    {
        bool isEqual = true;

        if (object.ReferenceEquals(value, tempValue))
        {
            //같은 인스턴스면 true
            isEqual = true;
            Debug.Log("equal is true");
        }
        else if (value == null || tempValue == null || value.Count != tempValue.Count)
        {
            //어느 한 쪽이 null이거나, 요소의 수가 다를 때는 false
            isEqual = false;
            Debug.Log("eqaul is false");
        }
        else
        {
            //1개 1개씩 요소 비교
            for (int i = 0; i < value.Count; i++)
            {
                //ary1의 요소의 Equals메소드에서, ary2의 요소와 같은지를 비교
                if (!value[i].Equals(tempValue[i]))
                {
                    //1개라도 같지 않은 요소가 있으면 false
                    isEqual = false;
                    break;
                }
            }
        }
        return isEqual;
    }
}