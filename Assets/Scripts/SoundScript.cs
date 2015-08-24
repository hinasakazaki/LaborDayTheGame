using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {
	public AudioClip death;
	public AudioClip shroom;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void playDeath(){
		this.gameObject.GetComponent<AudioSource>().PlayOneShot(death);
	}
	public void playShroom(){
		this.gameObject.GetComponent<AudioSource>().PlayOneShot(shroom);
	}

}
