using UnityEngine;
using System.Collections;


/// <summary>
/// Placing everything on prefab
/// </summary>

public class Placer : MonoBehaviour {


    //public variables
    public float CandyChance = 0.7f;
    public float BoostChance = 0.1f;
    public float ObstacleChance = 0.5f;

	// Use this for initialization
	void Start () {

        var Places = GetComponentsInChildren<ObjectPlacing>();

        if(Random.Range(0.0f,1.0f) <= CandyChance)
        {
            Places[Random.Range(0, Places.GetLength(0))].GetComponent<ObjectPlacing>().CPlacing();
        }
        if(Random.Range(0.0f,1.0f) <= BoostChance)
        {
            Places[Random.Range(0, Places.GetLength(0))].GetComponent<ObjectPlacing>().BPlacing();
        }
        if (Random.Range(0.0f, 1.0f) <= ObstacleChance)
        {
            Places[Random.Range(0, Places.GetLength(0))].GetComponent<ObjectPlacing>().OPlacing();
        }
	
	}

	}

