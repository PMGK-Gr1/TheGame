using UnityEngine;
using System.Collections;

public class FlurryManager : MonoSingleton<FlurryManager> {

	private int UpgradesLaunched = 0;
	private int MoneySpent;

	void OnLevelWasLoaded(int level) {
#if !UNITY_EDITOR
		FlurryAgent.Instance.onEndSession ();
#endif
	}

	// Use this for initialization
	void Start () {
		UpgradesLaunched = 0;
		Object.DontDestroyOnLoad(gameObject);
#if !UNITY_EDITOR
		FlurryAgent.Instance.onStartSession ("DSYXWKHNM2H2C3QVR9HM");
		FlurryAgent.Instance.setLogEnabled (true);
		FlurryAgent.Instance.logEvent ("Scene " + Application.loadedLevelName + " loaded");
		FlurryAgent.Instance.onPageView ();
#endif
	}

	public void OnApplicationPause (bool pause) {
#if !UNITY_EDITOR
		if (pause) {
			FlurryAgent.Instance.onEndSession ();		
		}
		else {
			FlurryAgent.Instance.onStartSession("DSYXWKHNM2H2C3QVR9HM");
		}
#endif
	}

	public void OnApplicationQuit() {
#if !UNITY_EDITOR
		FlurryAgent.Instance.logEvent ("Application closed");
		FlurryAgent.Instance.onEndSession ();
#endif
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
#if !UNITY_EDITOR
		FlurryAgent.Instance.logEvent (button + " button");
#endif
	}

	public void UpgradeBought (string name, int price) {
		Debug.Log ("Works");
		MoneySpent += price;
		FlurryAgent.Instance.logEvent (name + " upgrade bought");
	}
}