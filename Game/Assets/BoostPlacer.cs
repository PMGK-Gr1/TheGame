using UnityEngine;
using System.Collections;


/// <summary>
/// Placing boosts.
/// </summary>

public class BoostPlacer : MonoBehaviour {

    //public variables
    public GameObject[] Boosts;
    public float ChanceForBoost = 0.1f;


	// Use this for initialization
	void Start () {

        if (Random.Range(0.0f, 1.0f) <= ChanceForBoost)
        {
            GameObject tmpBoost = Boosts[Random.Range(0, Boosts.GetLength(0))];
            var tmpNewBoost = Instantiate(tmpBoost,
                                new Vector3(Random.Range(0.0f, this.collider.bounds.size.x) + this.transform.localPosition.x,
                                            Random.Range(0.0f, 12.0f) + this.transform.localPosition.y,
                                            0.0f),
                                Quaternion.identity) as GameObject;
            Destroy(tmpNewBoost, 70f);
        }
	}
	
	
	
}
