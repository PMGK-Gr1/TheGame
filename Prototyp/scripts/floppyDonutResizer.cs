using UnityEngine;
using System.Collections;

public class floppyDonutResizer : MonoBehaviour {
	
	Vector3 oldScale;
	int iterations, maxIterations;
	bool back;
	
	// Use this for initialization
	void Start () {
		oldScale = new Vector3();
		
		back = true;
		iterations = 0;
		maxIterations = 1;
		
		oldScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space))
		{
			back = !back;
		}
	}
	
	/// <summary>
	/// Raises the collision enter event.
	/// </summary>
	void OnCollisionEnter (Collision collision)
	{
		Vector3 toPointOfCol = collision.contacts[0].point - transform.position;
		Debug.Log(toPointOfCol);
		Deflect(toPointOfCol.normalized);
	}
	
	/// <summary>
	/// Spłaszcza donuta.
	/// </summary>
	void Deflect (Vector3 directionOfResize)
	{
		//Quaternion oldRotation = transform.rotation;
		
		//transform.rotation = Quaternion.identity;
		if (!back)
		{
			float mul = 0.1f;
			float speed = 0.02f;
			transform.localScale = new Vector3(
				Mathf.Lerp(transform.localScale.x, mul*directionOfResize.x, speed), 
				Mathf.Lerp(transform.localScale.y, mul*directionOfResize.y, speed),
				Mathf.Lerp(transform.localScale.z, mul*directionOfResize.z, speed));
			
		}
		else
		{
			
		}
		
		//transform.rotation = oldRotation;
	}

}
