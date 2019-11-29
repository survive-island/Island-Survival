using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNavigate : MonoBehaviour
{
    public int playerSpeed = 2;

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
     }
    }
}
