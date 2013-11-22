using UnityEngine;
using System.Collections;

/// <summary>
/// Placing candies. New version. Now, with prefabs of candies arrangement.
/// </summary>

public class SugarPlacer2 : MonoBehaviour {

    //public variables
    public GameObject[] SugarPrefabs;
    public float SugarChance = 0.75f;

	// Use this for initialization
	void Start () {

        if (Random.Range(0.0f, 1.0f) <= SugarChance)
        {
            GameObject tmpPref = SugarPrefabs[Random.Range(0, SugarPrefabs.GetLength(0))];
            var tmpNewPref = Instantiate(tmpPref, this.transform.localPosition, Quaternion.identity);
            Destroy(tmpNewPref, 70f);

        }

	}
	
}
