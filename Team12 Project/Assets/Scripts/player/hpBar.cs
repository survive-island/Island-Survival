using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBar : MonoBehaviour
{
    Image healthBar;
    public Text healthText;
    float maxHealth = 100f;
    public static float health;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image> ();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        healthText.text = ((int)(health)).ToString();
        UnityEngine.Debug.Log(healthText.text);
    }
}
