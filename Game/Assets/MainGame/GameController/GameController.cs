using UnityEngine;
using System.Collections;

public class GameController : MonoSingleton<GameController> {
	
	//private variables
	private string language;

	//public variables
	public Donut donut;
	public Pursuit helicopter;
	public bool chocolateRain = false;
	
	// Use this for initialization
	void Start () {
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
}
