using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour
{

    public GameObject[] MoveableObjects;
    private bool options = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (options) ComeBack();
            else Application.Quit();
        }
    }

   public void MoveAway() {


       foreach (var obj in MoveableObjects)
       {
           obj.GetComponent<Animator>().SetBool("state2", false);

           obj.GetComponent<Animator>().SetBool("state1", true);
           
       }
       options = true;
   }

   public void ComeBack()
   {
       foreach (var obj in MoveableObjects)
       {
           obj.GetComponent<Animator>().SetBool("state2", true);
           obj.GetComponent<Animator>().SetBool("state1", false);

       }
       options = false;
     

   }

 



}