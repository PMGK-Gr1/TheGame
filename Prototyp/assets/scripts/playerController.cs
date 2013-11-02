using UnityEngine;
using System.Collections;

/// <summary>
/// This script allows player to control object which it's assigned to.
/// </summary>

public class playerController : MonoBehaviour {
	
	//public
	public float jumpForce;
	public float xForce;

	// Use this for initialization
	void Start () {
		rigidbody.AddForce(Vector3.right*100, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.AddForce(Vector3.right*xForce);
	}
	
	/// <summary>
	/// Raises the collision stay event.
	/// </summary>
	void OnCollisionStay()
	{
		//While the object stays in contact with anything and player taps a screen the object jumps.
		//TODO: check if collision.collider is a ground
		//TODO: devide input check from the jump script (ie with a bool variable)
		if (Input.GetMouseButtonDown(0))
		{
			Jump();
		}
	}
	
	/// <summary>
	/// Jump.
	/// </summary>
	void Jump()
	{
		//Add impulsive force
		rigidbody.AddForce(Vector3.up.normalized*jumpForce, ForceMode.Impulse);
	}
}
