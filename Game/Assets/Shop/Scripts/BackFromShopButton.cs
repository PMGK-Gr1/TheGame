using UnityEngine;
using System.Collections;

public class BackFromShopButton : MonoBehaviour {

    void OnMouseUp()
    {
        Application.LoadLevel(2);
    }
}
