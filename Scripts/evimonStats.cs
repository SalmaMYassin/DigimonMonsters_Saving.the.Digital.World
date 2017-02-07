using UnityEngine;
using System.Collections;

public class evimonStats : MonoBehaviour {
	public int damage;
	public float health;
	public GameObject bullet;
	public Transform firePoint;
	float timeStart=0;
	float time=3; 
	bool shoot=false;
	bool walk=true;
	private Animator anim;

	bool dead=false;
	bool hit=false;
	public bool IsFacingRight;
	public float speed=1;
	private float x, y, z;

    private playerStats player;
    public GameObject collectible;

    
    // Use this for initialization
    void Start () {

		anim = GetComponent<Animator>();
		x = transform.localScale.x;
		y = transform.localScale.y;
		z = transform.localScale.z;

        player = FindObjectOfType<playerStats>();
    }
	
	// Update is called once per frame
	void Update () {

		if (shoot) {
			if (this.gameObject.tag == "Tayrannmon") {
				
				timeStart += 1.5F;
				shooting ();
				if (timeStart >= time) {
					shoot = false;
					walk = true;
					timeStart = 0;
				}
			} 
			if (this.gameObject.tag == "Matadormon") {
				
				timeStart += Time.deltaTime;
				if (timeStart >= time) {
					shoot = false;
					walk = true;
					timeStart = 0;
					anim.SetBool ("turn", shoot);
					damage = 15;
					
				}
			}
			if (this.gameObject.tag == "Ev1L4") {
				
				timeStart += Time.deltaTime;
				if (timeStart >= time) {
					shoot = false;
					walk = true;
					timeStart = 0;
					anim.SetBool ("kill", shoot);
					damage = 20;
					
				}
			}
			if (this.gameObject.tag == "Ev2Lv4") {
				
				timeStart += Time.deltaTime;
				if (timeStart >= time) {
					shoot = false;
					walk = true;
					timeStart = 0;
					anim.SetBool ("turn", shoot);
					damage = 15;
					
				}
			}
		
			
		} 

		 if (walk) {


			timeStart += Time.deltaTime;
			if (timeStart >= time) {
				shoot = true;
				walk = false;
				timeStart = 0;
				if (this.gameObject.tag == "Matadormon") {
					anim.SetBool ("turn", shoot);
					damage = 20;
				}
				if (this.gameObject.tag == "Ev1L4") {
					anim.SetBool ("kill", shoot);
					damage = 30;
				}
				if (this.gameObject.tag == "Ev2Lv4") {
					anim.SetBool ("turn", shoot);
					damage = 30;
				}
			}
		
		}
		
		if (dead) {
			damage=0;
			anim.SetTrigger ("Dead");
			timeStart += Time.deltaTime;
			if (timeStart >= time) {
				shoot=false;

                if (this.gameObject.tag == "Matadormon")
                {
                    player.exp += 15;
                    player.score += 20;
                }
                if (this.gameObject.tag == "Tayrannmon")
                {
                    player.exp += 20;
                    player.score += 25;
                }
                    if (this.gameObject.tag == "Ev1L4")
                {
                    Instantiate(collectible, transform.position, transform.rotation);
                    FindObjectOfType<EndOfScene>().key = true;
                    player.exp += 50;
                    player.score += 100;
                }
                if (this.gameObject.tag == "Ev2Lv4")
                {
                    player.exp += 30;
                    player.score += 50;
                }
                Destroy (this.gameObject);
			}
		}
		if (hit) {
			anim.SetBool ("Hit", hit);
			timeStart += 1;
			if (timeStart >= time) {
				hit=false;
				anim.SetBool ("Hit",hit);
				timeStart=0;
				
			}
		}

	}



	public void Takedamage(int damage) {

			this.health -= damage;
			
			
			if (this.health < 0)
			{
				this.health = 0;
				
			}
			
			if (this.health == 0)
			{
				dead=true;
				
			}

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag=="Player"){

			FindObjectOfType<playerStats>().Takedamage(this.damage);
		}

		else if (other.tag == "FireBullet") {
			hit = true;
			Takedamage(FindObjectOfType<FireBulletController>().damage);
		}

		else if (other.tag == "wallE")
		{
			flip();
		}
		
		
	}
	void FixedUpdate(){
		if (IsFacingRight)
		{
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
		}
		else
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

	

	}

	public void shooting()
	{ 

			Instantiate (bullet, firePoint.position, firePoint.rotation);

		
	}
	public void flip()
	{
		
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		IsFacingRight = !IsFacingRight;
	}


}
