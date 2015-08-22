using UnityEngine;
using System.Collections;

public class WorkerScript : MonoBehaviour {
	public Sprite[] spriteArray;
	public int index = 0;
	// Use this for initialization
	void Start () {
		index = Random.Range (0, spriteArray.Length);
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = spriteArray [index];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SetLazy(){
	}

	public void SwapSprite(){
		if (index == spriteArray.Length) {
			index = 0;
		} else {
			index += 1;
		}
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = spriteArray [index];
	}
}
