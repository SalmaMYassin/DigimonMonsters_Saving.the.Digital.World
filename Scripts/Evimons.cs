using UnityEngine;
using System.Collections;

public class Evimons : MonoBehaviour {

	public bool IsFacingRight;
	public float speed=1;
	private float x, y, z;

	// Use this for initialization
	void Start () {
		x = transform.localScale.x;
		y = transform.localScale.y;
		z = transform.localScale.z;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void flip()
	{

		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		IsFacingRight = !IsFacingRight;
	}


}
