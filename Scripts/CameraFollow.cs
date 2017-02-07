using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	float minPositionY  = -20; 
	float maxPositionY = 15; 
	float minPositionX  = -13; 
	float maxPositionX =30; 
	float x;
	float y;
	public Transform target;
	public float smoothing;
	private Vector3 offset;
	Vector3 newPos;
	Vector3 pos;
	Vector3 pos2;
	
	// Use this for initialization
	void Start () {
		offset = this.transform.position - target.position;

			pos = new Vector3 ((offset.x), 0, 0);
			pos2 = new Vector3 (0, (2 * offset.y), 0);


		
		
	}
	
	void FixedUpdate()
	{

		newPos = target.position + offset;
		if (newPos.x > minPositionX && newPos.x < maxPositionX && newPos.y > minPositionY && newPos.y < maxPositionY) {
		 
		
			transform.position = Vector3.Lerp (transform.position, newPos, smoothing * Time.deltaTime);
		} else if (newPos.x >= maxPositionX) {
			transform.position = Vector3.Lerp (transform.position, newPos - pos, smoothing * Time.deltaTime);
		}
		else if(newPos.y >= maxPositionY ) {
			transform.position = Vector3.Lerp (transform.position, newPos-pos2, smoothing * Time.deltaTime);
		}
		else if(newPos.x <=minPositionX ) {
			transform.position = Vector3.Lerp (transform.position, newPos+pos, smoothing * Time.deltaTime);
		}
		else if(newPos.y <= minPositionY ) {
			transform.position = Vector3.Lerp (transform.position, newPos+pos2, smoothing * Time.deltaTime);
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		target=FindObjectOfType<PlayerController>().transform;
	}

}
