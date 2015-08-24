using UnityEngine;
using System.Collections;

public class SceneControlScript : MonoBehaviour {
	public GameObject LandscapeEntry;
	public GameObject LandscapeFactory;
	public GameObject EndScreen;
	public GameObject Miz;
	public GameObject DIALOG;
	public GameObject MainPanel;
	public GameObject Clipboard;
	public GameObject worker;
	public GameObject boss;
	public GameObject cam;
	public GameObject title;
	public GameObject clock;

	public int scene; //1 = entry, 2 = factory 3= end

	// Use this for initialization
	void Start () {
		scene = 1;
	}
	public int getScene(){
		return scene;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.X) && scene == 2) {
			EndGame ();
		}
		if (scene == 2) {
			//count production
			bool[] deadArray = WorkerScript.dead;
			bool[] slackArray = WorkerScript.slacking;
			bool[] stealArray = WorkerScript.stealing;
			if (BossScript.dead | boss.GetComponent<BossScript> ().isWatchingPorn ()) {
				Clipboard.GetComponent<QuotaScript> ().bossNull ();
			}
			Clipboard.GetComponent<QuotaScript> ().updateWorkers (deadArray, slackArray, stealArray);
			
			//setting criminals
			int RandomInt = Random.Range (0, 1500);
			int RandomWorker = Random.Range (0, 7);
			if (RandomInt < 10 && !WorkerScript.stealing [RandomWorker]) {
				worker.GetComponent<WorkerScript> ().SetSlacking (RandomWorker);
			} else if (RandomInt > 1495 && !WorkerScript.slacking [RandomWorker]) {
				worker.GetComponent<WorkerScript> ().SetStealing (RandomWorker);
			}
			if (RandomInt > 1495) {
				boss.GetComponent<BossScript> ().SetWatchingPorn ();
			}

			string key = "8";
			if (Input.GetKey ((KeyCode.Keypad1)) | (Input.GetKey (KeyCode.Alpha1))) {
				key = "1";
			} else if (Input.GetKey ((KeyCode.Keypad2)) | (Input.GetKey (KeyCode.Alpha2))) {
				key = "2";
			} else if (Input.GetKey ((KeyCode.Keypad3)) | (Input.GetKey (KeyCode.Alpha3))) {
				key = "3";
			} else if (Input.GetKey ((KeyCode.Keypad4)) | (Input.GetKey (KeyCode.Alpha4))) {
				key = "4";
			} else if (Input.GetKey ((KeyCode.Keypad5)) | (Input.GetKey (KeyCode.Alpha5))) {
				key = "5";
			}
			if (key != "8") {
				foreach (Transform child in MainPanel.gameObject.transform) {
					if (child.name.Contains (key)) {
						child.gameObject.SetActive (true);
					} else {
						child.gameObject.SetActive (false);
					}
				}
				bool[] slacking = WorkerScript.slacking;
				bool[] stealing = WorkerScript.stealing;

				if (key == "2" && (slacking [0] | slacking [1])) {
					Clipboard.GetComponent<QuotaScript> ().workerSlackText ();
				} else if (key == "3" && (slacking [2] | slacking [3])) {
					Clipboard.GetComponent<QuotaScript> ().workerSlackText ();
				} else if (key == "4" && (slacking [4] | slacking [5])) {
					Clipboard.GetComponent<QuotaScript> ().workerSlackText ();
				} else if (key == "5" && (slacking [6])) {
					Clipboard.GetComponent<QuotaScript> ().workerSlackText ();
				} else if (key == "2" && (stealing [0] | stealing [1])) {
					Clipboard.GetComponent<QuotaScript> ().workerStealText ();
				} else if (key == "3" && (stealing [2] | stealing [3])) {
					Clipboard.GetComponent<QuotaScript> ().workerStealText ();
				} else if (key == "4" && (stealing [4] | stealing [5])) {
					Clipboard.GetComponent<QuotaScript> ().workerStealText ();
				} else if (key == "5" && (stealing [6])) {
					Clipboard.GetComponent<QuotaScript> ().workerStealText ();
				} else if (key == "1" && boss.GetComponent<BossScript> ().isWatchingPorn ()) {
					Clipboard.GetComponent<QuotaScript> ().bossSlackText ();
				} else {
					Clipboard.GetComponent<QuotaScript> ().clearText ();
				}
			}
		}
		else if ((scene == 3)& (Input.GetKeyDown(KeyCode.R))){
			worker.GetComponent<WorkerScript>().Refresh();
			boss.GetComponent<BossScript>().Refresh();
			Application.LoadLevel("Main");
		}
	}
	public void EnterBuilding(){
		scene = 2;
		title.gameObject.SetActive (false);
		LandscapeEntry.gameObject.SetActive (false);
		LandscapeFactory.gameObject.SetActive (true);
		DIALOG.GetComponent<DialogScript> ().setEnterFactory ();
		Miz.GetComponent<MoveScript> ().EnterFactory ();
		Clipboard.SetActive (true);
	}
	public void Death(){
		DIALOG.GetComponent<DialogScript> ().deathWorker();
		Clipboard.GetComponent<QuotaScript> ().workerMinus ();
		cam.GetComponent<SoundScript> ().playDeath ();
	}
	public void Feed(){
		DIALOG.GetComponent<DialogScript> ().mushroomQuote ();
		Clipboard.GetComponent<QuotaScript> ().mushMinus ();
		cam.GetComponent<SoundScript> ().playShroom ();
	}
	public void BossDeath(){
		DIALOG.GetComponent<DialogScript> ().deathBoss();
		Clipboard.GetComponent<QuotaScript> ().bossMinus ();
		cam.GetComponent<SoundScript> ().playDeath ();
	}

	public void EndGame(){
		scene = 3;
		clock.GetComponent<TimeScript> ().forceEnd ();
		LandscapeEntry.gameObject.SetActive (false);
		Miz.SetActive (false);
		Clipboard.GetComponent<QuotaScript> ().EndGame ();
		DIALOG.SetActive (false);
		LandscapeFactory.gameObject.SetActive (false);
		EndScreen.gameObject.SetActive (true);
	}
}
