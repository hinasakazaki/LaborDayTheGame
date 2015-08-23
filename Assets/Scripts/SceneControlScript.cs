using UnityEngine;
using System.Collections;

public class SceneControlScript : MonoBehaviour {
	public GameObject LandscapeEntry;
	public GameObject LandscapeFactory;
	public GameObject Miz;
	public GameObject DIALOG;
	public GameObject MainPanel;
	public GameObject Clipboard;
	public GameObject worker;
	public GameObject boss;

	public int scene; //1 = entry, 2 = factory

	// Use this for initialization
	void Start () {
		scene = 2;
	}

	// Update is called once per frame
	void Update () {
		if (scene == 2) {
			string key = "8";
			if (Input.GetKey ((KeyCode.Keypad1))|(Input.GetKey(KeyCode.Alpha1))) {
				key = "1";
			} else if (Input.GetKey ((KeyCode.Keypad2))|(Input.GetKey(KeyCode.Alpha2))) {
				key = "2";
			} else if (Input.GetKey ((KeyCode.Keypad3))|(Input.GetKey(KeyCode.Alpha3))){
				key = "3";
			} else if (Input.GetKey ((KeyCode.Keypad4))|(Input.GetKey(KeyCode.Alpha4))) {
				key = "4";
			} else if (Input.GetKey ((KeyCode.Keypad5))|(Input.GetKey(KeyCode.Alpha5))) {
				key = "5";
			}
			if (key != "8"){
				foreach (Transform child in MainPanel.gameObject.transform) {
					if (child.name.Contains (key)) {
						child.gameObject.SetActive (true);
					} else {
						child.gameObject.SetActive (false);
					}
				}
			}
			int RandomInt = Random.Range(0, 1500);
			if (RandomInt < 10){
				worker.GetComponent<WorkerScript>().SetSlacking(Random.Range (0, 7));
			} else if (RandomInt < 20){
				worker.GetComponent<WorkerScript>().SetStealing(Random.Range (0,7));
			}
			if (RandomInt < 950 && RandomInt > 957){
				boss.GetComponent<BossScript>().SetWatchingPorn();
			}
		}
	}
	public void EnterBuilding(){
		scene = 2;
		LandscapeEntry.gameObject.SetActive (false);
		LandscapeFactory.gameObject.SetActive (true);
		DIALOG.GetComponent<DialogScript> ().setEnterFactory ();
		Miz.GetComponent<MoveScript> ().EnterFactory ();
		Clipboard.SetActive (true);
	}
}
