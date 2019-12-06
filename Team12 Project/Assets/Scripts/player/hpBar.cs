using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        healthBar.fillAmount = health / maxHealth;
        healthText.text = ((int)(health)).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Fuse.isMissionFail) {
            Debug.Log("mission clear value is false");
            health -= 20;
            
            healthBar.fillAmount = health / maxHealth;
            healthText.text = ((int)(health)).ToString();
            UnityEngine.Debug.Log("health = " + healthText.text);
            
            Fuse.isMissionFail = false;

            if(health == 0) {
                // TODO : playerDie 씬으로 넘기기!
                SceneManager.LoadScene("PlayerDie");
                Debug.Log("game end!! - Die");
            }else {
                Debug.Log("Mission Fail but no die");
                // TODO : Mission Combination Fail Panel 띄워주기
            }
        }
        if(Fuse.isMissionSuccess) {
            Debug.Log("Mission Success in HP Bar!!");
            SceneManager.LoadScene("missionSuccess");
        }
    }
}
