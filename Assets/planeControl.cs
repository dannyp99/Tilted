using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeControl : MonoBehaviour { 
	private bool hasControl = true; 
	public float speed; 
	private Rigidbody rb;
	public float maxRot = 40f; 
	public float minRot = -40f;
	public float angleIn;
	public float angleOut;
	public float minAngle;
	public float maxAngle;

	// Use this for initialization
	void Start () { 
		rb = GetComponent<Rigidbody>();
		speed = 10;
		
	}

	float currentDeltaForward = 0.0f; 
	float currentDeltaRight = 0.0f;
	// Update is called once per frame
	void FixedUpdate () {
		if (hasControl == true) {
			float moveHorizontal = Input.GetAxis ("HorizontalPlane");
			float moveVertical = Input.GetAxis ("VerticalPlane"); 

			currentDeltaForward += Time.deltaTime * speed * moveVertical;
			currentDeltaForward = Mathf.Clamp (currentDeltaForward, -40.0f, 40.0f);



			currentDeltaRight += Time.deltaTime * speed * moveHorizontal; 
			currentDeltaRight = Mathf.Clamp (currentDeltaRight, -40.0f, 40.0f); 

			transform.eulerAngles = new Vector3 (currentDeltaForward, 0.0f, currentDeltaRight); 

			//transform.Rotate (Vector3.right * Time.deltaTime * speed * moveVertical);
			//transform.Rotate (Vector3.forward * Time.deltaTime * speed * moveHorizontal);
			//Vector3 ClampRotation = transform.rotation.eulerAngles;


			//if (prevAngle > 300.0f) 
			//{
			//	if (ClampRotation.x > 320.0f) 
			//	{
			//		ClampRotation.x = 320.0f;
			//	}
			//}


			//prevAngle = ClampRotation.x;
			//transform.rotation = Quaternion.Euler (ClampRotation);


		Vector3 ClampRotation2 = transform.rotation.eulerAngles; 
			transform.rotation = Quaternion.Euler (ClampRotation2);
		}

	} 
	float ClampAngle(float angle, float from, float to) {
		if (angle > 180f)
			angle = 360f - angle;
			angle = Mathf.Clamp (angle, from, to); 

		 if(angle < 180f) 
			angle = 360f - angle;


		return angle;
}
}