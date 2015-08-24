using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {
	protected Animator animator;
	public static bool bossesLeft = true;
	public static bool porn = false;
	public static bool dead = false;
	public bool clone = false;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();			
	}
	public void SetWatchingPorn(){
		if (!dead) {
			porn = true;
		}
	}
	public void Refresh(){
		bool bossesLeft = true;
		bool porn = false;
		bool dead = false;
		animator = GetComponent<Animator> ();
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;

	}
	// Update is called once per frame
	void Update () {
		if (dead) {
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		} else if (!dead) {
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		} 
		if (porn && !dead) {
			animator.SetBool ("porn", true);
			if (clone) {
				foreach (Transform child in gameObject.transform) {
					if (child.name == "porn") {
						child.gameObject.SetActive (true);
					}
				}
			}
		} else {
			animator.SetBool ("porn", false);
		}
	}
	public bool isWatchingPorn(){
		return porn;
	}
	public void feed(){
		animator.SetBool ("porn", false);
		porn = false;
		foreach (Transform child in gameObject.transform) {
			if (child.name == "porn"){
				child.gameObject.SetActive(false);
			} else if (child.name == "!"){
				child.gameObject.SetActive(true);
			}
		}
	}
	public void death(){
		dead = true;
		porn = false;
		animator.SetBool ("porn", false);

		if (bossesLeft) {
			Invoke ("replace", 20f);
		}
		foreach (Transform child in gameObject.transform) {
			if (child.name == "porn"){
				child.gameObject.SetActive(false);
			} else if (child.name == "!"){
				child.gameObject.SetActive(false);
			} else if (child.name == "bloodpool"){
				child.gameObject.SetActive(true);
			}
		}
	}
	void replace(){
		dead = false;
		foreach (Transform child in gameObject.transform) {
			if (child.name == "porn"){
				child.gameObject.SetActive(false);
			} else if (child.name == "!"){
				child.gameObject.SetActive(false);
			} else if (child.name == "bloodpool"){
				child.gameObject.SetActive(false);
			}
		}
	}
}
