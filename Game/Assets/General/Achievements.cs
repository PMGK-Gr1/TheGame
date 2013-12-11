using UnityEngine;
using System.Collections;

public class Achievements : MonoBehaviour {


    public bool death = false;
    
    private RigidDonut donut;

    private bool sugar20 = true, sugar50 = true, sugar100 = true, sugar200 = true, sugar500 = true, sugar1000 = true;
    private bool dist100 = true, dist200 = true, dist500 = true, dist1000 = true, dist2000 = true, dist5000 = true;
    private  bool marathon = true;

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
    void Start()
    {
        donut = RigidDonut.instance;
    }
	
	
	void Update () {

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
        if (dist100 && (donut.transform.position.x/10 >= 100)) Dist100();
        if (dist200 && (donut.transform.position.x/10 >= 200)) Dist200();
        if (dist500 && (donut.transform.position.x/10 >= 500)) Dist500();
        if (dist1000 && (donut.transform.position.x/10 >= 1000)) Dist1000();
        if (dist2000 && (donut.transform.position.x/10 >= 2000)) Dist2000();
        if (dist5000 && (donut.transform.position.x/10 >= 5000)) Dist5000();

      if (marathon && ((PlayerPrefs.GetInt("TotalDistance") + donut.transform.position.x) >= 42195)) Marathon(); 
#endregion

#region rebirths
      if (rebirth1 && (rebirthCount == 1)) Rebirth1();
      if (rebirth4 && (rebirthCount == 4)) Rebirth4();
      if (rebirth8 && (rebirthCount == 8)) Rebirth8();
#endregion

      if (diet && (donut.sugarCubes == 0) && ((donut.transform.position.x / 10) >= 1000)) Diet();
      if (stinger10 && (stingerCount >= 10)) Stinger10();
      if (marmolade5 && (marmoladeCount >= 5)) Marmolade5();

      if (billboard10 && (donut.billboardHits >= 10)) Billboard10();
      if (billboard100 && (PlayerPrefs.GetInt("TotalBillboardHits") + donut.billboardHits >= 100)) Billboard100();
      if (sticky50 && (stickyScore >= 50)) Sticky50();
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








    }
