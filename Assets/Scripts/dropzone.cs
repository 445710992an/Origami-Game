using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//created by xuefei use for detect winning condition of drag and drop
public class dropzone : MonoBehaviour, IDropHandler {
    
	public Text wintext;
	public Color loadToColor = Color.white;
	public int SceneNumber;
    float timestarted;
    float timetaken;
    void start (){
        wintext.text = "";
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
        wintext.text = "You win!";

		Saver saver1 = new Saver();
        saver1.SetScorebytime(timetaken);
        timestarted = 0;
        Initiate.FadeInt(SceneNumber, loadToColor, 2.0f);

    }
}