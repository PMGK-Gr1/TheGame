﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


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
	private Vector3 endPosition = Vector3.zero;
    private List<GameObject> level = new List<GameObject>();
    private float currentLenght = 0;
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

        levelPrefab = LevelPrefabs[0];
        var tmpElement = Instantiate(levelPrefab, endPosition, Quaternion.identity) as GameObject;
        /*
        tmpElement.GetComponent<CandyPlacer2>().CandyChance = -1;
        tmpElement.GetComponent<ObstaclePlacer>().ChanceForObstacle = -1;
        tmpElement.GetComponent<BoostPlacer>().ChanceForBoost = -1;
         */
        tmpElement.GetComponent<Placer>().CandyChance = -1;
        tmpElement.GetComponent<Placer>().BoostChance = -1;
        tmpElement.GetComponent<Placer>().ObstacleChance = -1;
        currentLenght += levelPrefab.GetComponent<Properties>().dimentions.x;
        level.Add(tmpElement);
        //current.layer = 9;
		endPosition += levelPrefab.GetComponent<Properties>().dimentions;
        var tmpElement1 = Instantiate(levelPrefab, endPosition, Quaternion.identity) as GameObject;
        /*
        tmpElement1.GetComponent<CandyPlacer2>().CandyChance = -1;
        tmpElement1.GetComponent<ObstaclePlacer>().ChanceForObstacle = -1;
        tmpElement1.GetComponent<BoostPlacer>().ChanceForBoost = -1;
         */
        tmpElement1.GetComponent<Placer>().CandyChance = -1;
        tmpElement1.GetComponent<Placer>().BoostChance = -1;
        tmpElement1.GetComponent<Placer>().ObstacleChance = -1;
        currentLenght += levelPrefab.GetComponent<Properties>().dimentions.x;
        level.Add(tmpElement1);
		//next.layer = 9;
		endPosition += levelPrefab.GetComponent<Properties>().dimentions;
        
       /* for (int i = 2; i < ModuleCount; i++)
        {
            
            levelPrefab = LevelPrefabs[RandomPrefab()];
            var tmpElem = Instantiate(levelPrefab, endPosition, Quaternion.identity) as GameObject;
            level.Add(tmpElem);
            endPosition += levelPrefab.GetComponent<Properties>().dimentions;
        }*/


        do
        {
            levelPrefab = LevelPrefabs[RandomPrefab()];
            var tmpElem = Instantiate(levelPrefab, endPosition, Quaternion.identity) as GameObject;
            currentLenght += levelPrefab.GetComponent<Properties>().dimentions.x;
            level.Add(tmpElem);
            endPosition += levelPrefab.GetComponent<Properties>().dimentions;

        } while (currentLenght < LevelLenght);


        
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		// TODO fix this shit
		// It should work continously not in (ModuleCount /2) increments
        /*if (transform.position.x > level[ModuleCount / 2].transform.position.x + 100f)
        {
            for (int i = 0; i < ModuleCount / 2; i++)
            {
                Destroy(level[0]);
                level.RemoveAt(0);
                levelPrefab = LevelPrefabs[RandomPrefab()];
                var tmpElem = Instantiate(levelPrefab, endPosition, Quaternion.identity) as GameObject;
                level.Add(tmpElem);
                endPosition += levelPrefab.GetComponent<Properties>().dimentions;
            }
        }*/

        if (transform.position.x - level[0].transform.localPosition.x > DestrucionDistance)
        {
            Destroy(level[0]);
            level.RemoveAt(0);
            do
            {
                levelPrefab = LevelPrefabs[RandomPrefab()];
                var tmpElem = Instantiate(levelPrefab, endPosition, Quaternion.identity) as GameObject;
                currentLenght += levelPrefab.GetComponent<Properties>().dimentions.x;
                level.Add(tmpElem);
                endPosition += levelPrefab.GetComponent<Properties>().dimentions;

            } while (currentLenght < LevelLenght);

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
        float tmp = UnityEngine.Random.Range(0.0f, 1.0f);
        if (tmp <= 0.2f) return 1;
        if (tmp >= 0.8f) return 2;
        else return 0;
    }
}
