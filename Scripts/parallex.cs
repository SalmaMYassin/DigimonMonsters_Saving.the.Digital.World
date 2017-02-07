using UnityEngine;
using System.Collections;

public class parallex : MonoBehaviour {


	public Transform[] Backgrounds;
	public float parallaxScale;
	public float parallaxReductionFactor;
	public float smoothing;
	private Vector3 lastPosition;
	// Use this for initialization
	void Start () {
		lastPosition = transform.position;

	}
	
	// Update is called once per frame
	void Update () {


		var parallax = (lastPosition.x - transform.position.x) * parallaxScale;
		for (var i = 0; i < Backgrounds.Length; i++) {

			var newXPosition = Backgrounds [i].position.x + parallax * (i * parallaxReductionFactor + 1);
			Vector3 newPos = new Vector3 (newXPosition, Backgrounds [i].transform.position.y, Backgrounds [i].transform.position.z);
			
			Backgrounds [i].position = Vector3.Lerp (Backgrounds [i].position, newPos, smoothing * Time.deltaTime);
		}
		lastPosition = transform.position;
	}
	}
