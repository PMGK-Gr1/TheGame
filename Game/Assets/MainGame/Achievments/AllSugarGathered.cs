using UnityEngine;
using System.Collections;

public class AllSugarGathered : MonoBehaviour {

    public int SugarId;
    private Donut donut;
    private bool cleared = false;

    void Start()
    {
        donut = GameController.instance.donut;
    }

	void FixedUpdate () {

        var MySugars = this.GetComponentsInChildren<Sugar>();
        if ((!cleared)&&(MySugars.GetLength(0) == 0))
        {
            donut.achieve.setAllCandy(SugarId);
            
            cleared = true;
        }


	}
}
