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
    public int[] DistanceDifficulty;

    public float SugarChance = 1f;
    public float BoostChance = 0.2f;
    public float ObstacleChance = 0.4f;
    public float NothingChance = 1f;

	public float difficultyDistance;
	public float difficultyPeriod;
    //private variables
    private GameObject levelPrefab;
    //private Properties prop; // unused removed
    private GameObject current;
    private GameObject next;
	private Vector3 endPosition = Vector3.zero;
	private Queue<Properties> level = new Queue<Properties>();
	private const int groundLayer = 10;
    private int difficulty = 4;
	// Use this for initialization
	void Start ()
    {
        /*#region cukiernia!
        GameObject Bakery = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Bakery.layer = groundLayer;
        Bakery.tag = "Ground";
        Bakery.transform.localScale = new Vector3(90.0f, 30.0f, 30.0f);
        Bakery.transform.position = new Vector3(45.0f, 15.0f, 0.0f);
        Destroy(Bakery, 20.0f);
        #endregion*/

        
        AddPrefab(LevelPrefabs[0], true);
        //AddPrefab(LevelPrefabs[0], true);
        
	}

    // Update is called once per frame
    
    void FixedUpdate()
    {
		/*
        if ((((int)(transform.position.x)) % IncreaseSugarChance) == 0) SugarChance += 0.1f;
        if ((((int)(transform.position.x)) % IncreaseBoostChance) == 0) BoostChance += 0.15f;
        if ((((int)(transform.position.x)) % IncreaseObstacleChance) == 0) ObstacleChance += 0.3f;
        if (((((int)(transform.position.x)) % DecreaseNothingChance) == 0) && (NothingChance > 0.05000001f)) NothingChance -= 0.05f;
		*/

		if (transform.position.x > difficultyDistance) {
			difficultyDistance += difficultyPeriod;
			BoostChance += 0.15f;
			NothingChance = Mathf.Max(NothingChance - 0.1f, 0f);
		}

        if (transform.position.x > DistanceDifficulty[0]) difficulty = 3;
        if (transform.position.x > DistanceDifficulty[1]) difficulty = 2;
        if (transform.position.x > DistanceDifficulty[2]) difficulty = 1;
        if (transform.position.x > DistanceDifficulty[3]) difficulty = 0;



		while (transform.position.x - level.Peek().transform.position.x - level.Peek().dimentions.x > DestrucionDistance)
        {
            Destroy(level.Dequeue().gameObject);
        }

		while (endPosition.x - transform.position.x < LevelLenght)
        {
            AddPrefab(LevelPrefabs[RandomPrefab()]);
           
        }
    }
    

    int RandomPrefab()
    {
		return Random.Range(1, LevelPrefabs.Length);
        /*float tmp = UnityEngine.Random.Range(0.0f, 1.0f);
        if (tmp <= 0.2f) return 1;
        if (tmp >= 0.8f) return 2;
        else return 0;*/
    }


    void AddPrefab(GameObject prefabToAdd, bool empty=false)
    {
		var segmentInstance = (Instantiate(prefabToAdd, endPosition, Quaternion.identity) as GameObject).GetComponent<Properties>();
        level.Enqueue(segmentInstance);
        endPosition += prefabToAdd.GetComponent<Properties>().dimentions;
        var placesList = segmentInstance.GetComponentsInChildren<SubelementPlacer>();
  

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
                }
                else if (objectToPlace.tag == "Sugar")
                {
                    candiesList.Add(objectToPlace);
                }
                else if (objectToPlace.tag == "Obstacle")
                {
                    obstaclesList.Add(objectToPlace);
                }
            }

            float obstacleChance, sugarChance, boostChance, nothingChance;
            if (empty) { obstacleChance = sugarChance = boostChance = 0; nothingChance = 1; }
            else
            {
                obstacleChance = ObstacleChance;
                sugarChance = SugarChance;
                boostChance = BoostChance;
                nothingChance = NothingChance;
            }
          
            if (candiesList.Count == 0) sugarChance = 0;
            if (boostsList.Count == 0) boostChance = 0;
            if (obstaclesList.Count == 0) obstacleChance = 0;

            float whatToInstatiate = Random.Range(0, obstacleChance + sugarChance + boostChance + nothingChance);
			GameObject tmpObject = null;

            if (whatToInstatiate < obstacleChance)
            {
                tmpObject = Instantiate(obstaclesList[Random.Range(0, obstaclesList.Count)], place.transform.position, place.transform.rotation) as GameObject;
            }
            else if (whatToInstatiate < obstacleChance + sugarChance)
            {
				tmpObject = Instantiate(candiesList[Random.Range(0, candiesList.Count)], place.transform.position, place.transform.rotation) as GameObject;
            }
            else if (whatToInstatiate < obstacleChance + sugarChance + boostChance)
            {
				tmpObject = Instantiate(boostsList[Random.Range(0, boostsList.Count)], place.transform.position, place.transform.rotation) as GameObject;
			}

			if(tmpObject != null) tmpObject.transform.parent = segmentInstance.transform;
            Destroy(place.gameObject);
        }
    }
}


