using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DialogScript : MonoBehaviour {
	Text person;
	Text content;
	string[] normalPhrases = new string[]{"Hey Manager!", "Busy day!", "Let's be productive!"};
	string[] stealingPhrases = new string[]{"I'm... not stealing or anything!", "I need this for the kids!", "Is this illegal?"};
	string[] slackingPhrases = new string[]{"Ugh so sleepy...", "Factory job is boring.", "Feeling unmotivated..."};
	string[] pornPhrases = new string[]{"AH! You caught me!", "I know it's inappropriate!", "Porn is more interesting!"};

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
	public void setBoss(){
		person.text = "Boss:";
		content.text = "Lots to do today!";
	}
	public void setStealingWorker(){
		person.text = "Worker:";
		content.text = stealingPhrases [Random.Range (0, normalPhrases.Length)];
	}
	public void setSlackingWorker(){
		person.text = "Worker:";
		content.text = slackingPhrases [Random.Range (0, normalPhrases.Length)];
	}
	public void setNormalWorker(){
		person.text = "Worker:";
		content.text = normalPhrases [Random.Range (0, normalPhrases.Length)];
	}
	public void setPornBoss(){
		person.text = "Boss:";
		content.text = pornPhrases [Random.Range (0, normalPhrases.Length)];
	}
}
