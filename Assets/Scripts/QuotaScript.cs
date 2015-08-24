using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuotaScript : MonoBehaviour {
	Text quota;
	Text workerCount;
	Text bossCount;
	Text mushCount;
	Text actionText;
	Text scoreText;
	Text EndText;
	int bearsDone;
	int bunniesDone;
	int controllersDone;
	int workerLeft;
	int bossLeft;
	int mushLeft;
	int bunny = 0;
	int bear = 0;
	int controller = 0;
	bool bossGone;
	int bunniesGoal = 600;
	int controllersGoal = 200;
	int bearsGoal = 600;
	int workersKilled;
	int bossesKilled;
	int mushFed;
	bool EndScreen = false;

	public static bool MushGone;

	// Use this for initialization
	void Start () {
		bearsDone = 0;
		bunniesDone = 0;
		controllersDone = 0;
		workerLeft = 10;
		bossLeft = 5;
		mushLeft = 400;

		foreach (Transform child in transform) {
			if (child.name == "Quota") {
				quota = child.GetComponent<Text>();
			}
			else if (child.name == "workercount") {
				workerCount = child.GetComponent<Text>();
			}else if (child.name == "bosscount") {
				bossCount = child.GetComponent<Text>();
			}else if (child.name == "mushcount") {
				mushCount = child.GetComponent<Text>();
			}else if (child.name == "Action") {
				actionText = child.GetComponent<Text>();
			} else if (child.name == "SCORE"){
				scoreText = child.GetComponent<Text>();
			} else if (child.name == "EndText"){
				EndText = child.GetComponent<Text>();
			}
		}
		InvokeRepeating ("UpdateWorkDone", 1, 1f);
	}
	public void mushMinus(){
		mushFed += 1;
		mushLeft -= 1;
	}
	public void workerMinus(){
		workersKilled += 1;
		workerLeft -= 1;
	}
	public void bossMinus(){
		bossesKilled += 1; 
		bossLeft -= 1;
	}
	// Update is called once per frame
	void Update () {
		if (!EndScreen){
			if (workerLeft <= 0) {
				WorkerScript.workersLeft = false;
				workerCount.text = "NO MORE \n WORKERS LEFT";
			} else {
				workerCount.text = workerLeft + " worker \n replacements \n available";
			}

			if (bossLeft <= 0) {
				BossScript.bossesLeft = false;
				bossCount.text = "NO MORE \n BOSSES LEFT";
			} else {
				bossCount.text = bossLeft + " boss \n replacements \n available";
			}

			if (mushLeft <= 0) {
				MushGone = true;
				mushCount.text = "NO MORE \n MUSHROOMS LEFT";
			} else {
				mushCount.text = mushLeft + " mushrooms \n available";
			}

			quota.text = "Daily Production Quota: \n \n" + bearsDone + "/" + bearsGoal + " bears \n" + bunniesDone + "/" + bunniesGoal + " bunnies \n"+ controllersDone + "/" + controllersGoal + " game controllers";
	
		}
	}
	void UpdateWorkDone(){
		if (!EndScreen) {
			bearsDone += bear;
			bunniesDone += bunny;
			controllersDone += controller;
		}
	}
	public void bossSlackText(){
		actionText.text = "It looks like the boss is slacking off. \n To kill and replace, get close and (Q). \n To feed Mushroom, get close and (F).";
	}
	public void workerSlackText(){
		actionText.text = "It looks like a worker is slacking off. \n To kill and replace, get close and (Q). \n To feed Mushroom, get close and (F).";
	}
	public void workerStealText(){
		actionText.text = "It looks like a worker is stealing stuff. \n To kill and replace, get close and (Q). \n To feed Mushroom, get close and (F).";
	}
	public void clearText(){
		actionText.text = "";
	}

	public void updateWorkers(bool[] dead, bool[] slack, bool[] steal){
		bunny = 0;
		bear = 0;
		controller = 0;
		if (steal[0]) {
			controller -= 1;
		}
		if (!slack [0] && !dead[0]) {
			controller += 1;
		}
		if (steal[1]) {
			controller -= 1;
		} 
		if (!slack [1] && !dead[1]) {
			controller += 1;
		}
		if (steal [2]) {
			bear -= 1;
		}
		if (!slack [2] && !dead[2]) {
			bear += 2;
		}
		if (steal [3]) {
			bear -= 1;
		}
		if (!slack [3] && !dead[3]) {
			bear += 2;
		}
		if (steal [4]) {
			bunny -= 1;
		}
		if (!slack [4] && !dead[4]) {
			bunny += 2;
		}
		if (steal [5]) {
			bunny -= 1;
		}
		if (!slack [5] && !dead[5]) {
			bunny += 2;
		}
		if (steal [6]) {
			controller -= 1;
		}
		if (!slack [6] && !dead[6]) {
			bunny += 1;
		}
		if (!bossGone) {
			bunny += 1;
			bear += 1;
			controller += 1;
		}

	}
	public void bossNull(){
		bossGone = true;
	}
	public void EndGame(){
		EndScreen = true;
		quota.text = "";
		actionText.text = "";
		bossCount.text = "";
		mushCount.text = "";
		workerCount.text = "";
		string grade;
		float bunnyGrade = (1.0f * bunniesDone) / bunniesGoal;
		float bearGrade = (1.0f * bearsDone) / bearsGoal;
		float controllerGrade = (1.0f * controllersDone) / controllersGoal;
		float averageScore = ((bunnyGrade + bearGrade + controllerGrade) / 3.0f)*100f;
		if (averageScore > 97) {
			grade = "A+";
		} else if (averageScore > 92) {
			grade = "A";
		} else if (averageScore > 89) {
			grade = "A-";
		} else if (averageScore > 86) {
			grade = "B+";
		} else if (averageScore > 83) {
			grade = "B";
		} else if (averageScore > 79) {
			grade = "B-";
		} else if (averageScore > 77) {
			grade = "C+";
		} else if (averageScore > 73) {
			grade = "C";
		} else if (averageScore > 69) {
			grade = "C-";
		} else {
			grade = "F";
		}
		scoreText.text = "GAME OVER- YOUR SCORE: " + grade;
		EndText.text = "Killed " + workersKilled + " workers \n \n Killed "
			+ bossesKilled + " bosses \n \n Fed " + mushFed + " mushrooms \n \n Made "
			+ controllersDone + " game controllers out of goal of " + controllersGoal 
				+ "\n \n Made " + bearsDone + " bears out of goal of " + bearsGoal + 
				" \n  \n Made " + bunniesDone + " bunnies out of goal of " + bunniesGoal;
	}
}
