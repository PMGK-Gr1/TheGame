using UnityEngine;
using System.Collections;

/// <summary>
/// Placing candies. New version. Now, with prefabs of candies arrangement.
/// </summary>

public class CandyPlacer2 : MonoBehaviour {

    //public variables
    public GameObject[] CandyPrefabs;
    public float CandyChance = 0.75f;

	// Use this for initialization
	void Start () {

        if (Random.Range(0.0f, 1.0f) <= CandyChance)
        {
            GameObject tmpPref = CandyPrefabs[Random.Range(0, CandyPrefabs.GetLength(0))];
            var tmpNewPref = Instantiate(tmpPref, this.transform.localPosition, Quaternion.identity);
            Destroy(tmpNewPref, 70f);

        }

	}
	
}
