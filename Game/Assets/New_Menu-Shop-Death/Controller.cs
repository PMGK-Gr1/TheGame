﻿using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public GameObject Menu, Shop, Busted, Options;
    public GameObject[] Upgrades;
    public bool optionsOn = false;
    public bool inshop = false;
    public bool deathscreen = false;
    int died;
	// Use this for initialization

    void Awake()
    {

        died = PlayerPrefs.GetInt("died");
        Menu.SetActive(false);
    }
	void Start () {


        if (died == 1)
        {
            BackToMenu(true);
            PlayerPrefs.SetInt("died", 0);
            deathscreen = true;
        }
        else
        {
            Menu.SetActive(true);
        }

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsOn) { FromOptions(); optionsOn = false; }
            else if (inshop) { BackToMenu(); inshop = false; }
            else if (deathscreen) { DeathToMenu(); deathscreen = false; }
            else Application.Quit();

        }
	}

    public void DeathToShop()
    {
        Menu.SetActive(false);
        StartCoroutine(Move(4.0f, true));



    }

    public void DeathToMenu()
    {
        StartCoroutine(Move(2.0f, true));
    }
    public void ToOptions()
    {
        optionsOn = true;
        StartCoroutine(OptionsMove(true));
    }

    public void FromOptions()
    {
        optionsOn = false;
        StartCoroutine(OptionsMove(false));

    }

    IEnumerator OptionsMove(bool on)
    {
        Vector3 a;
        if(on) a = 3 * Vector3.down;
        else a = 3* Vector3.up;
        var OptionsPosition = Options.transform.position + a;
          float t = 0;
          do
          {
              yield return new WaitForSeconds(0.0001f);
              t += 1.0f * Time.deltaTime;
              Options.transform.position = Vector3.Lerp(Options.transform.position,
                  OptionsPosition,
                  t / 3.0f);
          } while (Options.transform.position != OptionsPosition);
         yield return null;
    }


    
    public void ToShop()
    {
        StartCoroutine(Move(2.0f,true));
       
    
    }

    public void BackToMenu(bool fast=false)
    {
        StartCoroutine(Move(2.0f,false,fast));
    }

    IEnumerator Move(float d, bool left, bool fast=false)
    {
        Vector3 a;
        if(left) a = d * Vector3.left;
        else a = d * Vector3.right;

        var MenuPosition = Menu.transform.position + a;
        var ShopPosition = Shop.transform.position + a;
        var BustedPosition = Busted.transform.position + a;

        Vector3[] UpgradePositions = new Vector3[Upgrades.GetLength(0)];
        for (int i = 0; i < Upgrades.GetLength(0); i++)
        {
            UpgradePositions[i] = Upgrades[i].transform.position + a;

        }
            float t = 0;
 
            do
            {
                yield return new WaitForSeconds(0.0001f);
                t += 0.5f * Time.deltaTime;
                float s;
                if (fast) s = 2.0f;
                else s = 2*  t / d;

                for (int i = 0; i < Upgrades.GetLength(0); i++)
                {
                    Upgrades[i].transform.position = Vector3.Lerp(Upgrades[i].transform.position, UpgradePositions[i], s);
                }
                        
                
                Menu.transform.position = Vector3.Lerp(Menu.transform.position, MenuPosition, s);
                        
                Shop.transform.position = Vector3.Lerp(Shop.transform.position, ShopPosition, s);
                        
                Busted.transform.position = Vector3.Lerp(Busted.transform.position, BustedPosition, s);

            } while (Menu.transform.position != MenuPosition && Shop.transform.position != ShopPosition
                && Busted.transform.position != BustedPosition);
        
            Menu.SetActive(true);
            yield return null;
        
    }

}