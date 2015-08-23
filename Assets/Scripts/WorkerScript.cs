using UnityEngine;
using System.Collections;

public class WorkerScript : MonoBehaviour {
	public Sprite[] spriteArray;
	public int index = 0;
	public int workerId;
	public bool clone;
	
	public static bool[] slacking = new bool[7]{false, false, false, false, false, false, false};
	public static bool[] stealing = new bool[7]{false, false, false, false, false, false, false};
	public static int[] workerIdArray = new int[7]{0, 1, 2, 3, 4, 5, 6};

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = spriteArray [workerId];
	}
	
	// Update is called once per frame
	void Update () {
		if (!clone && slacking[workerId]) {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = null;
		} else if (clone && slacking[workerId]) {
			transform.position += Vector3.up*Time.deltaTime*0.1f;		
			foreach (Transform child in gameObject.transform) {
				if (child.name == "zzz"){
					child.gameObject.SetActive(true);
				}
			}
		}
		else if (!clone && stealing[workerId]) {
			//something that indicates stealing
		}
	}
	public void SetSlacking(int i){
		slacking [i] = true;
	}
	public void SetStealing(int i){
		stealing [i] = true;
	}
	public bool isStealing(){
		return stealing [workerId];
	}
	public bool isSlacking(){
		return slacking [workerId];
	}
	public void SwapSprite(){
		if (index == spriteArray.Length) {
			index = 0;
		} else {
			index += 1;
		}
		if (!clone) {
			workerIdArray[workerId] = index;
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = spriteArray [index];
		} else {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = spriteArray [workerIdArray[workerId]];
		}
	}
}
