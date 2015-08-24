using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
	protected Animator animator;
	float x1;
	float x2;
	float y1;
	float y2;
	float speed =3.0f;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();			
		animator.SetInteger("state", 4);
		x1 = 2f;
		x2 = -7f;
		y1 = -.8f;
		y2 = -3f;
	}
	
	// Update is called once per frame
	void Update () {

		if ((Input.GetKey (KeyCode.LeftArrow) | (Input.GetKey(KeyCode.A))) && transform.position.x > x2) {
			transform.position += Vector3.left * speed * Time.deltaTime;
			animator.SetInteger("state", 0);
		}
		if ((Input.GetKey (KeyCode.RightArrow)|(Input.GetKey(KeyCode.D))) && transform.position.x < x1){
			transform.position += Vector3.right * speed * Time.deltaTime;
			animator.SetInteger("state", 1);
		}
		if ((Input.GetKey(KeyCode.UpArrow)|Input.GetKey(KeyCode.W))&& transform.position.y < y1) {
			transform.position += Vector3.up * speed * Time.deltaTime;	
			animator.SetInteger("state", 2);
		}
		if ((Input.GetKey (KeyCode.DownArrow) | Input.GetKey (KeyCode.S)) && transform.position.y > y2) {
			transform.position += Vector3.down * speed * Time.deltaTime;
			animator.SetInteger ("state", 3);
		} 
	}
	public void EnterFactory(){
		x1 = 2f;
		x2 = -6.5f;
		y1 = 1f;
		y2 = -2.5f;
	}
}
