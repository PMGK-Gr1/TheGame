using UnityEngine;
using System.Collections;

public class Achievements : MonoBehaviour
{


    public bool death = false;

    private Donut donut;

    private bool sugar20 = true, sugar50 = true, sugar100 = true, sugar200 = true, sugar500 = true, sugar1000 = true, sugar300 = true;
    private bool diabetes = true;
    private bool dist100 = true, dist200 = true, dist500 = true, dist1000 = true, dist2000 = true, dist5000 = true;
    private bool marathon = true;

    private bool rebirth1 = true, rebirth4 = true, rebirth8 = true;
    private int rebirthCount = 0;

    //private bool diet = true;

    private bool stinger10 = true;
    private int stingerCount = 0;

   // private bool marmolade5 = true;
   // private int marmoladeCount = 0;

    private bool billboard10 = true, billboard100 = true;


    private bool sticky50 = true;
    public int stickyScore = 0;

    public bool fiveseconds = false;

    private bool candy1 = false, candy2 = false, candy3 = false, candy4 = false, candy5 = false, candy6 = false, candy7 = false, candy8 = false,
        candy9 = false, candy10 = false, candy11 = false, candy12 = false;

    private bool allCandy1 = true, allCandy2 = true, allCandy5 = true, allCandy12 = true, allCandyDM = true;

    private bool fall10 = true;


    private bool overViaduct = true;
    public bool over = false;


    private bool choco = true;

    private bool warpSpeed = true;

    private bool slippy = true;

    public bool donutfell = false;

    public bool verysweet = true;

    private bool burntandspeed = true;
    public bool isBurntandSpeed = false;

    void Awake()
    {
        if(PlayerPrefs.GetInt("Achievement1")!=0) sugar20 = false;
        if(PlayerPrefs.GetInt("Achievement2")!=0) sugar50 = false;
        if(PlayerPrefs.GetInt("Achievement3")!=0) sugar100 = false;
        if(PlayerPrefs.GetInt("Achievement4")!=0) sugar200 = false;
        if(PlayerPrefs.GetInt("Achievement5")!=0) sugar500 =false;
        if(PlayerPrefs.GetInt("Achievement6")!=0) sugar1000 = false;
        if(PlayerPrefs.GetInt("Achievement7")!=0) sugar300 = false;
        if(PlayerPrefs.GetInt("Achievement8")!=0) diabetes = false;
        if(PlayerPrefs.GetInt("Achievement9")!=0) allCandy1 = false;
        if(PlayerPrefs.GetInt("Achievement10")!=0) allCandy2 = false;
        if(PlayerPrefs.GetInt("Achievement11")!=0) allCandy5 = false;
        if(PlayerPrefs.GetInt("Achievement12")!=0) allCandy12 = false;
        if(PlayerPrefs.GetInt("Achievement13")!=0) allCandyDM = false;
        if(PlayerPrefs.GetInt("Achievement14")!=0) dist100 = false;
        if(PlayerPrefs.GetInt("Achievement15")!=0) dist200 = false;
        if(PlayerPrefs.GetInt("Achievement16")!=0) dist500 = false;
        if(PlayerPrefs.GetInt("Achievement17")!=0) dist1000 = false;
        if(PlayerPrefs.GetInt("Achievement18")!=0) dist2000 = false;
        if(PlayerPrefs.GetInt("Achievement19")!=0) dist5000 = false;
        if(PlayerPrefs.GetInt("Achievement20")!=0) marathon = false;
        if(PlayerPrefs.GetInt("Achievement21")!=0) rebirth1 = false;
        if(PlayerPrefs.GetInt("Achievement22")!=0) rebirth4 = false;
        if(PlayerPrefs.GetInt("Achievement23")!=0) rebirth8 = false;
        if(PlayerPrefs.GetInt("Achievement24")!=0) slippy = false;
        if(PlayerPrefs.GetInt("Achievement25")!=0) sticky50 =false;
        if(PlayerPrefs.GetInt("Achievement26")!=0) billboard10 = false;
        if(PlayerPrefs.GetInt("Achievement27")!=0) billboard100 = false;
        if(PlayerPrefs.GetInt("Achievement28")!=0) stinger10 = false;
        if(PlayerPrefs.GetInt("Achievement29")!=0) fall10 = false;
        if(PlayerPrefs.GetInt("Achievement30")!=0) warpSpeed = false;
        if(PlayerPrefs.GetInt("Achievement31")!=0) choco = false;
        if(PlayerPrefs.GetInt("Achievement32")!=0) overViaduct = false;
        if(PlayerPrefs.GetInt("Achievement33")!=0) burntandspeed = false;
        if(PlayerPrefs.GetInt("Achievement34") != 0) fiveseconds = false;
    }



    void Start()
    {
        donut = GameController.instance.donut;
    }


    void Update()
    {
		float donutDistance = donut.GetDistanceTravelled();

        #region sugar quantity
        if (sugar20 && (donut.sugarCubes >= 20)) Sugar20();
        if (sugar50 && (donut.sugarCubes >= 50)) Sugar50();
        if (sugar100 && (donut.sugarCubes >= 100)) Sugar100();
        if (sugar200 && (donut.sugarCubes >= 200)) Sugar200();
        if (sugar500 && (donut.sugarCubes >= 500)) Sugar500();
        if (sugar1000 && (donut.sugarCubes >= 1000)) Sugar1000();

        if (sugar300 &&death && (donut.sugarCubes == 300)) Sugar300();

        if (diabetes && (PlayerPrefs.GetInt("TotalSugarEver") + donut.sugarCubes) > 100000) Diabetes();
        #endregion
        #region distance
		if (dist100 && (donutDistance >= 100)) Dist100();
		if (dist200 && (donutDistance >= 200)) Dist200();
		if (dist500 && (donutDistance >= 500)) Dist500();
		if (dist1000 && (donutDistance >= 1000)) Dist1000();
		if (dist2000 && (donutDistance >= 2000)) Dist2000();
		if (dist5000 && (donutDistance >= 5000)) Dist5000();

		if (marathon && ((PlayerPrefs.GetInt("TotalDistance") + donutDistance) >= 42195)) Marathon();
        #endregion
        #region rebirths
        if (rebirth1 && (rebirthCount == 1)) Rebirth1();
        if (rebirth4 && (rebirthCount == 4)) Rebirth4();
        if (rebirth8 && (rebirthCount == 8)) Rebirth8();
        #endregion
        #region allcandies
        if (allCandy1 && (AllCandyCount() >= 1)) AllCandy1();
        if (allCandy2 && (AllCandyCount() >= 2)) AllCandy2();
        if (allCandy5 && (AllCandyCount() >= 5)) AllCandy5();
        if (allCandy12 && (AllCandyCount() >= 12)) AllCandy12();
        if (allCandyDM && candy9) AllCandyDM();
        #endregion


		//if (diet && (donut.sugarCubes == 0) && (donutDistance >= 1000)) Diet();
        if (stinger10 && (stingerCount >= 10)) Stinger10();
       // if (marmolade5 && (marmoladeCount >= 5)) Marmolade5();

        if (billboard10 && (donut.billboardHits >= 10)) Billboard10();
        if (billboard100 && (PlayerPrefs.GetInt("TotalBillboardHits") + donut.billboardHits >= 100)) Billboard100();
        if (sticky50 && (stickyScore >= 50)) Sticky50();
        if (overViaduct && over) OverViaduct();
        if (fiveseconds && death) FiveSeconds();
        if (choco&&(PlayerPrefs.GetInt("ChocalateRains") + donut.chocoRains) >= 10) Choco();
		if (donut.gameObject.GetComponent<Rigidbody> () != null) {
						if (warpSpeed && (donut.rigidbody.velocity.x > 100)) WarpSpeed ();
				}
        if (slippy && (donut.slippyCount >= 5)) Slippy();

        if(fall10 && donutfell && death && PlayerPrefs.GetInt("Falls") >= 9) Fall10();

        if (burntandspeed && isBurntandSpeed) BurntandSpeed();
    }

    void Diabetes()
    {
        PlayerPrefs.SetInt("Achievement8", 1);
        diabetes = false;
    }

    void WarpSpeed()
    {
        PlayerPrefs.SetInt("Achievement30", 1);

        warpSpeed = false;
        //Debug.Log("Achievement unlocked: Prędkość warpowa panie Sulu");
    }
  void FiveSeconds()
    {
        fiveseconds = false;
        PlayerPrefs.SetInt("Achievement34", 1);

        //Debug.Log("Achievement unlocked: Bezsensowny wysiłek");
    }

  void Slippy()
  {
      PlayerPrefs.SetInt("Achievement24", 1);

      slippy = false;
      //Debug.Log("Achievement unlocked: Śliski pączek");
  }
  /*public void VerySweet()
  {
      //Debug.Log("Achievement unlocked: Ultrasłitaśny");
  }*/
  public void BurntandSpeed()
  {
      PlayerPrefs.SetInt("Achievement33", 1);
      
      burntandspeed = false;
      //Debug.Log("Achievement unlocked: 88 mil na godzinę");
  }

    public void DonutRebirth()
    {

        rebirthCount++;
    }

    void Rebirth1()
    {
        PlayerPrefs.SetInt("Achievement21", 1);

        rebirth1 = false;
        //Debug.Log("Achievement unlocked: Nekropączek");
    }

    void Rebirth4()
    {
        PlayerPrefs.SetInt("Achievement22", 1);

        rebirth4 = false;
        //Debug.Log("Achievement unlocked: Zbyt młody, żeby umierać");
    }

    void Rebirth8()
    {
        PlayerPrefs.SetInt("Achievement23", 1);
        rebirth8 = false;
        //Debug.Log("Achievement unlocked: Koci pączek");

    }

    public void DonutStinger()
    {
        stingerCount++;
    }
    void Stinger10()
    {
        PlayerPrefs.SetInt("Achievement28", 1);
        stinger10 = false;
        //Debug.Log("Achievement unlocked: Fakir");
    }


    /*public void DonutMarmolade()
    { marmoladeCount++; }
    void Marmolade5()
    {

        marmolade5 = false;
        //Debug.Log("Achievement unlocked: Słodki szlak");
    }*/

    void Sugar20()
    {
        PlayerPrefs.SetInt("Achievement1", 1);
        sugar20 = false;
        //Debug.Log("Achievement unlocked: Słodka przekąska");
    }

    void Sugar50()
    {
        PlayerPrefs.SetInt("Achievement2", 1);
        sugar50 = false;
        //Debug.Log("Achievement unlocked: (50 cukierków)");
    }
    void Sugar100()
    {
        PlayerPrefs.SetInt("Achievement3", 1);
        sugar100 = false;
        //Debug.Log("Achievement unlocked: (100 cukierków)");
    }
    void Sugar200()
    {
        PlayerPrefs.SetInt("Achievement4", 1);
        sugar200 = false;
        //Debug.Log("Achievement unlocked: Koneser cukru");
    }
    void Sugar500()
    {
        PlayerPrefs.SetInt("Achievement5", 1);
        sugar500 = false;
        //Debug.Log("Achievement unlocked: Cukrowy nałogowiec");
    }
    void Sugar1000()
    {
        PlayerPrefs.SetInt("Achievement6", 1);
        sugar1000 = false;
        //Debug.Log("Achievement unlocked: (1000 cukierków)");
    }

    void Sugar300()
    {
        PlayerPrefs.SetInt("Achievement7", 1);
        sugar300 = false;
        //Debug.Log("Achievement unlocked: THIS IS MADNESS");
    }


    void Dist100()
    {
        PlayerPrefs.SetInt("Achievement14", 1);
        dist100 = false;
        //Debug.Log("Achievement unlocked: Rozprostawnie nóg");
    }

    void Dist200()
    {
        PlayerPrefs.SetInt("Achievement15", 1);
        dist200 = false;
        //Debug.Log("Achievement unlocked: Spacerek");
    }

    void Dist500()
    {
        PlayerPrefs.SetInt("Achievement16", 1);
        dist500 = false;
        //Debug.Log("Achievement unlocked: Wycieczka");
    }

    void Dist1000()
    {
        PlayerPrefs.SetInt("Achievement17", 1);
        dist1000 = false;
        //Debug.Log("Achievement unlocked: Wyprawa");
    }

    void Dist2000()
    {
        PlayerPrefs.SetInt("Achievement18", 1);
        dist2000 = false;
        //Debug.Log("Achievement unlocked: Podróż dookoła świata");
    }

    void Dist5000()
    {
        PlayerPrefs.SetInt("Achievement19", 1);
        dist5000 = false;
        //Debug.Log("Achievement unlocked: Gdzie żaden pączek nie dotarł");
    }

    void Marathon()
    {
        PlayerPrefs.SetInt("Achievement20", 1);
        marathon = false;
        //Debug.Log("Achievement unlocked: Maraton");
    }

   /* void Diet()
    {
        diet = false;
        //Debug.Log("Achievement unlocked: Dieta");
    }*/


    void Billboard10()
    {
        PlayerPrefs.SetInt("Achievement26", 1);
        billboard10 = false;
        //Debug.Log("Achievement unlocked: Pączek zniszczenia");
    }

    void Billboard100()
    {
        PlayerPrefs.SetInt("Achievement27", 1);
        billboard100 = false;
        //Debug.Log("Achievement unlocked: AdBlock");
    }

    void Sticky50()
    {
        //Debug.Log("Achievement unlocked: Lepkie ręce");
        PlayerPrefs.SetInt("Achievement25", 1);
        sticky50 = false;
    }

    void AllCandy1()
    {
        //Debug.Log("Achievement unlocked: (wszystkie z 1 formacji)");
        PlayerPrefs.SetInt("Achievement9", 1);
        allCandy1 = false;
    }

    void AllCandy2()
    {
        //Debug.Log("Achievement unlocked: (wszystkie z 2 formacji)");
        PlayerPrefs.SetInt("Achievement10", 1);
        allCandy2 = false;
    }

    void AllCandy5()
    {
        //Debug.Log("Achievement unlocked: (wszystkie z 5 formacji)");
        PlayerPrefs.SetInt("Achievement11", 1);
        allCandy5 = false;
    }
    void AllCandy12()
    {
        //Debug.Log("Achievement unlocked: (wszystkie ze wszystkich)");
        PlayerPrefs.SetInt("Achievement12", 1);
        allCandy12 = false;
    }
    void AllCandyDM()
    {
        //Debug.Log("Achievement unlocked:    DONUT MADNESS");
        PlayerPrefs.SetInt("Achievement13", 1);
        allCandyDM = false;
    }

    int AllCandyCount()
    {
        int count = 0;
        if (candy1) count++;
        if (candy2) count++;
        if (candy3) count++;
        if (candy4) count++;
        if (candy5) count++;
        if (candy6) count++;
        if (candy7) count++;
        if (candy8) count++;
        if (candy9) count++;
        if (candy10) count++;
        if (candy11) count++;
        if (candy12) count++;
        return count;
    }

    public void setAllCandy(int f)
    {
        if (f == 1) candy1 = true;
        if (f == 2) candy2 = true;
        if (f == 3) candy3 = true;
        if (f == 4) candy4 = true;
        if (f == 5) candy5 = true;
        if (f == 6) candy6 = true;
        if (f == 7) candy7 = true;
        if (f == 8) candy8 = true;
        if (f == 9) candy9 = true;
        if (f == 10) candy10 = true;
        if (f == 11) candy11 = true;
        if (f == 12) candy12 = true;


    }


    void OverViaduct()
    {
        PlayerPrefs.SetInt("Achievement32", 1);
        //Debug.Log("Achievement unlocked: Trasa alternatywna");
        overViaduct = false;
    }


    public void Fall10()
     {
         PlayerPrefs.SetInt("Achievement29", 1);
         fall10 = false;
         //Debug.Log("Achievement unlocked: Górnik");
    }
    void Choco()
    {
        PlayerPrefs.SetInt("Achievement31", 1);
        choco = false;
        //Debug.Log("Achievement unlocked: Apokalipsa");
    }







}

