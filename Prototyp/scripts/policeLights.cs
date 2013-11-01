using UnityEngine;
using System.Collections;

public class policeLights : MonoBehaviour {

	private Color colorA, colorB, swapColor;
	private bool colorDirection;
	
	// Use this for initialization
	void Start () {
		colorA = Color.red;
		colorB = Color.blue;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (light.color == colorA || light.color == colorB)
		{
			swapColor = colorA;
			colorA = colorB;
			colorB = swapColor;
		}
		light.color = Color.Lerp(light.color, colorB, 0.5f);
	}
}
