using UnityEngine;
using System.Collections;

public class upgradesleft : MonoBehaviour {

    private Donut donut;
    void Start()
    {
        donut = GameController.instance.donut;
        if (donut.upgrade == 0) Destroy(this.gameObject);
    }
	void FixedUpdate () {
        this.GetComponent<TextMesh>().text = donut.upgradeCount.ToString();
	
	}
}
