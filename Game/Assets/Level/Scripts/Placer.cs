using UnityEngine;
using System.Collections;


/// <summary>
/// Placing everything on prefab
/// </summary>

public class Placer : MonoBehaviour {


    //public variables
    public GameObject[] CandyPlaces;
    public GameObject[] BoostPlaces;
    public GameObject[] ObstaclePlaces;
    public float CandyChance = 0.7f;
    public float BoostChance = 0.1f;
    public float ObstacleChance = 0.5f;

	// Use this for initialization
	void Start () {

        if(Random.Range(0.0f,1.0f) <= CandyChance)
        {
            CandyPlaces[Random.Range(0, CandyPlaces.GetLength(0))].GetComponent<ObjectPlacing>().Placing();
        }
        if(Random.Range(0.0f,1.0f) <= BoostChance)
        {
            BoostPlaces[Random.Range(0, BoostPlaces.GetLength(0))].GetComponent<ObjectPlacing>().Placing();
        }
        if(Random.Range(0.0f,1.0f) <= ObstacleChance)
        {
            ObstaclePlaces[Random.Range(0, ObstaclePlaces.GetLength(0))].GetComponent<ObjectPlacing>().Placing();
        }

        Destroyer();
	
	}

    void Destroyer()
    {

        foreach (GameObject obj in CandyPlaces)
        {
            Destroy(obj);
        }
        foreach (GameObject obj in BoostPlaces)
        {
            Destroy(obj);
        }
        foreach (GameObject obj in ObstaclePlaces)
        {
            Destroy(obj);
        }
    }


	}

