using UnityEngine;
using System.Collections;

public class UpgradeEquipScript : MonoBehaviour
{

    public int UpgradeId;
    public UpgradeSlotScript slot;
    //private Rect pixel;

    Vector3 p;
    private bool inMove = false;
    // Use this for initialization
    void Awake()
    {


        this.guiTexture.pixelInset = new Rect(0.0f,
            0.0f,
            Screen.width * 0.1f,
            Screen.width * 0.1f);

        this.transform.position = new Vector3(2.0f + 0.305f, (0.65f - 2.0f * (float)UpgradeId / 10.0f), this.transform.position.z);

        //pixel = this.guiTexture.pixelInset;


        p = transform.position;
        
    }




    // Update is called once per frame
    void Update()
    {


        if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Began) && this.guiTexture.HitTest(Input.GetTouch(0).position) && slot.swiper.canSwipe)
        {
            inMove = true;
            slot.swiper.canSwipe = false;
            p = transform.position;
        }

        if (inMove)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (
                    Mathf.Sqrt(Mathf.Pow((this.transform.position.x - slot.transform.position.x), 2.0f) + Mathf.Pow((this.transform.position.y - slot.transform.position.y), 2.0f))
                    < 0.12f)
                    slot.Equip(UpgradeId);
                if (inMove) transform.position = p;
                inMove = false;
                slot.swiper.canSwipe = true;

            }

            if (Input.touchCount > 0 && inMove && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(Input.GetTouch(0).position.x / Screen.width, Input.GetTouch(0).position.y / Screen.height, this.transform.position.z), 0.1f);
                slot.swiper.canSwipe = false;
                inMove = true;

            }
        }

    }


    bool Detect()
    {

        var up = this.guiTexture.pixelInset;
        var sl = slot.guiTexture.pixelInset;

             if ((up.xMax + this.transform.position.x >= sl.xMin + slot.transform.position.x) && (up.xMax + this.transform.position.x <= sl.xMax + slot.transform.position.x) && (up.yMax + this.transform.position.y >= sl.yMin + slot.transform.position.y) && (up.yMax + this.transform.position.y <= sl.yMax + slot.transform.position.y)) return true;
        else if ((up.xMin + this.transform.position.x >= sl.xMin + slot.transform.position.x) && (up.xMin + this.transform.position.x <= sl.xMax + slot.transform.position.x) && (up.yMin + this.transform.position.y >= sl.yMin + slot.transform.position.y) && (up.yMin + this.transform.position.y <= sl.yMax + slot.transform.position.y)) return true;
        else if ((up.xMax + this.transform.position.x >= sl.xMin + slot.transform.position.x) && (up.xMax + this.transform.position.x <= sl.xMax + slot.transform.position.x) && (up.yMin + this.transform.position.y >= sl.yMin + slot.transform.position.y) && (up.yMin + this.transform.position.y <= sl.yMax + slot.transform.position.y)) return true;
        else if ((up.xMin + this.transform.position.x >= sl.xMin + slot.transform.position.x) && (up.xMin + this.transform.position.x <= sl.xMax + slot.transform.position.x) && (up.yMax + this.transform.position.y >= sl.yMin + slot.transform.position.y) && (up.yMax + this.transform.position.y <= sl.yMax + slot.transform.position.y)) return true;
        else return false;

    }
}