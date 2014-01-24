using UnityEngine;
using System.Collections;

public class SugarCounterScript : MonoBehaviour {

	// Use this for initialization]
    public GUIText SugarCount;
    
	void Start () {

	this.guiTexture.pixelInset = new Rect(
            Screen.width * 0.755f,
            Screen.height * 0.5f,
            Screen.width * 0.2f,
            Screen.width * 0.1f);
    SugarCount.fontSize = (int)(Screen.height * 0.07f);
    SugarCount.pixelOffset = new Vector2(Screen.width * 0.78f, Screen.height * 0.55f);
	
    }

    public void NO()
    {
        StartCoroutine("no");
    }


    IEnumerator no()
    {
        SugarCount.color = Color.red;
        yield return new WaitForSeconds(0.4f);
        SugarCount.color = Color.white;
        yield return null;

    }
	// Update is called once per frame
	void Update () {
        SugarCount.text = PlayerPrefs.GetInt("Sugar").ToString();
	
	}
}
