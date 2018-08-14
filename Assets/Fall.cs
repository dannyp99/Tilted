using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour { 
	public float time = 200f; 
	public float fallTime = 100f; 
//	public Text winText; 

	// Use this for initialization
	void Start () { 
//		setCountText (); 
//		winText.text = "";
		
	}

	// Update is called once per frame
	void Update () { 
		time = time - Time.deltaTime;
		if (time <= 100f) { 
			this.gameObject.GetComponent<Rigidbody> ().isKinematic  = false; 
		}
//		if(time <= 0){
//			winText.text = "Player2";
	}
}
