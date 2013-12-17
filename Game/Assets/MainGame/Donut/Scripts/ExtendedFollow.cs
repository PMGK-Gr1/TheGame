using UnityEngine;
using System.Collections;

public class ExtendedFollow : MonoBehaviour {

	public GameObject target;
	Vector3 startingRelativePosition;

	// Use this for initialization
	void Start () {
		startingRelativePosition = this.transform.position - target.transform.position;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		this.transform.position = target.transform.position + startingRelativePosition;
	}
}
