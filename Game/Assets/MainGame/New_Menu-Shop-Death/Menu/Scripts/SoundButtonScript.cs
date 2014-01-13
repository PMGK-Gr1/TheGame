﻿using UnityEngine;
using System.Collections;

public class SoundButtonScript : MonoBehaviour {

	// Use this for initialization
    void Awake()
    {
        if (!PlayerPrefs.HasKey("sound")) PlayerPrefs.SetInt("sound", 1);
    }

	void Start () {
        this.guiTexture.pixelInset = new Rect(
               Screen.width * 0.55f,
               Screen.height * 0.65f,
               Screen.width * 0.15f,
               Screen.height * 0.25f);
	}

    void OnMouseUp()
    {
        int music = PlayerPrefs.GetInt("sound");
        PlayerPrefs.SetInt("sound", music * (-1));
    }

	// Update is called once per frame
	void Update () {
	
	}
}