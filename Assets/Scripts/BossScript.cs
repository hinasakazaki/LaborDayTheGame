using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {
	protected Animator animator;
	public static bool porn = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();			
	}
	public void SetWatchingPorn(){
		porn = true;
	}
	// Update is called once per frame
	void Update () {
		if (porn) {
			animator.SetBool ("porn", true);
		}
	}
	public bool isWatchingPorn(){
		return porn;
	}
}
