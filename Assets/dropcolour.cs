using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class dropcolour : MonoBehaviour, IDropHandler
{
    public Text colourtext;
    public Color loadToColor = Color.white;
    void start()
    {
        //wintext.text = "";
    }
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("drop to area");
        //wintext.text = "You win!";
        if (colourtext.text == "b"){
        //    Debug.Log("drop to area");
            Saver saver1 = new Saver();
            saver1.SetScore(50000);
            Initiate.Fade("cloud and fire next", loadToColor, 2.0f);
        }
    }
}
