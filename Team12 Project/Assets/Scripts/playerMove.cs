using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    public int playerSpeed = 1;
    public Text status;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
        }

        if (count == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            count = 0;
        }
    }
}
