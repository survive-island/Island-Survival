using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public GameObject item;
    public GameObject myHand;
    bool inHands = false;

    Collider itemCol;
    Rigidbody itemRb;

    Camera cam;
    public float handPower;

    // Start is called before the first frame update
    void Start()
    {
        itemCol = item.GetComponent<Collider>();
        itemRb = item.GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            if (!inHands) //if held in hands
            {
                itemRb.velocity = Vector3.zero;
                itemCol.isTrigger = true;
                itemRb.useGravity = false;

                item.transform.SetParent(myHand.transform);
                item.transform.localPosition = new Vector3(0.003902235f, 0.0007025391f, 0.03649994f);//put it under arms
                itemRb.constraints = RigidbodyConstraints.FreezePositionX |
                    RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ; //freeze object's position. 
            }
            /*else
            {
                itemRb.velocity = cam.transform.rotation * Vector3.forward * handPower;
                itemCol.isTrigger = false;
                itemRb.useGravity = true;
                item.transform.SetParent(null);

                this.GetComponent<PlayerGrab>().enabled = false;
            }*/ //throwing objects.
            inHands = !inHands;
        }
    }
}
