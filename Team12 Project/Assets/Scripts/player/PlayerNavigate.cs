using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNavigate : MonoBehaviour
{
    public int playerSpeed = 2;
    public GameObject rainEffect;

    Vector3[] startPosition = {
        new Vector3 (21.0f, 153.0f, -122.0f),
        new Vector3 (-208.0f, 17.0f, 453.0f),
        // new Vector3 (-204.0f, 33.0f, 317.0f),
        new Vector3 (-160.3791f, 62.60879f, 207.8396f),
    };

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition[skipBtn.missionNum % 3];
        if(skipBtn.missionNum == 2) {
            rainEffect.SetActive(true);
        }else {
            rainEffect.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {       
        Vector3 minimapY = new Vector3(0.0f, 10.0f, 0.0f);
        // Assign value to Camera position
        if(Input.GetButton("Fire1"))    {
        	transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
     }
    }
}
