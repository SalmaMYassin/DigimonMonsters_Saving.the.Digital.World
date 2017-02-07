using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private float x, y, z;
    private float moveVelocity;

    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private bool doubleJumped;

    private Animator anim;

    public Transform firePoint;
    public GameObject FireBullet;
	public GameObject ThunderBullet;
	public bool FirePowerup=false;
	float startTime=0;
	float time=10;
	Vector3 pos;

	public GameObject Augmon;
	public GameObject Gabumon;

    public bool onLadder;
    public float climbSpeed;
    private float climbVelocity;
    private float gravityStore;

	public int character; // 1 Augmon , 2 Gabumon
	public AudioClip jump;
	public AudioClip shoot;


    void Start () {
        x = transform.localScale.x;
        y = transform.localScale.y;
        z = transform.localScale.z;

        anim = GetComponent<Animator>();
		pos = new Vector3 (0.5F,0.05F,0);
        gravityStore = GetComponent<Rigidbody2D>().gravityScale;

		character=PlayerPrefs.GetInt ("Character");

		if(this.gameObject.name=="Agumon"){

			if(character==2){
				
				Destroy(this.gameObject);
				Instantiate(Gabumon,transform.position,transform.rotation);
				
			}
		

		}
	
    }

    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    
    void Update () {

        if (grounded)
            doubleJumped = false;

        anim.SetBool("Grounded", grounded);
        

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
			AudioManager.instance.playSingle(jump);
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
        }

        moveVelocity = 0f;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {

            //GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = moveSpeed;
            Flip();
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = -moveSpeed;
            Flip();
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        if (Input.GetKeyDown(KeyCode.Z))
		{
			AudioManager.instance.playSingle(shoot);
            anim.SetTrigger("Fire");

            Instantiate(FireBullet, firePoint.position-pos, firePoint.rotation);
			if(FirePowerup){
				Instantiate(FireBullet, firePoint.position+(2*pos), firePoint.rotation);
			}
				

        }
		if(FirePowerup){

			startTime+=Time.deltaTime;
			if(startTime>=time){

				FirePowerup=false;
				startTime=0;
			}

		}
		if (Input.GetKeyDown(KeyCode.X))
		{

			if(FindObjectOfType<playerStats>().Thunder>0){
			Instantiate(ThunderBullet, firePoint.position-pos, firePoint.rotation);
			}
			AudioManager.instance.playSingle(shoot);
			
		}

        if(onLadder)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;

            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x , climbVelocity);

        }

        if (!onLadder)
        {
            GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        }
    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
    
    public void Flip()
    {
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            transform.localScale = new Vector3(x, y, z);
        }
        if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            transform.localScale = new Vector3(-x, y,z);
        }
        
    }

   void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }
}
