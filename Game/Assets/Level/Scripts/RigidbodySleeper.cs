using UnityEngine;
using System.Collections;

public class RigidbodySleeper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Debug.Log("Instance");
		rigidbody.Sleep();
		Destroy(this);
	}
}
