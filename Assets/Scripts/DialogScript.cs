using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DialogScript : MonoBehaviour {
	Text person;
	Text content;
	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {
			if (child.name == "DialogPersonName") {
				person = child.GetComponent<Text>();
			}
			else if (child.name == "DialogContent") {
				content = child.GetComponent<Text>();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setLydia(){
		person.text = "Lydia (Security):";
		content.text = "Good morning Miz!";
	}
	public void setBrian(){
		person.text = "Brian (Security):";
		content.text = "Have a good day!";
	}
	public void setEnterFactory(){
		person.text = "Me:";
		content.text = "How is the factory?";
	}
}
