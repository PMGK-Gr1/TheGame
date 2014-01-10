using UnityEngine;
using System.Collections;

public class reset : MonoBehaviour {


   // public GameObject plane;
    public GameObject confirm;

    private bool reseting = false;

    void Start()
    {
        confirm.guiText.fontSize = (int)(Screen.height * 0.3f);
        confirm.guiText.pixelOffset = new Vector2(Screen.width * 0.2f, Screen.height * 0.5f);
    }

    void Update()
    {

       
    }

    void OnMouseUp()
    {
        reseting = true;
      //  plane.transform.localPosition = new Vector3(
      //      plane.transform.localPosition.x,
      //      plane.transform.localPosition.y,
     //       plane.transform.localPosition.z - 20.0f);
        confirm.SetActive(true);
    }

    void OnGUI()
    {
        if (reseting)
        {

            if (GUI.Button(new Rect(Screen.width * 0.2f, Screen.height * 0.8f, Screen.width * 0.2f, Screen.height * 0.1f), "YA RLY"))
            {
                PlayerPrefs.SetInt("Sugar", 0);
                PlayerPrefs.SetInt("TotalSugarEver", 0);
                PlayerPrefs.SetInt("TotalDistance",0);
                PlayerPrefs.SetInt("TotalBillboardHits", 0);
                PlayerPrefs.SetInt("ChocalateRains", 0);
                PlayerPrefs.SetInt("ChosenUpgrade", 0);
                for (int i = 1; i <= 5; i++)
                {
                    PlayerPrefs.SetInt("Upgrade" + i.ToString(), 0);
                }
                PlayerPrefs.SetInt("LastDistance", 0);
                PlayerPrefs.SetInt("LastSugar", 0);
                PlayerPrefs.SetInt("HighestScore", 0);
                PlayerPrefs.Save();
                reseting = false;
                confirm.SetActive(false);
     //       plane.transform.localPosition = new Vector3(
      //      plane.transform.localPosition.x,
     //       plane.transform.localPosition.y,
      //      plane.transform.localPosition.z +20.0f);
            }

            if (GUI.Button(new Rect(Screen.width * 0.6f, Screen.height * 0.8f, Screen.width * 0.2f, Screen.height * 0.1f), "NO WAI"))
            {
                reseting = false;
                confirm.SetActive(false);

       //         plane.transform.localPosition = new Vector3(
      //      plane.transform.localPosition.x,
      //      plane.transform.localPosition.y,
      //      plane.transform.localPosition.z + 20.0f);
            }

        }

    }

}
