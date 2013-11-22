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
	public float JumpLength = 1.0f;
	public bool GodMode = false;
    //private variables
	private int sugarCubes = 0;
	private bool isAlive = true;
	private enum state {JumpPossible = 0, JumpStarted = 1, JumpOnGoing =2, JumpNotPossible = 3}
	private state prevState = state.JumpNotPossible;
	private float cooldown;

	private int stingersResistLeft = 0;
	private int milkCannonResistLeft = 0;
	private bool secondLife = false;

	void FixedUpdate() {
		float force = 0.0f;

		force = 50.0f / (1.0f + Mathf.Pow(2, this.rigidbody.velocity.x - TargetSpeed));
		rigidbody.AddForceAtPosition(new Vector3(force, 0, 0), transform.position + new Vector3(0, 5f, 0), ForceMode.Acceleration);
	}


	void Update() {
		// Input moved to pdate to prevent ignoring some keystrokes
		prevState = GetJumpState ();
		if (prevState == state.JumpStarted) {
			rigidbody.AddForce(new Vector3(0, InstantJumpForce, 0), ForceMode.VelocityChange);
		}
		else if(prevState == state.JumpOnGoing){
			rigidbody.AddForce(new Vector3(0, LongJumpForce, 0), ForceMode.Acceleration);
		}

	}

	public void SugarPickup(int value) {
		sugarCubes += value;
	}



	public void StingerHit() {
		if (stingersResistLeft > 0) {
			stingersResistLeft--;
			if (stingersResistLeft == 0) UnburntDonut();
		}else Death("Stinger");
	}

	public void BurntDonut() {
		Debug.Log("I am hot tonight.");
		// TODO nice pickup particle effect or some other spectacular thingy
		stingersResistLeft = 3;
	}

	void UnburntDonut() {
		Debug.Log("I am no longer burnt.");
		// TODO reverse the effects
	}




	public void MilkCannonHit() {
		if (milkCannonResistLeft > 0) {
			milkCannonResistLeft--;
			if (milkCannonResistLeft == 0) UnfrostDonut();
		}
		else Death("Milk");
	}

	public void FrostDonut() {
		Debug.Log("I am double frosted ?!?.");
		// TODO nice pickup particle effect or some other spectacular thingy
		milkCannonResistLeft = 3;
	}

	void UnfrostDonut() {
		Debug.Log("I am no longer frosted.");
		// TODO reverse the effects
	}



	public void GiveSecondLife() {
		Debug.Log("I've got a second life.");
		// TODO nice pickup particle effect or some other spectacular thingy
		milkCannonResistLeft = 3;
	}

	void Rebirth() {
		secondLife = false;
		Debug.Log("I died, but only temporally.");
		// TODO some epic rebirth effect
	}


	public void Death(string Cause) {
		if (!isAlive) return; // prevent killing multiple times
		if (secondLife && Cause != "Cops") {
			Rebirth();
			return;
		}
		Debug.Log(Localization.getText("DEAD"));
		if(!GodMode) Application.LoadLevel(Application.loadedLevel);
		PlayerPrefs.SetInt("Sugar", PlayerPrefs.GetInt("Sugar") + sugarCubes);
		PlayerPrefs.Save();
	}
	
	bool jump ()
    {
		return ((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space));
	}

	bool jumpHigher()
	{
		return ((Input.touchCount > 0)// && Input.touches[0].phase == TouchPhase.Stationary)
		        || Input.GetKey(KeyCode.Space));
	}

	state GetJumpState()
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
		cooldown = JumpLength;
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
