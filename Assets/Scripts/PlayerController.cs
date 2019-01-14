using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	public int moveSpeed;
	private Animator anim;
	private bool playerMoving;
	public Vector2 lastMove;
	private Rigidbody2D myRigidBody;
	private static bool playerExists;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		myRigidBody = GetComponent<Rigidbody2D>();
		
		if(!playerExists){
			playerExists=true;
			DontDestroyOnLoad(transform.gameObject);
		}else{
			Destroy(gameObject);
		}
		
	}
	
	// Update is called once per frames
	void Update () {
		float moveX=Input.GetAxisRaw("Horizontal");
		float moveY=Input.GetAxisRaw("Vertical");
		
		if(moveX==moveY){
			playerMoving=false;
			//myRigidBody.velocity = new Vector2(0,0);
		}else{
			playerMoving=true;
		}
		if (moveX !=0){
			//transform.Translate(new Vector3(moveX*moveSpeed*Time.deltaTime,0f,0f));
			myRigidBody.velocity = new Vector2(moveX*moveSpeed,myRigidBody.velocity.y);
			lastMove=new Vector2(moveX,0f);
		}
		
		if (moveY != 0){
			//transform.Translate(new Vector3(0f,moveY*moveSpeed*Time.deltaTime,0f));
			myRigidBody.velocity = new Vector2(myRigidBody.velocity.x,moveY*moveSpeed);
			lastMove=new Vector2(0f,moveY);
		}
		
		if(moveX < 0.5f && moveX > -0.5f)
			myRigidBody.velocity = new Vector2(0,myRigidBody.velocity.y);
		
		if(moveY < 0.5f && moveY > -0.5f)
			myRigidBody.velocity = new Vector2(myRigidBody.velocity.x,0);
		
		anim.SetFloat("moveX",moveX);
		anim.SetFloat("moveY",moveY);
		anim.SetFloat("lastMoveX",lastMove.x);
		anim.SetFloat("lastMoveY",lastMove.y);
		anim.SetBool("playerMoving",playerMoving);
		
	}
}
