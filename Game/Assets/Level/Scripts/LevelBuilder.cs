using UnityEngine;
using System.Collections;

/// <summary>
/// This is the script responsible for generating level. 
/// </summary>

public class LevelBuilder : MonoBehaviour {

    //public variables
    public GameObject[] LevelPrefabs;
    public GameObject Player;
    //private variables
    private GameObject levelPrefab;
    private Properties prop;
    private GameObject current;
    private GameObject next;
	private Vector3 endPosition = Vector3.zero;
	
	// Use this for initialization
	void Start () {
        levelPrefab = LevelPrefabs[0];
        current = Instantiate(levelPrefab, endPosition, Quaternion.identity) as GameObject;
        current.layer = 9;
		endPosition += levelPrefab.GetComponent<Properties>().dimentions;
		next = Instantiate(levelPrefab, endPosition, Quaternion.identity) as GameObject;
		next.layer = 9;
		endPosition += levelPrefab.GetComponent<Properties>().dimentions;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        if (Player.transform.position.x > next.transform.position.x + 50.0f)
        {            
            levelPrefab = LevelPrefabs[Random.Range(0, LevelPrefabs.GetLength(0))];
            Destroy(current);
            current = next;
			next = Instantiate(levelPrefab, endPosition, Quaternion.identity) as GameObject;
			next.layer = 9;
			endPosition += levelPrefab.GetComponent<Properties>().dimentions;
        }
        
    }
}
