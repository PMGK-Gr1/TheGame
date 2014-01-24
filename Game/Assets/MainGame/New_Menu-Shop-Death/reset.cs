using UnityEngine;
using System.Collections;

public class reset : MonoBehaviour {


    public GameObject warning;
  

    void Start()
    {
       
    }

    void Update()
    {

       
    }

    void OnMouseUp()
    {
        warning.SetActive(true);
     
      //  plane.transform.localPosition = new Vector3(
      //      plane.transform.localPosition.x,
      //      plane.transform.localPosition.y,
     //       plane.transform.localPosition.z - 20.0f);
            
    }



    public void rst()
    {

        PlayerPrefs.SetInt("Sugar", 0);
        PlayerPrefs.SetInt("TotalSugarEver", 0);
        PlayerPrefs.SetInt("TotalDistance", 0);
        PlayerPrefs.SetInt("TotalBillboardHits", 0);
        PlayerPrefs.SetInt("ChocalateRains", 0);
        PlayerPrefs.SetInt("ChosenUpgrade", 0);
        for (int i = 1; i <= 5; i++)
        {
            PlayerPrefs.SetInt("Upgrade" + i, 0);
        }

        for (int i = 1; i < 34; i++)
        {
            PlayerPrefs.SetInt("Achievement" + i, 0);
        }


        PlayerPrefs.SetInt("LastDistance", 0);
        PlayerPrefs.SetInt("LastSugar", 0);
        PlayerPrefs.SetInt("HighestScore", 0);
        PlayerPrefs.Save();
        warning.SetActive(false);

    }

   

    }


