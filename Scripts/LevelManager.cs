using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject CurrentCheckpoint;
	public Transform Enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Respawn()
	{
		FindObjectOfType<PlayerController>().transform.position = CurrentCheckpoint.transform.position;
	}
	public void RespawnEnemy()
	{
		Instantiate(Enemy, transform.position, transform.rotation);
	}

}
