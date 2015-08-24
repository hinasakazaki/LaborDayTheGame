using UnityEngine;
using System.Collections;

public class ShroomScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("RemovedEffects", 10f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void RemovedEffects(){
		this.gameObject.SetActive (false);
	}

}
