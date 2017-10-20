using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class dropcolour : MonoBehaviour, IDropHandler
{
    public Text colourtext;
    public Color loadToColor = Color.white;
    float timestarted;
    float timetaken;
 //   bool recorded;

    void start()
    {
        //wintext.text = "";
      //  timestarted = Time.time;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && timestarted == 0)
            timestarted = Time.time;
        timetaken = Time.time - timestarted;
    }
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("drop to area");
        //wintext.text = "You win!";
        if (colourtext.text == "b"){
            Saver saver1 = new Saver();
            saver1.SetScorebytime(timetaken);
            timestarted = 0;
            Initiate.Fade("Level_3_next", loadToColor, 2.0f);
        }
    }
}
