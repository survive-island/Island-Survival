using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapIcon : MonoBehaviour
{
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
