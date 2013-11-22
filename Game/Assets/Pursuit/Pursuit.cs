﻿using UnityEngine;
using System.Collections;

public class Pursuit : MonoBehaviour {

    //public variables
	//public float PursuitSpeed = 30.0f;
	public float CatchDistance = 60.0f;
	public float PursuitDelay = 2.0f;

    //private variables
	private float startTime = 0.0f;
	private RigidDonut donut;
	private float pursuitSpeed;


	// Use this for initialization
	void Start() {
		startTime = Time.time + PursuitDelay;
		donut = RigidDonut.instance;
		pursuitSpeed = donut.TargetSpeed;
	}

	// Update is called once per frame
	void FixedUpdate() {
		if (Time.time > startTime) {
			Vector3 tmpDelta = donut.transform.position - transform.position;
			float tmpX = tmpDelta.magnitude / CatchDistance;
			tmpX -= 2;
			float currentSpeed = tmpX * tmpX * tmpX * 0.2f + 1;
			currentSpeed *= pursuitSpeed;
			Vector3 tmpVelocity = currentSpeed * Time.fixedDeltaTime * tmpDelta.normalized;

			if (tmpDelta.magnitude < CatchDistance) {
				RigidDonut.instance.Death("DONUT_CAUGHT");
			}

			transform.position += tmpVelocity;
		}
	}
}
