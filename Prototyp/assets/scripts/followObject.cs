using UnityEngine;
using System.Collections;

/// <summary>
/// This script makes object follow its target.
/// </summary>

public class followObject : MonoBehaviour {
	
	//public
	public GameObject targetObject;	//But a target of follow here.
	public Vector3 offset;	//This vector allows you to define additional offset.
	public bool xAxis = true, yAxis = true, zAxis = true; //You can lock or unlock an axis from the editor.
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		AlignToTarget();
	}
	
	/// <summary>
	/// Aligns to target.
	/// </summary>
	void AlignToTarget ()
	{
		//Indicates if axis is set to true, if yes it follows the target along the axis.
		//If all axes are on true it follows object point to point
		transform.position = (new Vector3(
			(xAxis) ? (targetObject.transform.position.x) : transform.position.x, 
			(yAxis) ? (targetObject.transform.position.y) : transform.position.y, 
			(zAxis) ? (targetObject.transform.position.z) : transform.position.z) 
			+ offset); //Add the offset vector
	}

}
