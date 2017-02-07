using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HealthUI : MonoBehaviour {
	public Slider healthBar;
    private playerStats player;
	
	void Start () {
        player = FindObjectOfType<playerStats>();
        healthBar.value = player.health;
        healthBar = GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update () {
        if (player.health < 0)
            healthBar.value = 0;
		healthBar.value = PlayerPrefs.GetInt("Health");
	}

}
