using UnityEngine;
using System.Collections;

public class AllSugarGathered : MonoBehaviour {

    public int name;
    private RigidDonut donut;
    private bool cleared = false;

    void Start()
    {
        donut = RigidDonut.instance;
    }

	void FixedUpdate () {

        var MySugars = this.GetComponentsInChildren<Sugar>();
        if ((!cleared)&&(MySugars.GetLength(0) == 0))
        {
            donut.achieve.setAllCandy(name);
            
            cleared = true;
        }


	}
}
