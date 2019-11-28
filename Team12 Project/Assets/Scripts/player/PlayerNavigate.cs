using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNavigate : MonoBehaviour
{
    public int playerSpeed = 2;
    Camera cam = GameObject.Find("minimap").GetComponent<Camera>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {       
        Vector3 minimapY = new Vector3(0.0f, 10.0f, 0.0f);
        // Assign value to Camera position
        if(Input.GetButton("Fire1"))    {
        	transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
            cam.transform.localPosition = new Vector3(0, 10, 0);
            cam.transform.localRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
     }
    }
}
