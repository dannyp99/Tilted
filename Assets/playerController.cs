using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour { 
	public float speed;
	private Rigidbody rb; 
	private int count; 
	public Text countText; 
	public Text winText; 
	private bool hasControl = true; 
	private float time;
	public Text timeText;
	void Start(){ 
		 
		rb = GetComponent<Rigidbody>();
		count = 0; 
		time = 200f;
		setCountText (); 
		winText.text = "";
		timeText.text = "";

	}

	void FixedUpdate(){  
		if (hasControl == true) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical"); 
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			rb.AddForce (movement * speed); 
			setCountText ();
			time -= Time.deltaTime;

		} 
		if (time <= 0) { 
			winText.text = "Player2!"; 
			timeText.text = "Time: " + 0;
		}

		//if (count >= 12) { 
			//speed++; 
		//}
	}

	void OnTriggerStay(Collider other){ 
		if (other.gameObject.CompareTag ("Pick up")) { 
			other.gameObject.SetActive (false); 

		}
	
		Debug.Log(Vector3.Distance(transform.position, other.transform.position));
		if (Vector3.Distance(transform.position, other.transform.position) < 1.04f) { 
				this.gameObject.GetComponent<Collider> ().enabled = false; 
			this.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero; 
			hasControl = false; 
			winText.text = "Player1!";

			}

	} 

	void setCountText(){  
	//countText.text = "Count: " + count.ToString (); 
		timeText.text = "Time: " + time.ToString ("F0");
 	} 
}
