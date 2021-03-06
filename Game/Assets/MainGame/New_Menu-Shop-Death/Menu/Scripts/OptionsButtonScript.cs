﻿using UnityEngine;
using System.Collections;

public class OptionsButtonScript : MonoBehaviour {

    public Controller control;

    public bool active = true;
	// Use this for initialization
	void Start () {

        this.guiTexture.pixelInset = new Rect(0.025f * (float)Screen.width,
            0.8f * (float)Screen.height,
            (178.0f / 1676.0f) * (float)Screen.width,
            (178.0f / 1013.0f) * (float)Screen.height);


	}


    void OnMouseUp()
    {
        if (active)
        {
            FlurryManager.instance.Button("Options");
            if (!control.optionsOn) control.ToOptions();
            else control.FromOptions();
        }
    }
}
