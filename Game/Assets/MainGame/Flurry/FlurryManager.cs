﻿using UnityEngine;
using System.Collections;

public class FlurryManager : MonoBehaviour {

	private int UpgradesLaunched = 0;
	private int MoneySpent;

	void OnLevelWasLoaded(int level) {
		FlurryAgent.Instance.onEndSession ();
	}

	// Use this for initialization
	void Start () {
		UpgradesLaunched = 0;
		FlurryAgent.Instance.onStartSession ("DSYXWKHNM2H2C3QVR9HM");
		FlurryAgent.Instance.setLogEnabled (true);
		FlurryAgent.Instance.logEvent ("Scene " + Application.loadedLevelName + " loaded");
		FlurryAgent.Instance.onPageView ();
	}

	public void OnApplicationPause (bool pause) {
		if (pause) {
			FlurryAgent.Instance.onEndSession ();		
		}
		else {
			FlurryAgent.Instance.onStartSession("DSYXWKHNM2H2C3QVR9HM");
		}
	}

	public void OnApplicationQuit() {
		FlurryAgent.Instance.logEvent ("Application closed");
		FlurryAgent.Instance.onEndSession ();
	}

	public void SessionLength(float time) {
		Debug.Log ("Works");
		FlurryAgent.Instance.logEvent ("Donut was running for: " + time.ToString() + "s");
	}

	public void Distance(float distance) {
		Debug.Log ("Works");
		FlurryAgent.Instance.logEvent ("Donut rolled " + distance.ToString () + "m");
	}

	public void CandiesPicked(int candies) {
		Debug.Log ("Works");
		FlurryAgent.Instance.logEvent ("Donut picked " + candies.ToString () + " candies in one game");
	}

	public void BoostNumberPicked (int number) {
		Debug.Log ("Works");
		FlurryAgent.Instance.logEvent ("Donut picked " + number.ToString () + " boosts in one game");
	}

	public void BoostPicked (string name) {
		Debug.Log ("Works");
		FlurryAgent.Instance.logEvent (name + " boost picked");
	}

	public void UpgradeLaunch(string name) {
		Debug.Log ("Works");
		FlurryAgent.Instance.logEvent (name + " upgrade launched");
		UpgradesLaunched ++;
	}

	public void TotalUpgrades () {
		Debug.Log ("Works");
		FlurryAgent.Instance.logEvent ("Donut launched " + UpgradesLaunched.ToString() + " upgrades in one game");
	}

	public void DeathCause (string cause) {
		Debug.Log ("Works");
		FlurryAgent.Instance.logEvent ("Donut died because of " + cause);
	}

	public void CandiesSpent () {
		Debug.Log ("Works");
		FlurryAgent.Instance.logEvent (MoneySpent.ToString () + " candies was spent in our shop");
	}

	public void Button (string button) {
		Debug.Log ("Works");
		FlurryAgent.Instance.logEvent (button + " button");
	}

	public void UpgradeBought (string name) {
		Debug.Log ("Works");
		FlurryAgent.Instance.logEvent (name + " upgrade bought");
	}

	public void ByeByeMoney(int price) {
		MoneySpent += price;
	}
}