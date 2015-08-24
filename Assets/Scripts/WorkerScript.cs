using UnityEngine;
using System.Collections;

public class WorkerScript : MonoBehaviour {
	public static bool workersLeft= true;
	public Sprite[] spriteArray;
	public int index = 0;
	public int workerId;
	public bool clone;

	public static bool[] dead = new bool[7]{false, false, false, false, false, false, false};
	public static bool[] slacking = new bool[7]{false, false, false, false, false, false, false};
	public static bool[] stealing = new bool[7]{false, false, false, false, false, false, false};
	public static int[] workerIdArray = new int[7]{0, 1, 2, 3, 4, 5, 6};

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = spriteArray [workerId];
	}

	public void Refresh(){
		workersLeft= true;
		bool[] dead = new bool[7]{false, false, false, false, false, false, false};
		bool[] slacking = new bool[7]{false, false, false, false, false, false, false};
		bool[] stealing = new bool[7]{false, false, false, false, false, false, false};
		int[] workerIdArray = new int[7]{0, 1, 2, 3, 4, 5, 6};
		this.gameObject.SetActive (true);
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = spriteArray [workerId];

	}
	// Update is called once per frame
	void Update () {
		if (dead [workerId]) {
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		} else {
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = spriteArray [workerIdArray[workerId]];
		}

		foreach (Transform child in gameObject.transform) {
			if (!slacking[workerId] && !stealing[workerId]){
				if (child.name == "zzz") {
					child.gameObject.SetActive (false);
				}
				if (child.name == "$") {
					child.gameObject.SetActive (false);
				}
			}

			if (slacking[workerId]){
				if (child.name == "zzz") {
					child.gameObject.SetActive (true);
				}
				if (child.name == "!") {
					child.gameObject.SetActive (false);
				}if (child.name == "$" && clone) {
					child.gameObject.SetActive (false);
				}
			} else if (stealing[workerId]){
				if (child.name == "$" && clone) {
					child.gameObject.SetActive (true);
				}
				if (child.name == "!"){
					child.gameObject.SetActive(false);
				}
				if (child.name == "zzz"){
					child.gameObject.SetActive(false);
				}
			}
		}
	}
	public void SetSlacking(int i){
		if (!dead [i] && !stealing[i]) {
			slacking [i] = true;
		}
	}
	public void SetStealing(int i){
		if (!dead [i] && !slacking[i]) {
			stealing [i] = true;
		}
	}
	public bool isStealing(){
		return stealing [workerId];
	}
	public bool isSlacking(){
		return slacking [workerId];
	}
	public void SwapSprite(){
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		int RandomNextSprite = Random.Range (0, spriteArray.Length);
		workerIdArray [workerId] = RandomNextSprite;
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = spriteArray [RandomNextSprite];
		dead [workerId] = false;

	}
	public bool isDead(){
		return dead [workerId];
	}

	public void death(){
		dead [workerId] = true;
		stealing [workerId] = false;
		slacking [workerId] = false;
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		foreach (Transform child in gameObject.transform) {
			if (child.name == "bloodpool") {
				child.gameObject.SetActive (true);
			}
			if (child.name == "!"){
				child.gameObject.SetActive(false);
			}if (child.name == "zzz"){
				child.gameObject.SetActive(false);
			}if (child.name == "$"){
				child.gameObject.SetActive(false);
			}

		}
		if (workersLeft) {
			Invoke ("SwapSprite", 2f);
		}
	}

	public void feed(){
		slacking[workerId] = false;
		foreach (Transform child in gameObject.transform) {
			if (child.name == "!"){
				child.gameObject.SetActive(true);
			}
			else if (child.name == "zzz"){
				child.gameObject.SetActive(false);
			}
		}
	}
}
