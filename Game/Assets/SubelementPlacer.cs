using UnityEngine;
using System.Collections;

public class SubelementPlacer : MonoBehaviour {

	// Use this for initialization

    public GameObject[] ObjectsToPlace;
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Suicide()
    {
        Destroy(gameObject);
    }
}
