using UnityEngine;
using System.Collections;

public class Turlanie : MonoBehaviour {

	private Vector2 wektorRuchu;
	private Vector3 wektorObrotu;
	public float KatObrotu = -0.3f;
	
	// Use this for initialization
	void Start () {
		wektorRuchu.Set(1,0);
		wektorObrotu.Set(0,0,1);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(wektorRuchu);	
		//transform.Rotate(wektorObrotu, -KatObrotu);
	}
}
