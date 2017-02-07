using UnityEngine;
using System.Collections;

public class movable : MonoBehaviour {

    
	public bool IsFacingRight;
    public float speed;

   

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

    }
	public void flip()
	{ 
		if(this.gameObject.tag=="Horizontal"){
		IsFacingRight = !IsFacingRight;
		
		}
		if(this.gameObject.tag=="Vertical"){
			IsFacingRight = !IsFacingRight;
		
	}
		}
	void FixedUpdate()
	{
		if(this.gameObject.tag=="Horizontal"){
		if (IsFacingRight)
		{
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
		}
		else
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
		}
		if(this.gameObject.tag=="Vertical"){
			if (IsFacingRight)
			{
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,-speed);
			}
			else
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,speed);
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "wall")
			{
				flip();
			}
	
	}
}
