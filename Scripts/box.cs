using UnityEngine;
using System.Collections;

public class box : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (this.gameObject.tag == "box!"&& other.tag=="Player") {

			Destroy(this.gameObject);
		
		}
		if (this.gameObject.tag == "boxX"&& other.tag=="FireBullet") {
			
			Destroy(this.gameObject);
			
		}

	}
}
