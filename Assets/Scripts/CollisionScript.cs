using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {
	public GameObject SceneController;
	public GameObject DIALOG;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.name.Contains ("metaldetector")) {
			SceneController.GetComponent<SceneControlScript> ().EnterBuilding ();
		} else if (coll.name == "Lydia") {
			DIALOG.GetComponent<DialogScript>().setLydia();
		} else if (coll.name == "Brian") {
			DIALOG.GetComponent<DialogScript>().setBrian();
		}
	}
}
