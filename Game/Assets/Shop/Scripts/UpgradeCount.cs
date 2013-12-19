using UnityEngine;
using System.Collections;

public class UpgradeCount : MonoBehaviour {

    public int id;
	void Update () {
        this.GetComponent<TextMesh>().text= PlayerPrefs.GetInt("Upgrade" + id.ToString()).ToString(); 
	}
}
