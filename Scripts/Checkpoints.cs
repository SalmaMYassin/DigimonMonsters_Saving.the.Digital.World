using UnityEngine;
using System.Collections;

public class Checkpoints : MonoBehaviour {


    private Animator anim;
    private bool Activated = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Activated", Activated);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Activated = true;
            FindObjectOfType<LevelManager>().CurrentCheckpoint = this.gameObject;

        }
    }

}


