using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Name: Lyndon Jones
 *Date: 1/17/18
 *Credit: Project & Portfolio 4 - MegaMan 2 group project
 *Purpose: Instantiates bullet prefab   
 *
 **Name: Robert O'Mara
 *Date: 03/14/18
 *Credit: www.unity3d.com/learn/tutorials/topics/scripting/instantiate
 *Purpose: Instantiates bullet prefab in the proper direction and trigger player animation
 */
public class Weapon : MonoBehaviour {

    public GameObject bullet;
    public GameObject metalWeapon;

    private PlayerController playerMovement;
    private Transform blaster;
	private Animator anim;

	// Use this for initialization
	void Start ()
    {
        playerMovement = GetComponent<PlayerController>();
		anim = GetComponent<Animator> ();

        blaster = gameObject.transform.Find("Blaster");
	}
	
	//Instantiates the bullets
	void Update ()
    {
		if (Input.GetKeyDown (KeyCode.K)) {
			var tBullet = Instantiate (bullet, blaster.transform.position, blaster.transform.rotation) as GameObject;
			tBullet.GetComponent<Bullet> ().bulletDirection = playerMovement.PlayerDirection;
			anim.SetBool ("isShooting", true);
		} 
		if (Input.GetKeyDown (KeyCode.L)) {
			var tMetalWeapon = Instantiate (metalWeapon, blaster.transform.position, blaster.transform.rotation) as GameObject;
			tMetalWeapon.GetComponent<Bullet> ().bulletDirection = playerMovement.PlayerDirection;
			anim.SetBool ("isShooting", true);
		}
		if (Input.GetKeyUp (KeyCode.K)) {
			anim.SetBool ("isShooting", false);
		}
		if (Input.GetKeyUp (KeyCode.L)) {
			anim.SetBool ("isShooting", false);
		}
    }
}
