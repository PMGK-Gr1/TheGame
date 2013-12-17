using UnityEngine;
using System.Collections;

public class Achievements : MonoBehaviour
{


    public bool death = false;

    private Donut donut;

    private bool sugar20 = true, sugar50 = true, sugar100 = true, sugar200 = true, sugar500 = true, sugar1000 = true;
    private bool dist100 = true, dist200 = true, dist500 = true, dist1000 = true, dist2000 = true, dist5000 = true;
    private bool marathon = true;

    private bool rebirth1 = true, rebirth4 = true, rebirth8 = true;
    private int rebirthCount = 0;

    private bool diet = true;

    private bool stinger10 = true;
    private int stingerCount = 0;

    private bool marmolade5 = true;
    private int marmoladeCount = 0;

    private bool billboard10 = true, billboard100 = true;


    private bool sticky50 = true;
    public int stickyScore = 0;

    public bool fiveseconds = false;

    private bool candy1 = false, candy2 = false, candy3 = false, candy4 = false, candy5 = false, candy6 = false, candy7 = false, candy8 = false,
        candy9 = false, candy10 = false, candy11 = false, candy12 = false;

    private bool allCandy1 = true, allCandy2 = true, allCandy5 = true, allCandy12 = true, allCandyDM = true;


    private bool overViaduct = true;
    public bool over = false;


    private bool choco = true;

    private bool warpSpeed = true;

    private bool slippy = true;
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

        if (death && (donut.sugarCubes == 300)) Sugar300();
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


		if (diet && (donut.sugarCubes == 0) && (donutDistance >= 1000)) Diet();
        if (stinger10 && (stingerCount >= 10)) Stinger10();
        if (marmolade5 && (marmoladeCount >= 5)) Marmolade5();

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
    }


    void WarpSpeed()
    {
        warpSpeed = false;
        Debug.Log("Achievement unlocked: Prędkość warpowa panie Sulu");
    }
  void FiveSeconds()
    {
        Debug.Log("Achievement unlocked: Bezsensowny wysiłek");
    }

  void Slippy()
  {
      slippy = false;
      Debug.Log("Achievement unlocked: Śliski pączek");
  }
  public void VerySweet()
  {
      Debug.Log("Achievement unlocked: Ultrasłitaśny");
  }
  public void BurntandSpeed()
  {
      Debug.Log("Achievement unlocked: 88 mil na godzinę");
  }

    public void DonutRebirth()
    {
        rebirthCount++;
    }

    void Rebirth1()
    {
        rebirth1 = false;
        Debug.Log("Achievement unlocked: Nekropączek");
    }

    void Rebirth4()
    {
        rebirth4 = false;
        Debug.Log("Achievement unlocked: Zbyt młody, żeby umierać");
    }

    void Rebirth8()
    {
        rebirth8 = false;
        Debug.Log("Achievement unlocked: Koci pączek");

    }

    public void DonutStinger()
    {
        stingerCount++;
    }
    void Stinger10()
    {
        stinger10 = false;
        Debug.Log("Achievement unlocked: Fakir");
    }


    public void DonutMarmolade()
    { marmoladeCount++; }
    void Marmolade5()
    {
        marmolade5 = false;
        Debug.Log("Achievement unlocked: Słodki szlak");
    }

    void Sugar20()
    {
        sugar20 = false;
        Debug.Log("Achievement unlocked: Słodka przekąska");
    }

    void Sugar50()
    {
        sugar50 = false;
        Debug.Log("Achievement unlocked: (50 cukierków)");
    }
    void Sugar100()
    {
        sugar100 = false;
        Debug.Log("Achievement unlocked: (100 cukierków)");
    }
    void Sugar200()
    {
        sugar200 = false;
        Debug.Log("Achievement unlocked: Koneser cukru");
    }
    void Sugar500()
    {
        sugar500 = false;
        Debug.Log("Achievement unlocked: Cukrowy nałogowiec");
    }
    void Sugar1000()
    {
        sugar1000 = false;
        Debug.Log("Achievement unlocked: (1000 cukierków)");
    }

    void Sugar300()
    {
        Debug.Log("Achievement unlocked: THIS IS MADNESS");
    }


    void Dist100()
    {
        dist100 = false;
        Debug.Log("Achievement unlocked: Rozprostawnie nóg");
    }

    void Dist200()
    {
        dist200 = false;
        Debug.Log("Achievement unlocked: Spacerek");
    }

    void Dist500()
    {
        dist500 = false;
        Debug.Log("Achievement unlocked: Wycieczka");
    }

    void Dist1000()
    {
        dist1000 = false;
        Debug.Log("Achievement unlocked: Wyprawa");
    }

    void Dist2000()
    {
        dist2000 = false;
        Debug.Log("Achievement unlocked: Podróż dookoła świata");
    }

    void Dist5000()
    {
        dist5000 = false;
        Debug.Log("Achievement unlocked: Gdzie żaden pączek nie dotarł");
    }

    void Marathon()
    {
        marathon = false;
        Debug.Log("Achievement unlocked: Maraton");
    }

    void Diet()
    {
        diet = false;
        Debug.Log("Achievement unlocked: Dieta");
    }


    void Billboard10()
    {
        billboard10 = false;
        Debug.Log("Achievement unlocked: Pączek zniszczenia");
    }

    void Billboard100()
    {
        billboard100 = false;
        Debug.Log("Achievement unlocked: AdBlock");
    }

    void Sticky50()
    {
        Debug.Log("Achievement unlocked: Lepkie ręce");
        sticky50 = false;
    }

    void AllCandy1()
    {
        Debug.Log("Achievement unlocked: (wszystkie z 1 formacji)");
        allCandy1 = false;
    }

    void AllCandy2()
    {
        Debug.Log("Achievement unlocked: (wszystkie z 2 formacji)");
        allCandy2 = false;
    }

    void AllCandy5()
    {
        Debug.Log("Achievement unlocked: (wszystkie z 5 formacji)");
        allCandy5 = false;
    }
    void AllCandy12()
    {
        Debug.Log("Achievement unlocked: (wszystkie ze wszystkich)");
        allCandy12 = false;
    }
    void AllCandyDM()
    {
        Debug.Log("Achievement unlocked:    DONUT MADNESS");
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
        Debug.Log("Achievement unlocked: Trasa alternatywna");
        overViaduct = false;
    }


    public void Fall10()
     {
         Debug.Log("Achievement unlocked: Górnik");
    }
    void Choco()
    {
        choco = false;
        Debug.Log("Achievement unlocked: Apokalipsa");
    }







}

