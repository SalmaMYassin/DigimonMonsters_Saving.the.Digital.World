using UnityEngine;
using System.Collections;

public class spikes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			if(this.gameObject.tag=="Spikes"){

				FindObjectOfType<playerStats>().Takedamage(5);
			}
			if(this.gameObject.tag=="water"){
				FindObjectOfType<LevelManager>().Respawn();
				FindObjectOfType<playerStats>().Takedamage(100);

			}
		}

			
	}
}
