using UnityEngine;
using System.Collections;


/// <summary>
/// Placing obstacles
/// </summary>

public class ObstaclePlacer : MonoBehaviour
{

    //public variables
    public GameObject[] Obstacles;
    public float Height = 0;
    public float ChanceForObstacle = 0.4f;


    // Use this for initialization
    void Start()
    {

        if (Random.Range(0.0f, 1.0f) <= ChanceForObstacle)
        {
            GameObject tmpObstacle = Obstacles[Random.Range(0, Obstacles.GetLength(0))];
            var tmpNewObstacle = Instantiate(tmpObstacle,
                                            new Vector3(this.transform.localPosition.x + 0.5f * this.collider.bounds.size.x,
                                                        this.transform.localPosition.y + Height * this.collider.bounds.size.y + 0.5f * tmpObstacle.transform.localScale.y,
                                                        0.0f),
                                             Quaternion.identity) as GameObject;

            Destroy(tmpNewObstacle, 70f);
        }
     }
}
