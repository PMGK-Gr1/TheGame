using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour {


    public Texture[] upgrades;
    public int upgrade;
	void FixedUpdate () {

        upgrade = PlayerPrefs.GetInt("ChosenUpgrade");
        this.guiTexture.texture = upgrades[upgrade];

	}
}
