using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour {
    public Slider expBar;
    private playerStats player;
    // Use this for initialization
    void Start () {
        expBar = GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update () {
        expBar.value = PlayerPrefs.GetInt("exp");
    }
}
