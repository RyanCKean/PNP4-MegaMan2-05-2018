using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Name: Lyndon Jones
 *Date: 1/17/18
 *Credit: Project & Portfolio 4 - MegaMan 2 group project
 *Purpose: Sets damage, speed, and direction for bullet prefab                            

*Name:Robert O'Mara
*Date 3/16/18
*Purpose: change the function to allow the bullet to move correctly with the new player controller
*/
//*Name:Robert O'Mara
//*Date 3/23/18
//*Purpose: added the cleanup function to delete the object after a delay
//*


public class Bullet : MonoBehaviour
{

    public Direction bulletDirection = Direction.RIGHT;
    public float speed = 5.0f;
	private float Nspeed;
    public int damage = 2;
	public bool isFacingRight;
	private int destroyTime =6;

    private Transform _transform;



    void Start() {
        _transform = transform;
		Nspeed = speed * -1;
    }

	void Awake() {
		FaceCheck ();
	}

    // Update is called once per frame
    void Update() {
		isFacingRight = GameObject.Find ("MegaManV3").GetComponent<PlayerController> ().facingRight;
        MoveBullet();  
		CleanUp ();
	}


    // Causes the bullet to move at a set speed
    void MoveBullet() {

		//if (isFacingRight == true) {
			//transform.Translate (speed * Time.deltaTime, 0, 0);
			
        int moveDirection = bulletDirection == Direction.LEFT ? -1 : 1;
        float translate = moveDirection * speed * Time.deltaTime;
        _transform.Translate(translate, 0, 0);
		//}
//		if (isFacingRight == false) {
//			transform.Translate (Nspeed*Time.deltaTime, 0, 0);
//		}
    }
	void FaceCheck(){
		if (isFacingRight == true) {
			bulletDirection = Direction.RIGHT;
		} else {
			bulletDirection = Direction.LEFT;
		}
	}

    // Allows bullet to collide with Enemy tag
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.collider.tag == "Enemy") {
            collision.collider.gameObject.GetComponent<EnemyData>().Damage(damage);
            Destroy(gameObject);
        }
    }

	void CleanUp(){
		Destroy (gameObject, destroyTime);
	}
}


