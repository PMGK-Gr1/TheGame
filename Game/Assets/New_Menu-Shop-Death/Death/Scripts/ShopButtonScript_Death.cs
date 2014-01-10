using UnityEngine;
using System.Collections;

public class ShopButtonScript_Death : MonoBehaviour {
    public Controller control;

	// Use this for initialization
	void Start () {

        this.guiTexture.pixelInset = new Rect(
           Screen.width * 0.05f,
           Screen.height * 0.1f,
           Screen.width * 0.2f,
           Screen.width * 0.2f);

	}

    void OnMouseUp()
    {
        control.DeathToShop();
        control.deathscreen = false;

        control.inshop = true;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
