using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {
	public GameObject SceneController;
	public GameObject DIALOG;
	bool hitStealingWorker;
	bool hitNormalWorker;
	bool hitSlackingWorker;
	bool hitNormalBoss;
	bool hitSlackingBoss;
	Collider2D collCur;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown ((KeyCode.Q))) && collCur != null ) {
			if (hitNormalWorker | hitSlackingWorker | hitStealingWorker){
				SceneController.GetComponent<SceneControlScript>().Death();
				collCur.GetComponent<WorkerScript>().death ();
			}
			if (hitNormalBoss | hitSlackingBoss){
				SceneController.GetComponent<SceneControlScript>().BossDeath();
				collCur.GetComponent<BossScript>().death();
			}
			//kill
		}
		if (Input.GetKeyDown ((KeyCode.F)) && !QuotaScript.MushGone) {
			if (hitNormalWorker | hitSlackingWorker | hitStealingWorker){
				SceneController.GetComponent<SceneControlScript>().Feed();
				collCur.GetComponent<WorkerScript> ().feed ();
			}
			if (hitNormalBoss | hitSlackingBoss){
				SceneController.GetComponent<SceneControlScript>().Feed();
				collCur.GetComponent<BossScript>().feed();
			}
		}
	
	}
	void OnTriggerEnter2D(Collider2D coll) {
		collCur = coll;
		hitSlackingBoss = false;
		hitNormalBoss = false;
		hitSlackingWorker = false;
		hitStealingWorker = false;
		hitNormalWorker = false;
		if (coll.name.Contains ("metaldetector")) {
			SceneController.GetComponent<SceneControlScript> ().EnterBuilding ();
		} else if (coll.name == "Lydia") {
			DIALOG.GetComponent<DialogScript> ().setLydia ();
		} else if (coll.name == "Brian") {
			DIALOG.GetComponent<DialogScript> ().setBrian ();

		} else if (coll.name.Contains ("boss")) {
			if (coll.gameObject.GetComponent<BossScript> ().isWatchingPorn ()) {
				hitSlackingBoss = true;
				DIALOG.GetComponent<DialogScript> ().setPornBoss ();
			} else if (!BossScript.dead){
				hitNormalBoss = true;
				DIALOG.GetComponent<DialogScript> ().setBoss ();
			}
		} else if (coll.name.Contains ("Worker")) {
			if (coll.gameObject.GetComponent<WorkerScript> ().isSlacking ()) {
				DIALOG.GetComponent<DialogScript> ().setSlackingWorker ();
				hitSlackingWorker = true;
			} else if (coll.gameObject.GetComponent<WorkerScript> ().isStealing ()) {
				DIALOG.GetComponent<DialogScript> ().setStealingWorker ();
				hitStealingWorker = true;
			} else if (!(coll.gameObject.GetComponent<WorkerScript>().isDead())) {
				DIALOG.GetComponent<DialogScript> ().setNormalWorker ();
				hitNormalWorker = true;
			}
		} else {
			hitNormalWorker = false;
			hitSlackingWorker = false;
			hitStealingWorker = false;
			hitNormalBoss = false;
			hitSlackingBoss = false;
		}
	}
}
