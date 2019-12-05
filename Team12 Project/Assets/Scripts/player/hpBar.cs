using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBar : MonoBehaviour
{
    Image healthBar; // Reference to an image to flash on the screen
    public Text healthText;
    float maxHealth = 100f;
    public static float health; // current health the player has.

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
