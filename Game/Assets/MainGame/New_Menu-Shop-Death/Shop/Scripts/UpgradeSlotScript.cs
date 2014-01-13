using UnityEngine;
using System.Collections;

public class UpgradeSlotScript : MonoBehaviour {

	// Use this for initialization

    public Texture[] UpradeTextures;
    private int UpgradeId;
    public UpgradesSwipe swiper;
    public UpgradeCounter slotCount;
	void Start () {

        UpgradeId = PlayerPrefs.GetInt("ChosenUpgrade");
        this.guiTexture.texture = UpradeTextures[UpgradeId];
        this.guiTexture.pixelInset = new Rect(
           0,
            0,
            Screen.width * 0.1f,
            Screen.width * 0.1f);
        slotCount.UpgradeId = UpgradeId;
	}

    public void Equip(int id) {
		FlurryManager.instance.Button("UpgradeEquip");
        PlayerPrefs.SetInt("ChosenUpgrade", id);
        UpgradeId = id;
        this.guiTexture.texture = UpradeTextures[id];
        slotCount.UpgradeId = UpgradeId;

    }

	// Update is called once per frame
	void Update () {

	}
}
