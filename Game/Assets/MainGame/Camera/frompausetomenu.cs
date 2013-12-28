using UnityEngine;
using System.Collections;

public class frompausetomenu : MonoBehaviour {
    private Donut donut;

    void Start()
    {

        donut = GameController.instance.donut;
    }
    void OnMouseUp()
    {
        Time.timeScale = 1.0f;
        donut.Save();
        Application.LoadLevel(0);
    }
}
