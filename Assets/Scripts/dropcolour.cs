using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//created by xuefei,modified version of drag base on current colour of paper
public class dropcolour : MonoBehaviour, IDropHandler
{
    public Text colourtext;
    public Color loadToColor = Color.white;
    float timestarted;
    float timetaken;//unity use float to keep track of current time

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && timestarted == 0)
            timestarted = Time.time; ;// if no start time recorded, start record when user click left mouse key(buttons or drag).
        timetaken = Time.time - timestarted;//update is called everyframe, so this will return timelapse in real time
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (colourtext.text == "b"){//it can be only win by black paper
            Saver saver1 = new Saver();//create a saver class for saving 
            saver1.SetScorebytime(timetaken);
            timestarted = 0;
            Initiate.Fade("Level_3_next", loadToColor, 2.0f);//reset start time to zero
        }
    }
}
