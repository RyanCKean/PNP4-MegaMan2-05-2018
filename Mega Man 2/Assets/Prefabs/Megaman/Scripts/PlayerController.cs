using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*Name: Lyndon Jones
 *Date: 1/17/18
 *Credit: Project & Portfolio 4 - MegaMan 2 group project
 *Purpose: Basic player movements, health, and damage taking                               */

//Name: Anthony Downie
//Date: 3/7/18
//Credit: Richard Altreche
//Purpose: Basic player movements; Movement left/right, jump, and climb ladders

//Name: Robert O'Mara
//Date: 3/13/18
//Purpose: Added animations and player life controls to interact with pickups

//Name: Anthony Downie
//Date: 3/12/18
//Credit: Unity Health HUD 
//  Link: https://unity3d.com/learn/tutorials/projects/survival-shooter/health-hud
//Purpose: To teach me how the canvas and UI Images work

//Name: Anthony Downie
//Date: 3/12/18
//Credit: Kevin Huang
//Purpose: To rewrite gravity to make mega man jump more like the original

//Name: Robert O'Mara
//Date: 3/15/18
//Purpose: Disabled Jumping portions. Jumping will now be handled via the Jump.cs and JumpGravity.cs


public enum Direction {LEFT, RIGHT}
public class PlayerController : MonoBehaviour {

	public float speed = 5.0f;
	public float climbUpSpeed = .01f;
	public float ClimbDownSpeed = -.02f;
    public bool isGrounded = true;
    public float jumpPower = 6000;
    public float jumpHeight;
    public float apex;
    public const int health = 100; // holds constant starting health value
    public int currentHealth = health; //holds current health
	public int energy;
    public RectTransform healthBar;
    public bool facingRight = true;
	public int playerLifes = 2;
    private Vector2 movementVector;
	private Animator anim;
	public bool onLadder = false;


    private void Awake()
    {
        currentHealth = health;
    }

    private Rigidbody2D rb;
    private Direction playerDirection = Direction.RIGHT;
    public void TakeDamage(int amount) // handles taking damage

    {
        currentHealth -= amount;
        
        if (currentHealth <= 0)
        {
            currentHealth = 0;
           
        }
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y); // keeps healthbar updated
    }

    public Direction PlayerDirection { 
     get {
        return playerDirection;
    }
}

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        Cursor.visible = false;
        healthBar.sizeDelta = new Vector2(100, healthBar.sizeDelta.y);
		anim = GetComponent<Animator> ();
		climbUpSpeed = 5;
		ClimbDownSpeed = -5f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        MovePlayer();
		LifeCheck ();
		LadderMovement ();
		EnergyCheck ();
		//Jump ();

        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
	}

    void MovePlayer()
    {
 	
        float xSpeed = (Input.GetAxis("Horizontal"));

        if (isGrounded == true)
        {
            movementVector = new Vector2(xSpeed * speed, rb.velocity.y);
            rb.velocity = movementVector;
        }
//        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
//        {
//            rb.AddForce(transform.up * jumpPower);
//            isGrounded = false;
//            apex = transform.position.y + jumpHeight;
//            anim.SetBool("isJumping", true);
//        }
//            if (isGrounded == false && transform.position.y >= apex)
//            {
//                rb.AddForce(transform.up * -jumpPower);
//            }

		if (xSpeed > 0 && !facingRight) 
		{
			playerDirection = Direction.RIGHT;
			Flip ();
		} else if (xSpeed < 0 && facingRight) 
		{
			playerDirection = Direction.RIGHT;
			Flip ();
		} 
		//Robert Checks if the movement is 0. If so then stop running animation
		else if (xSpeed == 0) 
		{
			anim.SetBool ("isRunning", false);
		}
		//Robert Checks if there is movement happening. If so then play the running animation.
		if (xSpeed > 0 || xSpeed < 0) {
			anim.SetBool ("isRunning", true);
		}
		if (isGrounded == false) {
			anim.SetBool ("isJumping", true);
		} else {
			anim.SetBool ("isJumping", false);
		}
    }

//    void Jump()
//    {
//        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
//        {
//			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 10), ForceMode2D.Impulse);
//            rb.AddForce(transform.up * jumpPower);
//            isGrounded = false;
//            apex = transform.position.y + jumpHeight;
//
//            if (transform.position.y >= apex)
//            {
//                rb.AddForce(transform.up * -jumpPower);
//            }
//
//            rb.velocity = movementVector;
//            anim.SetBool ("isJumping", true);
//        }
//    }

	void LadderMovement(){
		
		if (onLadder == true && Input.GetKey(KeyCode.W)) {
			transform.Translate (0, climbUpSpeed*Time.deltaTime , 0);
		}
		if (onLadder == true && Input.GetKey(KeyCode.S)) {
			transform.Translate (0, ClimbDownSpeed*Time.deltaTime , 0);

		}
	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
		GameObject.Find ("Blaster").GetComponent<Transform> ().Rotate (0, -180, 0);
    }

    void OnCollisionEnter2D(Collision2D _collision)
    {
		isGrounded = true;
        if (_collision.gameObject.tag=="Enemy")
        {
            _collision.gameObject.GetComponent<EnemyData>();
            EnemyData enemyData = _collision.gameObject.GetComponent<EnemyData>();
           currentHealth -= enemyData.PhysicalDamage;
        }

        if (_collision.gameObject.tag == "Killzone")
        {
            currentHealth = 0;
        }
        if (_collision.gameObject.tag == "Projectile")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), _collision.gameObject.GetComponent<Collider2D>());
        }
		if (_collision.gameObject.tag == "Environment")
        {
			anim.SetBool ("isJumping", false);
		}
    }

	void OnCollisionExit2D(Collision2D _collision)
    {
		if (_collision.gameObject.tag == "Pickup") 
		{
			isGrounded = true;
			anim.SetBool ("isJumping", false);
		}
		if (_collision.gameObject.tag == "Environment") 
		{
			isGrounded = false;
		}
       
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 5.0f);
        if (hit.collider != null)
        {

        }
    }
	void LifeCheck()
	{
		if (health <= 0)
		{
			playerLifes = playerLifes - 1;
		}
		if(playerLifes <= 0)
		{
			SceneManager.LoadScene("GameOver");
		}
	}
	void EnergyCheck(){
		if (energy < 0) {
			energy = 0;
		}
		if (energy > 100) {
			energy = 100;
		}
	}
}
