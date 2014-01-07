using UnityEngine;
using System.Collections;
using System.Collections.Generic;



/// <summary>
/// This is the script responsible for generating level. 
/// </summary>

public class LevelBuilder : MonoBehaviour {

    //public variables
    public GameObject[] LevelPrefabs;
    public GameObject[] SugarPrefabs;
    public GameObject[] ObstaclePrefabs;
    public GameObject[] BoostsPrefabs;
    //public int ModuleCount = 20;
    public float LevelLenght = 500.0f;
    public float DestrucionDistance = 100.0f;
    public int[] DistanceDifficulty;

    public float SugarChance = 0.7f;
    public float BoostChance = 0.1f;
    public float ObstacleChance = 0.5f;
    public float NothingChance = 0.30f;

    public int IncreaseSugarChance = 200;
    public int IncreaseBoostChance = 200;
    public int IncreaseObstacleChance = 200;
    public int DecreaseNothingChance = 200;
    //private variables
    private GameObject levelPrefab;
    //private Properties prop; // unused removed
    private GameObject current;
    private GameObject next;
	private Vector3 endPosition = Vector3.zero;
	public Queue<Properties> level = new Queue<Properties>();
	private const int groundLayer = 10;
    private int difficulty = 4;

    private List<GameObject>[] LevelPrefabsPool;
    private List<GameObject>[] SugarPrefabsPool;
    private List<GameObject>[] ObstaclePrefabsPool;
    private List<GameObject>[] BoostsPrefabsPool;

	// Use this for initialization
   

    void Awake()
    {
        
        LevelPrefabsPool = new List<GameObject>[LevelPrefabs.Length];
        for (int y = 0; y < LevelPrefabsPool.Length; y++)
        {
            LevelPrefabsPool[y] = new List<GameObject>();
        }

        for (int i = 0; i < LevelPrefabs.Length; i++)
        {

            for (int j = 0; j < 3; j++)
                {
                
                var tmp = Instantiate(LevelPrefabs[i], Vector3.zero, Quaternion.identity) as GameObject;
                tmp.SetActive(false);
                LevelPrefabsPool[i].Add(tmp);
            }
        }





        SugarPrefabsPool = new List<GameObject>[SugarPrefabs.Length];
        for (int y = 0; y < SugarPrefabsPool.Length; y++)
        {
            SugarPrefabsPool[y] = new List<GameObject>();
        }

        for (int i = 0; i < SugarPrefabs.Length; i++)
        {

            for (int j = 0; j < 4; j++)
            {

                var tmp = Instantiate(SugarPrefabs[i], Vector3.zero, Quaternion.identity) as GameObject;
                tmp.SetActive(false);
                SugarPrefabsPool[i].Add(tmp);
            }
        }



        ObstaclePrefabsPool = new List<GameObject>[ObstaclePrefabs.Length];
        for (int y = 0; y < ObstaclePrefabsPool.Length; y++)
        {
            ObstaclePrefabsPool[y] = new List<GameObject>();
        }

        for (int i = 0; i < ObstaclePrefabs.Length; i++)
        {

            for (int j = 0; j < 6; j++)
            {

                var tmp = Instantiate(ObstaclePrefabs[i], Vector3.zero, Quaternion.identity) as GameObject;

                //if (j==0) { Debug.Log("hey"); tmp.GetComponent<Billboard>().set(); }
                tmp.SetActive(false);
                ObstaclePrefabsPool[i].Add(tmp);
            }
        }

       

        BoostsPrefabsPool = new List<GameObject>[BoostsPrefabs.Length];
        for (int y = 0; y < BoostsPrefabsPool.Length; y++)
        {
            BoostsPrefabsPool[y] = new List<GameObject>();
        }

        for (int i = 0; i < BoostsPrefabs.Length; i++)
        {

            for (int j = 0; j < 6; j++)
            {

                var tmp = Instantiate(BoostsPrefabs[i], Vector3.zero, Quaternion.identity) as GameObject;
                tmp.SetActive(false);
                BoostsPrefabsPool[i].Add(tmp);
            }
        }




    }

    void Start()
    {
        
        #region cukiernia!
        GameObject Bakery = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Bakery.layer = groundLayer;
        Bakery.tag = "Ground";
        Bakery.transform.localScale = new Vector3(90.0f, 30.0f, 30.0f);
        Bakery.transform.position = new Vector3(45.0f, 15.0f, 0.0f);
        Destroy(Bakery, 20.0f);
        #endregion

        
        AddPrefab(0, true);
        AddPrefab(0, true);
        //AddPrefab(LevelPrefabs[0], true);
        
	}

    // Update is called once per frame

    void FixedUpdate()
    {
   

        if ((((int)(transform.position.x)) % IncreaseSugarChance) == 0) SugarChance += 0.1f;
        if ((((int)(transform.position.x)) % IncreaseBoostChance) == 0) BoostChance += 0.15f;
        if ((((int)(transform.position.x)) % IncreaseObstacleChance) == 0) ObstacleChance += 0.3f;
        if (((((int)(transform.position.x)) % DecreaseNothingChance) == 0) && (NothingChance > 0.05000001f)) NothingChance -= 0.05f;


        if (transform.position.x > DistanceDifficulty[0]) difficulty = 3;
        if (transform.position.x > DistanceDifficulty[1]) difficulty = 2;
        if (transform.position.x > DistanceDifficulty[2]) difficulty = 1;
        if (transform.position.x > DistanceDifficulty[3]) difficulty = 0;



		if (transform.position.x - level.Peek().transform.position.x - level.Peek().dimentions.x > DestrucionDistance)
        {
            while (level.Peek().usedObjects.Count != 0) { level.Peek().usedObjects.Dequeue().SetActive(false);}
            level.Dequeue().gameObject.SetActive(false);
        }

		if (endPosition.x - transform.position.x < LevelLenght)
        {
            AddPrefab(RandomPrefab());                
        }
    }
    

    int RandomPrefab()
    {
        return Random.Range(0, LevelPrefabs.Length - difficulty);
    }


    void AddPrefab(int toAdd, bool empty=false)
    {
        GameObject tmp = null;
        for (int i = 0; i < LevelPrefabsPool[toAdd].Count; i++)
        {
            if (!LevelPrefabsPool[toAdd][i].activeSelf)
            {
                tmp = LevelPrefabsPool[toAdd][i];
 
                break;
            }
        }

        if (tmp == null) return;


        tmp.transform.position = endPosition;
        tmp.SetActive(true);
        endPosition += tmp.GetComponent<Properties>().dimentions;
       
		var segmentInstance = tmp.GetComponent<Properties>();
        level.Enqueue(segmentInstance);
        
        var placesList = segmentInstance.GetComponentsInChildren<SubelementPlacer>();
        

        foreach (var place in placesList)
        {/*
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
            */
            float obstacleChance, sugarChance, boostChance, nothingChance;
            if (empty) { obstacleChance = sugarChance = boostChance = 0; nothingChance = 1; }
            else
            {
                obstacleChance = ObstacleChance;
                sugarChance = SugarChance;
                boostChance = BoostChance;
                nothingChance = NothingChance;
            }
          
            if (place.Sugars.Length == 0) sugarChance = 0;
            if (place.Boosts.Length == 0) boostChance = 0;
            if (place.Obstacles.Length == 0) obstacleChance = 0;

            float whatToInstatiate = Random.Range(0, obstacleChance + sugarChance + boostChance + nothingChance);
			//GameObject tmpObject = null;
       


            if (whatToInstatiate < obstacleChance)
            {
   
                int whichOne = place.Obstacles[Random.Range(0, place.Obstacles.Length)];

                GameObject tmpObj = null;
                for (int i = 0; i < ObstaclePrefabsPool[whichOne].Count; i++)
                {
                    if (!ObstaclePrefabsPool[whichOne][i].activeSelf)
                    {
                        tmpObj = ObstaclePrefabsPool[whichOne][i];
                        break;
                    }
                }
                if (tmpObj == null) continue;
               
                tmp.GetComponent<Properties>().usedObjects.Enqueue(tmpObj);
                tmpObj.transform.position = place.transform.position;
                tmpObj.SetActive(true);
            }





            else if (whatToInstatiate < obstacleChance + sugarChance)
            {

                int whichOne = place.Sugars[Random.Range(0, place.Sugars.Length)];
                GameObject tmpObj = null;
                for (int i = 0; i < SugarPrefabsPool[whichOne].Count; i++)
                {
                    if (!SugarPrefabsPool[whichOne][i].activeSelf)
                    {
                        tmpObj = SugarPrefabsPool[whichOne][i];
                        break;
                    }
                }
                if (tmpObj == null) continue;
                tmp.GetComponent<Properties>().usedObjects.Enqueue(tmpObj);
                tmpObj.SetActive(true);
                tmpObj.transform.position = place.transform.position;
                
            }



            else if (whatToInstatiate < obstacleChance + sugarChance + boostChance)
            {
     
                int whichOne = place.Boosts[Random.Range(0, place.Boosts.Length)];
                GameObject tmpObj = null;
                for (int i = 0; i < BoostsPrefabsPool[whichOne].Count; i++)
                {
                    if (!BoostsPrefabsPool[whichOne][i].activeSelf)
                    {
                        tmpObj = BoostsPrefabsPool[whichOne][i];
                        break;
                    }
                }
                if (tmpObj == null) continue;
                tmp.GetComponent<Properties>().usedObjects.Enqueue(tmpObj);

                tmpObj.transform.position = segmentInstance.transform.position;
                tmpObj.SetActive(true);
			}


			//if(tmpObject != null) tmpObject.transform.parent = segmentInstance.transform;
            //Destroy(place.gameObject);
        }
    }

}


