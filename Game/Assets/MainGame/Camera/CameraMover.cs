﻿using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

	public GameObject cylinder;
	Vector3 startVector;
    public PauseButton pause;


    public int sound, music;
	// Use this for initialization
    void Awake()
    {
        
        sound = PlayerPrefs.GetInt("sound", 1);

    }

	void Start () {
		startVector = this.transform.position - cylinder.transform.position;
       
		music = PlayerPrefs.GetInt("music", 1);

		Debug.Log(music.ToString());

		if (music == 1)
		{
			this.GetComponent<AudioSource>().Play();
		}
	}


	// Update is called once per frame
	void FixedUpdate () {
		Vector3 moveDirection = cylinder.transform.position + startVector - transform.position;
		if (cylinder.rigidbody != null) {
						Vector3 dynamicCamera = new Vector3 (0, 0, startVector.z - Mathf.Abs (cylinder.rigidbody.velocity.x));	
		
						this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, Mathf.Lerp (this.transform.position.z, 0.9f * dynamicCamera.z, 0.2f));

						this.transform.position += new Vector3 (moveDirection.x * 0.05f, moveDirection.y * 0.01f, 0);
						this.transform.LookAt (cylinder.transform.position - new Vector3 (startVector.x + 0.18f * Mathf.Lerp (this.transform.position.z, dynamicCamera.z, 0.02f), 0, 0));
						//Debug.Log(moveDirection);
						//this.transform.position += moveDirection;// * 0.2f;
				}
	}

	void Update() {
        music = PlayerPrefs.GetInt("music", 1);
        sound = PlayerPrefs.GetInt("sound", 1);

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (pause.paused) { pause.paused = false; pause.Pause(); }
            else { pause.paused = true; pause.Unpause(); }
        }
		if (Input.GetKeyDown(KeyCode.Menu)) Application.LoadLevel(0);
	}


}
