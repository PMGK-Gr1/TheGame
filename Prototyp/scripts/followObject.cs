using UnityEngine;
using System.Collections;

public class followObject : MonoBehaviour {
	
	//public
	public GameObject targetObject;
	public Vector3 offset;
	public bool xAxis = true, yAxis = true, zAxis = true;

	//private
	private Transform CameraTransform;
		
	// Use this for initialization
	void Start () {
		transform.Translate(new Vector3(targetObject.transform.position.x - transform.position.x, 0.0f, 0.0f));
	}
	
	// Update is called once per frame
	void Update () {
		AlignToTarget();
	}
	
	void AlignToTarget ()
	{
		transform.position = (new Vector3(
			(xAxis) ? (targetObject.transform.position.x) : transform.position.x, 
			(yAxis) ? (targetObject.transform.position.y) : transform.position.y, 
			(zAxis) ? (targetObject.transform.position.z) : transform.position.z) 
			+ offset);
	}

}
