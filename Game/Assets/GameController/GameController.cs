using UnityEngine;
using System.Collections;


/// <summary>
/// Now it does nothing.
/// </summary>
public class GameController : MonoSingleton<GameController> {
	
	//private variables
	private string language;
	
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
