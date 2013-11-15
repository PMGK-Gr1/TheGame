using UnityEngine;
using System.Collections;

public class shake : MonoBehaviour {
	
	float counter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		counter += 0.2f;
		transform.position = transform.position + new Vector3(0.1f*Mathf.Sin(counter), 0.01f*Mathf.Sin(counter), 0.1f*Mathf.Sin(counter));
	}
}
