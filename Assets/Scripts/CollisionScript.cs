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
			DIALOG.GetComponent<DialogScript> ().setLydia ();
		} else if (coll.name == "Brian") {
			DIALOG.GetComponent<DialogScript> ().setBrian ();
		} else if (coll.name == "boss") {
			if (coll.gameObject.GetComponent<BossScript>().isWatchingPorn()){
				DIALOG.GetComponent<DialogScript>().setPornBoss();
			} else {
				DIALOG.GetComponent<DialogScript> ().setBoss ();
			}
		} else if (coll.name.Contains ("Worker")) {
			if (coll.gameObject.GetComponent<WorkerScript>().isSlacking()){
				DIALOG.GetComponent<DialogScript> ().setSlackingWorker ();
			}else if (coll.gameObject.GetComponent<WorkerScript>().isStealing()){
				DIALOG.GetComponent<DialogScript> ().setStealingWorker ();
			}else {
				DIALOG.GetComponent<DialogScript> ().setNormalWorker ();
			}
		}
	}
}
