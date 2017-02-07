using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour {

    public Sprite[] HeartSprites;

    public Image heartUI;


    private playerStats player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerStats>();
    }

    void Update()
    {
		heartUI.sprite = HeartSprites[PlayerPrefs.GetInt("Lives")];
    }
}
