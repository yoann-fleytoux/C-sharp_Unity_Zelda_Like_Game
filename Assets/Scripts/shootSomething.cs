using UnityEngine;
using System.Collections;

public class shootSomething : MonoBehaviour {

		public GameObject projectile;
		public Vector2 velocity;
		bool canShoot= true;
		public Vector2 offset;
		public float cooldown;
		private PlayerController thePlayer;


	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController>();

		

	}
	
	// Update is called once per frame
	void Update () {
	
				if (Input.GetKeyDown (KeyCode.Space) && canShoot || Input.GetKeyDown("joystick button 0") && canShoot ) {

						

						
						if(thePlayer.lastMove.x == 0 &&  thePlayer.lastMove.y == 0){
							offset = new Vector2(0.5f,0f);
							GameObject go = (GameObject)	Instantiate (projectile,(Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
							go.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity.x * transform.localScale.x, 0);
						}else{
							offset = new Vector2(thePlayer.lastMove.x,thePlayer.lastMove.y);
							GameObject go = (GameObject)	Instantiate (projectile,(Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
							go.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity.x * transform.localScale.x * thePlayer.lastMove.x, velocity.y * transform.localScale.y * thePlayer.lastMove.y);
						}
						

						StartCoroutine (CanShoot());

						//GetComponent<Animator> ().SetTrigger ("shoot");

				}


	}

	
		IEnumerator CanShoot()
		{
				canShoot = false;
				yield return new WaitForSeconds (cooldown);
				canShoot = true;
		}
}