using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {
	public string levelName;
	public int levelNumber;
	int skip = 1;
	bool firstLoad = true;
	// Update is called once per frame
	void Update () {
		if (skip > 0) {
			skip--;
			return;
		}
		if (string.IsNullOrEmpty(levelName)) {
			if (Application.GetStreamProgressForLevel(levelNumber) == 1) {
				Application.LoadLevel(levelNumber);
			}
			else {
				Debug.Log("Streaming");
			}
		}
		else {
			if (Application.GetStreamProgressForLevel(levelName) == 1) {
				Application.LoadLevel(levelName);
			}
			else {
				Debug.Log("Streaming");
			}
		}
	}

	void OnLevelWasLoaded(int level) {
		if (firstLoad) {
			firstLoad = false;
			GetComponent<GUITexture>().enabled = true;
		}
		else {
			Destroy(gameObject);
		}
	}

	public static void LoadLevel(string levelName) {
		LoadingScreen loader = (Instantiate(Resources.Load<GameObject>("LoadingScreen")) as GameObject).GetComponent<LoadingScreen>();
		loader.levelName = levelName;

		DontDestroyOnLoad(loader);
		Application.LoadLevel("LoadingScreen");
	}

	public static void LoadLevel(int levelNumber) {
		LoadingScreen loader = (Instantiate(Resources.Load<GameObject>("LoadingScreen")) as GameObject).GetComponent<LoadingScreen>();
		loader.levelNumber = levelNumber;

		DontDestroyOnLoad(loader);
		Application.LoadLevel("LoadingScreen");
	}
}