using UnityEngine;
using System.Collections;

public class UpgradesSwipe : MonoBehaviour {

	// Use this for initialization
    public GameObject[] Upgrades;

    public bool canSwipe = true;

	void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && canSwipe)
        {
          
            var delta = Input.GetTouch(0).deltaPosition.y;
            if (delta > 0 && Upgrades[32].transform.localPosition.y <= 0.7f) foreach(var up in Upgrades) up.transform.localPosition += new Vector3(0, Mathf.Sign(delta) / 20.0f, 0);
            else if (delta < 0 && Upgrades[0].transform.localPosition.y >= 0.1f) foreach (var up in Upgrades) up.transform.localPosition += new Vector3(0, Mathf.Sign(delta) / 20.0f, 0);
         
          
        }

        

	}
}
