using UnityEngine;
using System.Collections;
using System.Collections.Generic;



/// <summary>
/// This is the script responsible for generating level. 
/// </summary>

public class LevelBuilder : MonoBehaviour {

    //public variables
    public GameObject[] LevelPrefabs;
    //public int ModuleCount = 20;
    public float LevelLenght = 500.0f;
    public float DestrucionDistance = 200.0f;
    //private variables
    private GameObject levelPrefab;
    //private Properties prop; // unused removed
    private GameObject current;
    private GameObject next;
	public Vector3 endPosition = Vector3.zero;
    private Queue<GameObject> level = new Queue<GameObject>();
    public float currentLenght = 0;
	private const int groundLayer = 10;
	// Use this for initialization
	void Start ()
    {
        #region cukiernia!
        GameObject Bakery = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Bakery.layer = groundLayer;
        Bakery.transform.localScale = new Vector3(70.0f, 30.0f, 30.0f);
        Bakery.transform.position = new Vector3(35.0f, 15.0f, 0.0f);
        Destroy(Bakery, 20.0f);
        #endregion

        AddPrefab(LevelPrefabs[0]);

        
	}

    // Update is called once per frame
    
    void FixedUpdate()
    {

       
        while(transform.position.x - level.Peek().transform.localPosition.x > DestrucionDistance)
        {
            currentLenght -= level.Peek().GetComponent<Properties>().dimentions.x;
            Destroy(level.Dequeue());
        }

        while (currentLenght < LevelLenght)
        {
            AddPrefab(LevelPrefabs[RandomPrefab()]);
        }
    }
    

    int RandomPrefab()
    {
        float tmp = UnityEngine.Random.Range(0.0f, 1.0f);
        if (tmp <= 0.2f) return 1;
        if (tmp >= 0.8f) return 2;
        else return 0;
    }


    void AddPrefab(GameObject prefabToAdd)
    {
        Properties prefabProperties = prefabToAdd.GetComponent<Properties>();
        var tmpElem = Instantiate(prefabToAdd, endPosition, Quaternion.identity) as GameObject;
        level.Enqueue(tmpElem);
        currentLenght += prefabToAdd.GetComponent<Properties>().dimentions.x;
        endPosition += prefabToAdd.GetComponent<Properties>().dimentions;
        var placesList = tmpElem.GetComponentsInChildren<SubelementPlacer>();
  

        foreach (var place in placesList)
        {
            List<GameObject> obstaclesList, boostsList, candiesList;
            obstaclesList = new List<GameObject>();
            boostsList = new List<GameObject>();
            candiesList = new List<GameObject>();

            foreach (var objectToPlace in place.ObjectsToPlace)
            {
                if (objectToPlace.tag == "Boost")
                {
                    boostsList.Add(objectToPlace);                  
                    //break;
                }
                if (objectToPlace.tag == "Sugar")
                {
                    candiesList.Add(objectToPlace);
                 //   break;
                }
                if (objectToPlace.tag == "Obstacle")
                {
                    obstaclesList.Add(objectToPlace);
                //    break;
                }
                
            }

            float obstacleChance, candyChance, boostChance, nothingChance;
            obstacleChance = prefabProperties.ObstacleChance;
            candyChance = prefabProperties.CandyChance;
            boostChance = prefabProperties.BoostChance;
            nothingChance = prefabProperties.NothingChance;
          
            if (candiesList.Count == 0) candyChance = 0;
            if (boostsList.Count == 0) boostChance = 0;
            if (obstaclesList.Count == 0) obstacleChance = 0;
            float whatToInstatiate = Random.Range(0, obstacleChance + candyChance + boostChance + nothingChance);

            if (whatToInstatiate < obstacleChance)
            {
                var tmpObject = Instantiate(obstaclesList[Random.Range(0, obstaclesList.Count)], place.transform.position, place.transform.rotation);
                Destroy(tmpObject, prefabProperties.LifeTime);
            }
            else if (whatToInstatiate < obstacleChance + candyChance)
            {
                var tmpObject = Instantiate(candiesList[Random.Range(0, candiesList.Count)], place.transform.position, place.transform.rotation);
                Destroy(tmpObject, prefabProperties.LifeTime);
            }
            else if (whatToInstatiate < obstacleChance + candyChance + boostChance)
            {
                var tmpObject = Instantiate(boostsList[Random.Range(0, boostsList.Count)], place.transform.position, place.transform.rotation);
                Destroy(tmpObject, prefabProperties.LifeTime);
            }
            else place.GetComponent<SubelementPlacer>().Suicide();
            
           

        }
    }
}


