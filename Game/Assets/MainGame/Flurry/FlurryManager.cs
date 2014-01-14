using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlurryManager : MonoSingleton<FlurryManager> {

	private int UpgradesLaunched = 0;
	private int MoneySpent = 0;
	private int upgradesBought = 0;

	// Use this for initialization
	void Start () {
		UpgradesLaunched = 0;
		Object.DontDestroyOnLoad(gameObject);

		//FlurryAgent.Instance.onStartSession ("DSYXWKHNM2H2C3QVR9HM");

		FlurryAgent.Instance.onStartSession("B35PZVVJMGN7JG7N3VNH"); // Official donut account

		//FlurryAgent.Instance.onStartSession("TDN8Z75V4VQWVFT6YRPQ"); // Debug account
		

		FlurryAgent.Instance.setLogEnabled (true);

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
		FlurryAgent.Instance.onEndSession ();
	}

	public void EndRun(float time, float distance, int candies, string cause, int boostNumber) {
		Dictionary<string, string> parameters = new Dictionary<string,string>();
		parameters.Add("time", CheckInterval(time));
		parameters.Add("distance", CheckInterval(distance));
		parameters.Add("candies", CheckInterval(candies));
		parameters.Add("cause", cause);
		parameters.Add("boostNumber", boostNumber.ToString());
		parameters.Add("upgrades", UpgradesLaunched.ToString());
		FlurryAgent.Instance.logEvent("SingleRun", parameters);
	}

	public void UpgradeLaunch() {
		UpgradesLaunched ++;
	}

	public void CandiesSpent () {
		Dictionary<string, string> parameters = new Dictionary<string, string>();
		parameters.Add("SugarSpent", CheckInterval (MoneySpent));
		parameters.Add("Upgrades bought", upgradesBought.ToString());
		FlurryAgent.Instance.logEvent ("ShopVisit", parameters);
		MoneySpent = 0;
		upgradesBought = 0;
	}

	public void Button (string button) {
		Dictionary<string, string> p = new Dictionary<string, string>();
		p.Add ("ButtonPressed", button);
		FlurryAgent.Instance.logEvent ("Buttons", p);
	}

	public void UpgradeBought (int price) {
		upgradesBought++;
		MoneySpent += price;
	}

	string CheckInterval(float value) {
		if (value < 10.0f) {
			return  "<10";
		} 
		else if (value < 20.0f) {
			return  "10:20";
		} 
		else if (value < 50.0f) {
			return  "20:50";		
		}
		else if (value < 100.0f) {
			return  "50:100";			
		} 
		else if (value < 200.0f) {
			return  "100:200";			
		}
		else if (value < 500.0f) {
			return  "200:500";			
		}
		else if (value < 1000.0f) {
			return  "500:1000";			
		}
		else if (value < 2000.0f) {
			return  "1000:2000";			
		} 
		else if (value < 5000.0f) {
			return  "2000:5000";			
		} 
		else {
			return  "5000<";			
		}
	}
}