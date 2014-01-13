using UnityEngine;
using System.Collections;

public class resetYES : MonoBehaviour {


    public reset r;
	// Use this for initialization
	void Start () {
        this.guiTexture.pixelInset = new Rect(
            Screen.width * 0.3f,
            Screen.height * 0.3f,
            Screen.width * 0.1f,
            Screen.height * 0.1f);


	}

    void OnMouseUp()
    {
        r.rst();
    }



	// Update is called once per frame
	void Update () {
	
	}
}
