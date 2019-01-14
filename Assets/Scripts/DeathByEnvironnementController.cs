using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathByEnvironnementController : MonoBehaviour {


	public float waitToReload;
	private bool reloading;
	
	private GameObject thePlayer;
	private CameraController theCamera;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
