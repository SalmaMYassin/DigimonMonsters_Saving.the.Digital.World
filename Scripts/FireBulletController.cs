using UnityEngine;
using System.Collections;

public class FireBulletController : MonoBehaviour
{	public float range;
	public float pos;
    public float speed;
	public int damage=5;
     PlayerController player;

    // Use this for initialization
    void Start()
	{ 

        player = FindObjectOfType<PlayerController>();
		pos = this.transform.position.x;
        if (player.transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
		float newpos = this.transform.position.x;
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
		if (Mathf.Abs(newpos - pos) >= range)
		{
			Destroy(this.gameObject);
		}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
            Destroy(gameObject);
    }

    
}
