using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody2D myRigidBody;
	
	private bool moving;
	
	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;
	
	private Vector3  moveDirection;
	
	public float waitToReload;
	private bool reloading;
	
	private GameObject thePlayer;
	private CameraController theCamera;
	
	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
		//timeBetweenMoveCounter = timeBetweenMove;
		//timeToMoveCounter = timeToMove;
		timeBetweenMoveCounter = Random.Range(timeBetweenMove*0.75f,timeBetweenMove*1.25f);
		timeToMoveCounter = Random.Range(timeToMove*0.75f,timeToMove*1.25f);
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		if (moving){
			timeToMoveCounter -= Time.deltaTime;
			myRigidBody.velocity = moveDirection;
			if(timeToMoveCounter < 0f){
				moving=false;
				//timeToMoveCounter = timeBetweenMove;
				timeToMoveCounter = Random.Range(timeToMove*0.75f,timeToMove*1.25f);
			}	
		}else{
			myRigidBody.velocity = Vector2.zero;
			timeBetweenMoveCounter -= Time.deltaTime;
			if(timeBetweenMoveCounter < 0f){
				//timeBetweenMoveCounter=timeToMove;
				timeBetweenMoveCounter = Random.Range(timeBetweenMove*0.75f,timeBetweenMove*1.25f);
				moving = true;
				moveDirection = new Vector3(Random.Range(-1f,1f)*moveSpeed, Random.Range(-1f,1f)*moveSpeed, 0f);
					
			}
		}
		if(reloading){
			waitToReload -= Time.deltaTime;
			if(waitToReload < 0){
				//Application.LoadLevel(Application.loadedLevel);
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				thePlayer.SetActive(true);
				
				thePlayer.transform.position=transform.position;				
				theCamera = FindObjectOfType<CameraController>();
				theCamera.transform.position=new Vector3(transform.position.x, transform.position.y, -10);
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.name == "Player"){
			other.gameObject.SetActive(false);
			reloading = true;
			thePlayer = other.gameObject;
		}
	}
}
