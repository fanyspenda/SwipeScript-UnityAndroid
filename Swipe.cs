using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

	public float maxTime; //Maximum Time for Swiping
	public float minSwipeDist; //Minimal Swipe Distance

	float startTime; //for initiate When we begin touching
	float endTime; //initiate when we End the Touching

	Vector3 startPos; //start Position of our hand on screen
	Vector3 endPos; //end Position of our hand on screen
	float swipeDistance; //Saving Distance
	float swipeTime; //Saving Swipe Time

	Rigidbody2D rigidPlayer;
	// Use this for initialization
	void Start () {
		rigidPlayer = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		touchCheck ();
	}

	//melakukan check apakah jari sedang menyentuh layar
	void touchCheck(){
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);

			if (touch.phase == TouchPhase.Began) { //Does our Finger Touch the Screen?
				startTime = Time.time;
				startPos = touch.position;
			}

			else if (touch.phase == TouchPhase.Ended) { //Does We release Our Finger?
				endTime = Time.time;
				endPos = touch.position;

				swipeDistance = (endPos - startPos).magnitude;
				swipeTime = endTime - startTime;

				if (swipeTime < maxTime && swipeDistance > minSwipeDist)
					swipe ();
			}
		}
	}

	void swipe(){
		Vector2 distance = endPos - startPos;
		if (Mathf.Abs (distance.x) > Mathf.Abs (distance.y)) {
			//Horizontal left And Right
			if (distance.x > 0) {
				//Horizontal Right
			} else {
				//Horizontal Left
			}
		} else if (Mathf.Abs (distance.x) < Mathf.Abs (distance.y)) {
			//Vertical Up and Down
			if (distance.y > 0) {
				//Vertical UP
			} else {
				//Vertical Down
			}
		}
	}
}
