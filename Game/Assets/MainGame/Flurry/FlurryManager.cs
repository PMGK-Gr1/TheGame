using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlurryManager : MonoSingleton<FlurryManager> {

	private int UpgradesLaunched = 0;
	private int MoneySpent;

	void OnLevelWasLoaded(int level) {
		FlurryAgent.Instance.onEndSession ();
	}

	// Use this for initialization
	void Start () {
		UpgradesLaunched = 0;
		Object.DontDestroyOnLoad(gameObject);
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
		Dictionary<string, string> p = CheckInterval (time, "RunLength");
		FlurryAgent.Instance.logEvent ("SingleRun", p);
	}

	public void Distance(float distance) {
		Debug.Log ("Works");
		Dictionary<string, string> p = CheckInterval (distance, "Distance");
		FlurryAgent.Instance.logEvent ("SingleRun", p);
	}

	public void CandiesPicked(int candies) {
		Debug.Log ("Works");
		Dictionary<string, string> p = CheckInterval (candies, "CandiesPicked");
		FlurryAgent.Instance.logEvent ("SingleRun", p);
	}

	public void BoostNumberPicked (int number) {
		Debug.Log ("Works");
		Dictionary<string, string> p = CheckInterval (number, "BoostNumberPicked");
		FlurryAgent.Instance.logEvent ("SingleRun", p);
	}

	public void BoostPicked (string name) {
		Debug.Log ("Works");
		Dictionary<string, string> p = new Dictionary<string, string>();
		p.Add ("BoostPicked", name);
		FlurryAgent.Instance.logEvent ("SingleRun", p);
	}

	public void UpgradeLaunch(string name) {
		Debug.Log ("Works");
		Dictionary<string, string> p = new Dictionary<string, string>();
		p.Add ("UpgradeLaunched", name);
		FlurryAgent.Instance.logEvent ("SingleRun", p);
		UpgradesLaunched ++;
	}

	public void TotalUpgrades () {
		Debug.Log ("Works");
		Dictionary<string, string> p = CheckInterval (UpgradesLaunched, "TotalUpgradesLaunched");
		FlurryAgent.Instance.logEvent ("SingleRun", p);
	}

	public void DeathCause (string cause) {
		Debug.Log ("Works");
		Dictionary<string, string> p = new Dictionary<string, string>();
		p.Add ("Death", cause);
		FlurryAgent.Instance.logEvent ("SingleRun", p);
	}

	public void CandiesSpent () {
		Debug.Log ("Works");
		Dictionary<string, string> p = CheckInterval (MoneySpent, "SugarSpent");
		FlurryAgent.Instance.logEvent ("SingleShopVisit", p);
	}

	public void Button (string button) {
		Debug.Log ("Works");
		Dictionary<string, string> p = new Dictionary<string, string>();
		p.Add ("ButtonPressed", button);
		FlurryAgent.Instance.logEvent ("General", p);
	}

	public void UpgradeBought (string name, int price) {
		Debug.Log ("Works");
		MoneySpent += price;
		Dictionary<string, string> p = new Dictionary<string, string>();
		p.Add ("UpgradeBought", name);
		FlurryAgent.Instance.logEvent ("SingleShopVisit", p);
	}

	Dictionary<string, string> CheckInterval(float value, string pKey) {
		Debug.Log (pKey + " " + value);
		Dictionary<string, string> p = new Dictionary<string, string> ();
		if (value < 10.0f) {
			p.Add (pKey, "<10");
		} 
		else if (value < 20.0f) {
			p.Add (pKey, "<20");
		} 
		else if (value < 50.0f) {
			p.Add (pKey, "<50");		
		}
		else if (value < 100.0f) {
			p.Add (pKey, "<100");			
		} 
		else if (value < 200.0f) {
			p.Add (pKey, "<200");			
		}
		else if (value < 500.0f) {
			p.Add (pKey, "<500");			
		}
		else if (value < 1000.0f) {
			p.Add (pKey, "<1000");			
		}
		else if (value < 2000.0f) {
			p.Add (pKey, "<2000");			
		} 
		else if (value < 5000.0f) {
			p.Add (pKey, "<5000");			
		} 
		else {
			p.Add (pKey, ">=5000");			
		}
		return p;
	}
}