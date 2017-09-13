using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class dropzone : MonoBehaviour, IDropHandler {
    public Text wintext;
    void start (){
        wintext.text = "";
    }
    public void OnDrop(PointerEventData eventData) {
        //Debug.Log("drop to area");
        wintext.text = "You win!";
    }
}