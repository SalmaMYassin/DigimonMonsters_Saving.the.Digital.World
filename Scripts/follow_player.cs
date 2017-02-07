using UnityEngine;
using System.Collections;

public class follow_player : EnemyController
{
    public Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
	}
}
