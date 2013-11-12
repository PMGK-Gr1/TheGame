using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class Localization : MonoSingleton<Localization> {

	private Dictionary<string, string> texts;
	private TextAsset textFile;

	public static void loadLanguage(string language) {
		instance.textFile = Resources.Load("Localization/" + language) as TextAsset;
		if (instance.textFile == null) {
			Debug.LogError("Localization not supported");
		}
		StringReader textReader = new StringReader(instance.textFile.text);
		instance.texts = new Dictionary<string, string>();
		string line;
		while ((line = textReader.ReadLine()) != null) {
			string[] pair = line.Split(',');
			instance.texts.Add(pair[0], pair[1]);
		}
	}

	public static string getText(string key){
		return instance.texts[key];
	}
}
