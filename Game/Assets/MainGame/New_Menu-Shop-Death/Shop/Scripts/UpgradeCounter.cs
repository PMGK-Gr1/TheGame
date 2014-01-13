using UnityEngine;
using System.Collections;

public class UpgradeCounter : MonoBehaviour {

    public int UpgradeId;
	// Use this for initialization
	void Start () {

        this.guiText.fontSize = (int)(Screen.height * 0.09f);
        this.guiText.pixelOffset = new Vector2(Screen.width * 0.31f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {

        if (UpgradeId == 0) this.guiText.enabled = false;
        else { this.guiText.enabled = true; this.guiText.text = PlayerPrefs.GetInt("Upgrade" + UpgradeId.ToString()).ToString(); }

	}
}
