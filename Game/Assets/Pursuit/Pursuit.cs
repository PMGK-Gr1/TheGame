using UnityEngine;
using System.Collections;

public class Pursuit : MonoBehaviour {

	public GameObject donut;
	public float pursuitSpeed = 10.0f;
	public float catchDistance = 2.0f;
	public float pursuitDelay = 2.0f;

	float startTime = 0.0f;
	// Use this for initialization
	void Start() {
		startTime = Time.time + pursuitDelay; 
	}

	// Update is called once per frame
	void FixedUpdate() {
		if (Time.time > startTime) {
			Vector3 delta = donut.transform.position - transform.position;

			float x = delta.magnitude / catchDistance;
			x -= 2;
			float currentSpeed = x * x * x * 0.2f + 1;
			currentSpeed *= pursuitSpeed;
			Vector3 velocity = currentSpeed * Time.fixedDeltaTime * delta.normalized;

			if (delta.magnitude < catchDistance) {
				Debug.Log("You've been caught. HAHAHA!!!!");
			}

			transform.position += velocity;

		}
	}
}
