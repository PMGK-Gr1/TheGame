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
          if((Input.GetTouch(0).position.x >= Screen.width * 0.005f) && (Input.GetTouch(0).position.x <= Screen.width * 0.5f ))
            {
            var delta = Input.GetTouch(0).deltaPosition.y;
            if (delta > 0 && Upgrades[6].transform.localPosition.y <= 0.6f) foreach(var up in Upgrades) up.transform.localPosition += new Vector3(0, Mathf.Sign(delta) / 20.0f, 0);
            else if (delta < 0 && Upgrades[5].transform.localPosition.y >= 0.1f) foreach (var up in Upgrades) up.transform.localPosition += new Vector3(0, Mathf.Sign(delta) / 20.0f, 0);
         
          
        }}

        

	}
}
