using UnityEngine;
using System.Collections;

public class DingSoundDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("waitALittle");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator waitALittle()
	{
		yield return new WaitForSeconds(1);
		Destroy(gameObject);
	}
}
