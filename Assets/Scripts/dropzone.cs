using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class dropzone : MonoBehaviour, IDropHandler {
    
	//public Text wintext;
	public Color loadToColor = Color.white;
	public int SceneNumber;

    void start (){
        //wintext.text = "";
    }
    public void OnDrop(PointerEventData eventData) 
	{
        //Debug.Log("drop to area");
        //wintext.text = "You win!";

		Saver saver1 = new Saver();
		saver1.SetScore(50000);
		Initiate.FadeInt(SceneNumber, loadToColor, 2.0f);

    }
}