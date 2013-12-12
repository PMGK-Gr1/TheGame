using UnityEngine;
using System.Collections;

public class UpgradeCount : MonoBehaviour {

    public int id;
	void Update () {
        this.guiText.text = PlayerPrefs.GetInt("Upgrade" + id.ToString()).ToString(); 
	}
}
