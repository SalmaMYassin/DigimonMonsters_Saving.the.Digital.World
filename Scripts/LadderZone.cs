using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour {

    private PlayerController player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Player")
        {
            player.onLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.onLadder = false;
        }
    }
}
