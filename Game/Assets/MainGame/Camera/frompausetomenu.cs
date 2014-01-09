using UnityEngine;
using System.Collections;

public class frompausetomenu : MonoBehaviour {
    private Donut donut;

	public FlurryManager flurry;

    void Start()
    {
        donut = GameController.instance.donut;
    }
    void OnMouseUp()
    {
		flurry.SendMessage ("Button", "Menu");
        Time.timeScale = 1.0f;
        donut.Save();
        Application.LoadLevel(0);
    }
}
