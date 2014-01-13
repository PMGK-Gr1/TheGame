using UnityEngine;
using System.Collections;

public class UpgradeBuyScript : MonoBehaviour
{


    public int UpgradeId;
    public int Price;
    public GUIText PriceTag;
    // Use this for initialization
	void Awake () {

        

        this.guiTexture.pixelInset = new Rect(0,0,
                Screen.width * 0.2f,
                Screen.width * 0.1f);

        this.transform.position = new Vector3(2 + 0.1f,
                (0.65f - 2.0f * (float)UpgradeId / 10.0f), this.transform.position.z);

        PriceTag.text = Price.ToString();
        PriceTag.fontSize = (int)(Screen.height * 0.05f);
        PriceTag.pixelOffset = new Vector3(Screen.width * 0.15f, Screen.height * 0.01f);
    
    }

    void OnMouseUp()
    {
        if (PlayerPrefs.GetInt("Sugar") >= Price)
        {
            PlayerPrefs.SetInt("Sugar", PlayerPrefs.GetInt("Sugar") - Price);
            PlayerPrefs.SetInt("Upgrade" + UpgradeId.ToString(), PlayerPrefs.GetInt("Upgrade" + UpgradeId.ToString()) + 1);
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
