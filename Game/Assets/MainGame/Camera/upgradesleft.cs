using UnityEngine;
using System.Collections;

public class upgradesleft : MonoBehaviour {

    private Donut donut;
    public GameObject counter;
    void Start()
    {
        this.guiText.fontSize = (int)(Screen.height * 0.04f);
        this.guiText.pixelOffset = new Vector2(Screen.width * 0.165f, Screen.height * 0.065f);
        donut = GameController.instance.donut;

        if (donut.upgrade == 0)
        {
            Destroy(this.gameObject);
            Destroy(counter.gameObject);
        }

    }
	void FixedUpdate () {
        this.GetComponent<GUIText>().text = donut.upgradeCount.ToString();
	
	}
}
