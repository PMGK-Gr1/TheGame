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
    private Quaternion rotation = Quaternion.Euler(new Vector3(-90, 180,0));
	
	// Use this for initialization
	void Start () {
        levelPrefab = LevelPrefabs[0];
        current = Instantiate(levelPrefab, new Vector3(0, 0, 0), rotation) as GameObject;
        current.layer = 9;
        Vector3 nextVector = new Vector3(current.collider.bounds.size.x-0.1f,0,0);
        next = Instantiate(levelPrefab, nextVector, rotation) as GameObject;
        next.layer = 9;
        prop = next.GetComponent<Properties>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        if (Player.transform.position.x > (next.transform.position.x - ((next.transform.localScale.x)/3) ))
        {            
            levelPrefab = LevelPrefabs[Random.Range(0, LevelPrefabs.GetLength(0))];
            float nextPositionX = next.transform.position.x + next.collider.bounds.size.x -0.2f;
            float nextPositionY = next.transform.position.y + prop.NextY;
            Destroy(current);
            current = next;
            next = Instantiate(levelPrefab,new Vector3(nextPositionX,nextPositionY,0),rotation ) as GameObject;
            prop = next.GetComponent<Properties>();
            next.layer = 9;
        }
        
    }
}
