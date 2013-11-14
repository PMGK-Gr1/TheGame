using UnityEngine;
using System.Collections;


/// <summary>
/// Moving donut.
/// </summary>
public class RigidDonut : MonoSingleton<RigidDonut> {

	//public variables
	public float TargetSpeed = 20.0f;
	public float JumpForce = 1000.0f;
    //private variables
	private float cooldown = 2;
	private int sugarCubes = 0;
	private bool isAlive = true;



	void FixedUpdate() {
		float force = 0.0f;

		force = 10.0f / (1.0f + Mathf.Pow(2, this.rigidbody.velocity.x - TargetSpeed));
		rigidbody.AddForceAtPosition(new Vector3(force, 0, 0), transform.position + new Vector3(0, 5f, 0), ForceMode.Acceleration);
	}


	void Update() {
		// Input moved to pdate to prevent ignoring some keystrokes
		if (((Input.touchCount != 0 && Input.touches[0].phase == TouchPhase.Began)
			|| Input.GetKeyDown(KeyCode.Space))
			&& cooldown <= 0) {
			rigidbody.AddForce(new Vector3(0, JumpForce, 0), ForceMode.VelocityChange);
			cooldown = 0.5f;
		}
		cooldown -= Time.fixedDeltaTime;
	}

	public void SugarCubePickup(int value) {
		sugarCubes += value;
	}

	public void BoostPickup(string type) {
		// TODO
		// implement picking boosts
	}

	public void Death(string Cause) {
		if (!isAlive) return; // prevent killing multiple times
		// TODO handle different boost preventing death
		Debug.Log(Localization.getText("DEATH"));
		Application.LoadLevel(Application.loadedLevel);
		PlayerPrefs.SetInt("Sugar", PlayerPrefs.GetInt("Sugar") + sugarCubes);
		PlayerPrefs.Save();
	}
}
