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
        if(Input.GetButton("Fire1"))    {
        	transform.position = transform.position + Camera.main.transform.forward * playerSpeed *        
                 Time.deltaTime;
     }
    }
}
