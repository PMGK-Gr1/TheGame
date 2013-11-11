using UnityEngine;
using System.Collections;


/// <summary>
/// Moving donut.
/// </summary>
public class RigidDonutMover : MonoBehaviour {

	//public variables
	public float TargetSpeed = 20.0f;
	public float JumpForce = 1000.0f;
    //private variables
	private float cooldown = 2;
	/*
	// Use this for initialization
	void Start() {
		//cloth = this.GetComponent<InteractiveCloth>();
	}
	*/
	// Update is called once per frame
	void FixedUpdate() {
		float force = 0.0f;
		float x = this.rigidbody.velocity.x;

		force = 10.0f / (1.0f + Mathf.Pow(2, x - TargetSpeed));
		rigidbody.AddForceAtPosition(new Vector3(force, 0, 0), transform.position + new Vector3(0, 5f, 0), ForceMode.Acceleration);

		if (((Input.touchCount != 0 && Input.touches[0].phase == TouchPhase.Began)
			|| Input.GetKeyDown(KeyCode.Space))
			&& cooldown <= 0)
		{
			rigidbody.AddForce(new Vector3(0, JumpForce, 0), ForceMode.VelocityChange);
			cooldown = 0.5f;
		}
		cooldown -= Time.fixedDeltaTime;
	}
}
