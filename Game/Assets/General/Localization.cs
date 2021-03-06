﻿using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class Localization {

	private Dictionary<string, string> texts;
	private static Localization instance;

	public static Localization Instance {
		get {
			if (instance == null) instance = new Localization();
			return instance;
		}
	}

	public static void loadLanguage(string language) {
		TextAsset textFile = Resources.Load("Localization/" + language) as TextAsset;
		if (textFile == null) {
			Debug.LogError("Localization not supported: " + language);
			textFile = Resources.Load("Localization/English") as TextAsset;
		}
		else {
			Debug.Log("Loaded localization: " + language);
		}
		StringReader textReader = new StringReader(textFile.text);
		Instance.texts = new Dictionary<string, string>();
		string line;
		while ((line = textReader.ReadLine()) != null) {
			string[] pair = line.Split(',');
			Instance.texts.Add(pair[0], pair[1]);
		}
	}

	public static string getText(string key) {
		string ret;
		if (Instance.texts.TryGetValue(key, out ret)) return ret;
		return null;
	}

}