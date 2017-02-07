using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    private playerStats player;
    Text text;
    
    void Start () {
        player = FindObjectOfType<playerStats>();
        text = GetComponent<Text>();
        text.text = "" + player.score;
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "" + player.score;
	}
}
