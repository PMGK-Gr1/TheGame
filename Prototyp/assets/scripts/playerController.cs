using UnityEngine;
using System.Collections;

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
		rigidbody.AddForce(Vector3.up.normalized*jumpForce, ForceMode.Impulse);
	}
}
