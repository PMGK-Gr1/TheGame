using UnityEngine;
using System.Collections;

public class Pursuit : MonoBehaviour {

    //public variables
	//public float PursuitSpeed = 30.0f;
	public float CatchDistance = 60.0f;
	public float PursuitDelay = 2.0f;
	public float pursuitSpeed;
	public NetShooter netShooter;
    public bool DonutCatchable = true;
    //private variables
	private float startTime = 0.0f;
	private Donut donut;


	// Use this for initialization
	void Start() {
		startTime = Time.time + PursuitDelay;
		donut = GameController.instance.donut;
		pursuitSpeed = donut.TargetSpeed;
	}

	// Update is called once per frame
	void FixedUpdate() {
		if (Time.time > startTime) {
			Vector3 tmpDelta = donut.transform.position - transform.position;
            this.light.intensity = 5.0f / tmpDelta.magnitude;
			float tmpX = tmpDelta.magnitude / CatchDistance;
			tmpX -= 2;
			float currentSpeed = tmpX * tmpX * tmpX * 0.2f + 1;
			currentSpeed *= pursuitSpeed;
			Vector3 tmpVelocity = currentSpeed * Time.fixedDeltaTime * tmpDelta.normalized;

			if ((tmpDelta.magnitude < CatchDistance)&&(DonutCatchable)) {
				GameController.instance.donut.Death("Cops");
			}

			transform.position += tmpVelocity;
		}
	}
}
