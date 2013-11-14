using UnityEngine;
using System.Collections;


/// <summary>
/// Now it does nothing.
/// </summary>
public class GameController : MonoBehaviour {
	
	//private variables
	private string language;
	
	// Use this for initialization
	void Start () {
		language = SaveAndLoad.GetLoadedLanguage();
		Localization.loadLanguage(language);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
