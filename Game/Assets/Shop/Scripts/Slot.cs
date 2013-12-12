using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour {


    public Texture[] upgrades;

	void FixedUpdate () {

        int upgrade = PlayerPrefs.GetInt("ChosenUpgrade");
        this.guiTexture.texture = upgrades[upgrade];

	}
}
