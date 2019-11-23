using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class audio : MonoBehaviour
{
    public static audio Instance;

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("playGame"))
        {
            Destroy(gameObject);
            return;
        }
    }
}
