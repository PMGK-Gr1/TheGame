using UnityEngine;
using System.Collections;


/// <summary>
/// Moving donut.
/// </summary>
public class RigidDonut : MonoSingleton<RigidDonut> {

	//public variables
	public float TargetSpeed = 20.0f;
	public float InstantJumpForce = 1000.0f;
	public float LongJumpForce = 500.0f;
	public bool IsTouchingGround = false;
	public float Cooldown = 1.0f;
    //private variables
	private int sugarCubes = 0;
	private bool isAlive = true;
	private enum state {JumpPossible = 0, JumpStarted = 1, JumpOnGoing =2, JumpNotPossible = 3}
	private state prevState = state.JumpNotPossible;
	private float cooldown;

	void FixedUpdate() {
		float force = 0.0f;

		force = 10.0f / (1.0f + Mathf.Pow(2, this.rigidbody.velocity.x - TargetSpeed));
		rigidbody.AddForceAtPosition(new Vector3(force, 0, 0), transform.position + new Vector3(0, 5f, 0), ForceMode.Acceleration);
	}


	void Update() {
		// Input moved to pdate to prevent ignoring some keystrokes
		prevState = jumpState ();
		if (prevState == state.JumpStarted && jump ()) {
			rigidbody.AddForce(new Vector3(0, InstantJumpForce, 0), ForceMode.VelocityChange);
		}
		else if(prevState == state.JumpOnGoing){
			rigidbody.AddForce(new Vector3(0, LongJumpForce, 0), ForceMode.Acceleration);
		}

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
		Debug.Log(Localization.getText("DEAD"));
		Application.LoadLevel(Application.loadedLevel);
		PlayerPrefs.SetInt("Sugar", PlayerPrefs.GetInt("Sugar") + sugarCubes);
		PlayerPrefs.Save();
	}
	
	bool jump ()
    {
		return ((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space));
	}

	bool jumpHigher()
	{
		return ((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Stationary)
		        || Input.GetKey(KeyCode.Space));
	}

	state jumpState()
	{
		if(prevState == state.JumpPossible && jump())
		{
			return state.JumpStarted;
		}
		if((prevState == state.JumpStarted || prevState == state.JumpOnGoing) && jumpHigher() && cooldown > 0)
		{
			cooldown -= Time.deltaTime;
			return state.JumpOnGoing;
		}
		cooldown = Cooldown;
		if(IsTouchingGround && (prevState == state.JumpNotPossible || prevState == state.JumpPossible))
		{
			return state.JumpPossible;
		}
		if(!IsTouchingGround && prevState == state.JumpPossible)
		{
			return state.JumpNotPossible;
		}


		return state.JumpNotPossible;
	}

}
