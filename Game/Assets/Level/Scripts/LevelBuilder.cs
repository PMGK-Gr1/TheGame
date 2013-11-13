using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// This is the script responsible for generating level. 
/// </summary>

public class LevelBuilder : MonoBehaviour {

    //public variables
    public GameObject[] LevelPrefabs;
    public GameObject Player;
    public int HowMany = 20;
    //private variables
    private GameObject levelPrefab;
    private Properties prop;
    private GameObject current;
    private GameObject next;
	private Vector3 endPosition = Vector3.zero;
    private List<GameObject> level = new List<GameObject>();
	
	// Use this for initialization
	void Start ()
    {

        #region cukiernia!
        GameObject Bakery = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Bakery.layer = 9;
        Bakery.transform.localScale = new Vector3(70.0f, 30.0f, 30.0f);
        Bakery.transform.position = new Vector3(35.0f, 15.0f, 0.0f);
        Destroy(Bakery, 20.0f);
        #endregion




        levelPrefab = LevelPrefabs[0];
        var tmpElement = Instantiate(levelPrefab, endPosition, Quaternion.identity) as GameObject;
        tmpElement.GetComponent<CandyPlacer2>().CandyChance = -1;
        tmpElement.GetComponent<ObstaclePlacer>().ChanceForObstacle = -1;
        tmpElement.GetComponent<BoostPlacer>().ChanceForBoost = -1;
        level.Add(tmpElement);
        //current.layer = 9;
		endPosition += levelPrefab.GetComponent<Properties>().dimentions;
        var tmpElement1 = Instantiate(levelPrefab, endPosition, Quaternion.identity) as GameObject;
        tmpElement1.GetComponent<CandyPlacer2>().CandyChance = -1;
        tmpElement1.GetComponent<ObstaclePlacer>().ChanceForObstacle = -1;
        tmpElement1.GetComponent<BoostPlacer>().ChanceForBoost = -1;
        level.Add(tmpElement1);
		//next.layer = 9;
		endPosition += levelPrefab.GetComponent<Properties>().dimentions;
        
        for (int i = 2; i < HowMany; i++)
        {
            
            levelPrefab = LevelPrefabs[RandomPrefab()];
            var tmpElem = Instantiate(levelPrefab, endPosition, Quaternion.identity) as GameObject;
            level.Add(tmpElem);
            endPosition += levelPrefab.GetComponent<Properties>().dimentions;
        }

        
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player.transform.position.x > level[HowMany / 2].transform.position.x + 100f)
        {
            for (int i = 0; i < HowMany / 2; i++)
            {
                Destroy(level[0]);
                level.RemoveAt(0);
                levelPrefab = LevelPrefabs[RandomPrefab()];
                var tmpElem = Instantiate(levelPrefab, endPosition, Quaternion.identity) as GameObject;
                level.Add(tmpElem);
                endPosition += levelPrefab.GetComponent<Properties>().dimentions;
                

            }


        }
        
        /*

        if (Player.transform.position.x > next.transform.position.x + 50.0f)
        {            
            levelPrefab = LevelPrefabs[Random.Range(0, LevelPrefabs.GetLength(0))];
            Destroy(current);
            current = next;
			next = Instantiate(levelPrefab, endPosition, Quaternion.identity) as GameObject;
			next.layer = 9;
			endPosition += levelPrefab.GetComponent<Properties>().dimentions;
        }
        
    */
    }


    int RandomPrefab()
    {
        float tmp = Random.Range(0.0f, 1.0f);
        if (tmp <= 0.2f) return 1;
        if (tmp >= 0.8f) return 2;
        else return 0;


    }
}
