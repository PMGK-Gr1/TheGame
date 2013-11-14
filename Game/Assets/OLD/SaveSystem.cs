using UnityEngine;
using System.Collections;

/// <summary>
/// Saving and loading game data
/// </summary>/

public class SaveSystem : MonoBehaviour {
	
	//private variables
	private static int score;
	private static string language;
	private bool first = false;
	
	// Use this for initialization
	void Start () {
		//checking if it's first run
		if(!(PlayerPrefs.HasKey ("Score")))
		{
			score = 0;
			first = true;
		}
		
		if(!(PlayerPrefs.HasKey("Language")))
		{
			//language = Application.systemLanguage.ToString();
			language = "English";
			first = true;
		}
		
		if(first)
		{
			Save ();
		}
		
		Load ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// Loading game data
	public static void Load(){
		language = PlayerPrefs.GetString ("Language");
		score = PlayerPrefs.GetInt ("Score");
	}
	
	// Saving game data
	public static void Save(){
	//	score += CandyPicker.GetCandies();
		PlayerPrefs.SetString("Language", language);
		PlayerPrefs.SetInt ("Score", score);
	}
	
	public static string GetLoadedLanguage(){
		return language;
	}
	
	public static void ChangeLanguage(string changedLanguage){
		//To do when changing language will be done
		language = changedLanguage;
	}
	
	public static int GetScore(){
		return score;
	}
}
