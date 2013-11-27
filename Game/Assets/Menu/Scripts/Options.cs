using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour
{

    public GameObject[] MoveableObjects;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

    }


   public void MoveAway() {


       foreach (var obj in MoveableObjects)
       {
           obj.GetComponent<Animator>().SetBool("state2", false);

           obj.GetComponent<Animator>().SetBool("state1", true);
           
       }
      
   }

   public void ComeBack()
   {
       foreach (var obj in MoveableObjects)
       {
           obj.GetComponent<Animator>().SetBool("state2", true);
           obj.GetComponent<Animator>().SetBool("state1", false);

       }
     
     

   }
    



}