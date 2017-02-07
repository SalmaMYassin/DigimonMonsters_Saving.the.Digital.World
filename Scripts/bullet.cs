using UnityEngine;
using System.Collections;

public class bullet : FireBulletController {


	evimonStats evimon;
	// Use this for initialization
	void Start () {
		
		pos = this.transform.position.x;
		evimon = FindObjectOfType<evimonStats> ();
		if (evimon.transform.localScale.x <0)
		{
			speed = -speed;
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}
		
	}
	

	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			FindObjectOfType<playerStats>().Takedamage(this.damage);
			Destroy(this.gameObject);
		}
	}



}
