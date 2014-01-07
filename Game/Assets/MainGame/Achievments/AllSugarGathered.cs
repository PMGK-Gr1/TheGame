using UnityEngine;
using System.Collections;

public class AllSugarGathered : MonoBehaviour {

    public int SugarId;
    private Donut donut;
    private bool cleared = false;
    private Sugar[] MySugars;
    private Vector3[] pos;
    void Awake()
    {
        donut = GameController.instance.donut;
        MySugars = this.GetComponentsInChildren<Sugar>();
        pos = new Vector3[MySugars.Length];
        for (int i = 0; i < MySugars.Length; i++) pos[i] = MySugars[i].transform.localPosition;
    }

    void FixedUpdate()
    {

        
        if ((!cleared)&&(MySugars.GetLength(0) == 0))
        {
            donut.achieve.setAllCandy(SugarId);
            
            cleared = true;
        }
	}

   void OnEnable()
    {

        for (int i = 0; i < MySugars.Length; i++)
        {
            MySugars[i].transform.localPosition = pos[i];
            MySugars[i].gameObject.SetActive(true);
        }

    }
}
