using UnityEngine;
using System.Collections;


/// <summary>
/// Now it does nothing.
/// </summary>
public class GameController : MonoSingleton<GameController> {
	
	//private variables
	private string language;
	FlurryAgent flurry = new FlurryAgent();
	
	// Use this for initialization
	void Start () {
		flurry.onStartSession ("DSYXWKHNM2H2C3QVR9HM");
		LoadLanguage();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void LoadLanguage() {
		string language;
		if (PlayerPrefs.HasKey("Language")) {
			language = PlayerPrefs.GetString("Language");
		}
		else {
			language = "English";
			PlayerPrefs.SetString("Language", language);
			PlayerPrefs.Save();
		}
		Localization.loadLanguage(language);
	}

	void OnApplicationPause(bool pause)
	{
		if (pause) {
			flurry.onEndSession ();
				}
		else {
			flurry.onStartSession("DSYXWKHNM2H2C3QVR9HM");
				}
	}

	void OnApplicationQuit()
	{
		flurry.onEndSession();
	}
}
