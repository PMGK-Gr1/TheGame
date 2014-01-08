﻿using UnityEngine;
using System.Collections;

public class FlurryManager : MonoBehaviour {

	void Awake() {
		DontDestroyOnLoad (transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		FlurryAgent.Instance.onStartSession ("DSYXWKHNM2H2C3QVR9HM");
		FlurryAgent.Instance.setLogEnabled (true);
		FlurryAgent.Instance.logEvent ("Donut is running");
		FlurryAgent.Instance.onPageView ();
	}

	public void OnApplicationPause (bool pause) {
		if (pause) {
			FlurryAgent.Instance.logEvent ("Application paused");
			FlurryAgent.Instance.onEndSession ();		
		}
		else {
			FlurryAgent.Instance.onStartSession("DSYXWKHNM2H2C3QVR9HM");	
			FlurryAgent.Instance.logEvent ("Application resumed");	
		}
	}

	public void OnApplicationQuit() {
		FlurryAgent.Instance.logEvent ("Application closed");
		FlurryAgent.Instance.onEndSession ();
	}

}
