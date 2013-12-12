using UnityEngine;
using System.Collections;

public class Equip : MonoBehaviour {

    public int id;
    void OnMouseUp()
    {
        PlayerPrefs.SetInt("ChosenUpgrade", id);
    }
}
