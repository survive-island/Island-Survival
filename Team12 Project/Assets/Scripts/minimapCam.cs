using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapCam : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position;
    }
}
