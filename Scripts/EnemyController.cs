using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    private float x, y, z;

    private playerStats player;

    private FireBulletController bullet;
    private float health = 10;
    private int evidamage = 10;
    private int flameBunchDamage = 15;
    private int pinoBunchDamage = 20;

    public float moveSpeed;
    private bool moveRight;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;

    private bool notAtEdge;
    public Transform edgeCheck;

    private bool playerNear;
    public Transform playerCheck;
    public LayerMask whatIsPlayer;

    float time = 0.6f;

    private Animator anim;

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();

        x = transform.localScale.x;
        y = transform.localScale.y;
        z = transform.localScale.z;

        player = FindObjectOfType<playerStats>();
    }
	
	// Update is called once per frame
	void Update () {
       

        anim.SetBool("PlayerNear", playerNear);
       
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        playerNear = Physics2D.OverlapCircle(playerCheck.position, wallCheckRadius, whatIsPlayer);

        if (hittingWall || !notAtEdge)
            moveRight = !moveRight;

        if (moveRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            Flip();

        }
        else
        { 
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            Flip();
        }
 

    }

    public void Flip()
    {
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            transform.localScale = new Vector3(x, y, z);
        }
        if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            transform.localScale = new Vector3(-x, y, z);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FireBullet")
        {
            bullet = FindObjectOfType<FireBulletController>();
            Takedamage(bullet.damage);
            if (health != 0)
                anim.SetTrigger("Hit");
        }

        if (other.tag == "Player" && !playerNear)
        {

            player.Takedamage(evidamage);
        }

        if (other.tag == "Player" && playerNear)
        {
            if(this.gameObject.tag == "Flamemon")
            {
                player.Takedamage(flameBunchDamage);
            }
               
            if(this.gameObject.tag == "Pinocchimon")
            {
                player.Takedamage(pinoBunchDamage);
            }
               
        }
        if (other.tag == "Flamemon" || other.tag == "Pinocchimon")
            moveRight = !moveRight;
    }

    public void Takedamage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            health = 0;
        }

        if (health == 0)
        {
            anim.SetTrigger("K.O.");
            moveSpeed = 0;
            GetComponent<EnemyController>().GetComponent<BoxCollider2D>().enabled = false;

            if (this.gameObject.tag == "Flamemon")
            {
                player.exp += 5;
                player.score += 10;
            }

            if (this.gameObject.tag == "Pinocchimon")
            {
                player.exp += 10;
                player.score += 15;
            }

            StartCoroutine("Die",time);     
        }
    }

    IEnumerator Die(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

}
