using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerStats : MonoBehaviour {

    public int health = 100;
	public int exp;
	public int lives = 5 ;
    public int score;

	public float ImmuneTime = 0;
	public float ImuneDuration = 2;
	public bool IsImmune = false;
	public float FlickringTime = 0;
	public float FlickringDuration;

	private SpriteRenderer sp;
	public AudioClip GameOver;

	public GameObject EvolvedAugmon;
	public GameObject EvolvedGabumon;
	public int Evidence;
	public int collectible;
	public int Thunder;
	Vector3 pos;
	Vector3 pos2;
	int character;
	public AudioClip evolved;
	Collider2D box;


	// Use this for initialization
	void Start () {
		pos = new Vector3 (4,0,0);
		pos2 = new Vector3 (0,4,0);
		int z = 0;
		sp = this.gameObject.GetComponent<SpriteRenderer>();
		PlayerPrefs.SetInt("Evidence",z) ;
		character=PlayerPrefs.GetInt("Character");
		health=PlayerPrefs.GetInt("Health");
		lives=PlayerPrefs.GetInt("Lives");
		exp = PlayerPrefs.GetInt ("exp");
        score = PlayerPrefs.GetInt("Score");
        collectible = PlayerPrefs.GetInt("collectible");
    }
	
	// Update is called once per frame
	void Update () {
		if (IsImmune)
		{
			SpriteFlicker();
			ImmuneTime += Time.deltaTime;
			if (ImmuneTime >= ImuneDuration)
			{
				sp.enabled = true;
				IsImmune = false;
			}
		}
		if(exp >= 100){
			evolve();
		}
		PlayerPrefs.SetInt ("Lives",lives);
		PlayerPrefs.SetInt("Evidence",Evidence) ;
		PlayerPrefs.SetInt("collectible",collectible) ;
		PlayerPrefs.SetInt("Thunder",Thunder) ;
		PlayerPrefs.SetInt("exp",exp) ;
        PlayerPrefs.SetInt("Score", score);


    }

	public void Takedamage(int damage) {
		if (IsImmune == false)
		{
			this.health -= damage;
			PlayerPrefs.SetInt("Health",health);
			
			if (this.health < 0)
			{
				this.health = 0;
				PlayerPrefs.SetInt("Health",health);
				
			}
			if (this.health == 0 && lives > 0)
			{
				lives--;
				this.health = 100;
				PlayerPrefs.SetInt("Health",health);
				PlayerPrefs.SetInt("Lives",lives);
				FindObjectOfType<LevelManager>().Respawn();
                
			}
			if (lives == 0)
			{
				AudioManager.instance.BG.Stop();
				Application.LoadLevel("GameOver");
				AudioManager.instance.playSingle(GameOver);
				Destroy(this.gameObject);
				
				
			}
		}
		IsImmune = true;
		ImmuneTime = 0;
	}
	
	public void SpriteFlicker()
	{
		if (FlickringTime < FlickringDuration)
		{
			FlickringTime += Time.deltaTime;
			
		}
		else if (FlickringTime >= FlickringDuration)
		{
			sp.enabled = !sp.enabled;
			FlickringTime = 0;
		}
	}
	public void evolve(){
        int check = PlayerPrefs.GetInt("evolved");

        if (check != 0 && character == 1)
        {

            AudioManager.instance.playSingle(evolved);
            int e = 0;
            PlayerPrefs.SetInt("evolved", e);
            Instantiate(EvolvedAugmon, transform.position, transform.rotation);
            Destroy(this.gameObject);

        }


        else if (check != 0 && character == 2)
        {
            AudioManager.instance.playSingle(evolved);
            int e = 0;
            PlayerPrefs.SetInt("evolved", e);
            Instantiate(EvolvedGabumon, transform.position, transform.rotation);
            Destroy(this.gameObject);

        }


    }
}
