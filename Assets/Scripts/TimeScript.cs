using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {
	Text clockText;  
	private float timer = 240.0f;
	private bool started = false;
	bool end = false;
	public GameObject sc;
	// Use this for initialization
	void Start () {
		clockText = this.GetComponent<Text> ();
		clockText.text = "9:00 AM";
	}
	
	// Update is called once per frame
	void Update () {
		if (!started & sc.GetComponent<SceneControlScript> ().getScene () == 2) {
			started = true;
		}
		if (started && !end) {
			timer -= Time.deltaTime;
			float time = 1020 - timer*2;
			int minutes = Mathf.FloorToInt(time / 60F);
			string am = "AM";
			int seconds = Mathf.FloorToInt(time - minutes * 60);
			if (minutes > 11) {
				am = "PM";
			}
			if (minutes > 12) {
				minutes -= 12;
			}
			string clockformat = string.Format("{0:0}:{1:00} ", minutes, seconds);
			clockformat += am;
			clockText.text = clockformat;

		}
		if (timer <= 0f | end) {
			sc.GetComponent<SceneControlScript>().EndGame();
			clockText.text = "R TO RESTART";
			//end game
		}
	
	}
	public void forceEnd(){
		end = true;
	}
}
