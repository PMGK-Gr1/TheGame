using UnityEngine;
using System.Collections;

public class Pursuit : MonoBehaviour {

    //public variables
	public GameObject Donut;
	public float PursuitSpeed = 10.0f;
	public float CatchDistance = 2.0f;
	public float PursuitDelay = 2.0f;

    //private variables
	private float startTime = 0.0f;
	// Use this for initialization
	void Start() {
		startTime = Time.time + PursuitDelay; 
	}

	// Update is called once per frame
	void FixedUpdate() {
		if (Time.time > startTime) {
			Vector3 tmpDelta = Donut.transform.position - transform.position;

			float tmpX = tmpDelta.magnitude / CatchDistance;
			tmpX -= 2;
			float currentSpeed = tmpX * tmpX * tmpX * 0.2f + 1;
			currentSpeed *= PursuitSpeed;
			Vector3 tmpVelocity = currentSpeed * Time.fixedDeltaTime * tmpDelta.normalized;

			if (tmpDelta.magnitude < CatchDistance) {
				Debug.Log("You've been caught. HAHAHA!!!!");
			}

			transform.position += tmpVelocity;

		}
	}
}
