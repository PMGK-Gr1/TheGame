using UnityEngine;
using System.Collections;

public class Ruch : MonoBehaviour {
	
	public Transform Donut;
	public Transform Kamera;
	private Vector3 wektorPrzesuniecia;
	
	// Use this for initialization
	void Start () {
		wektorPrzesuniecia.Set (0,0,100);
	}
	
	// Update is called once per frame
	void Update () {
			Kamera.position = Donut.position + wektorPrzesuniecia;
	}
}
