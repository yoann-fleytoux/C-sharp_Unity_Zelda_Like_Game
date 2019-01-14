using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class AudioScripts : MonoBehaviour {
	
	private bool isItOn;
	public AudioClip musicLevel;
	public AudioClip musicTheEnd;
	AudioSource m_MyAudioSource;
	
	void Start () {
		m_MyAudioSource = GetComponent<AudioSource>();
		GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
         if (objs.Length > 1)
             Destroy(this.gameObject);
 
         DontDestroyOnLoad(this.gameObject);
		
		isItOn=true;
	}
	
	void Update () {
		if(isItOn && SceneManager.GetActiveScene().name == "theEnd"){
			//playEndMusic(); 
		}
	}
	public void playLevelMusic(){
		if(isItOn){
			m_MyAudioSource.Stop();
			m_MyAudioSource.clip = musicLevel;
			m_MyAudioSource.volume=0.1f;
			m_MyAudioSource.Play();
		}
	}
	
	public void playEndMusic(){
		m_MyAudioSource = GetComponent<AudioSource>();
		m_MyAudioSource.Stop();
		m_MyAudioSource.clip = musicTheEnd;
		m_MyAudioSource.volume=0.8f;
		m_MyAudioSource.Play();
	}
	
	
	public void OnToggle(){
		if(isItOn){
			isItOn=false;
			Off();
		}else{
			isItOn=true;
			On();
		}
	}
	
    private void Off() {
        AudioListener.volume = 0;
    }
	
	private void On() {
        AudioListener.volume = 1;
    }
}