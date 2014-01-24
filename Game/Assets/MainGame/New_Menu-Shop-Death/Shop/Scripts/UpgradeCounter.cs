using UnityEngine;
using System.Collections;

public class UpgradeCounter : MonoBehaviour {

    public int UpgradeId;
	// Use this for initialization
	void Start () {

        this.guiText.fontSize = (int)(Screen.height * 0.07f);
        this.guiText.pixelOffset = new Vector2(Screen.width * 0.32f, 0.0001f);
	}
	
	// Update is called once per frame
	void Update () {

        if (UpgradeId == 0) this.guiText.enabled = false;
        else { this.guiText.enabled = true; this.guiText.text = PlayerPrefs.GetInt("Upgrade" + UpgradeId.ToString()).ToString(); }

	}
}
