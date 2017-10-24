using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//created by xuefei, get signal when user complete the level by drop to area and record time taken
public class dropzone : MonoBehaviour, IDropHandler {
    
	public Color loadToColor = Color.white;//when complete, load this scene
    float timestarted;//unity use float to keep track of current time
    float timetaken;
	public GameObject store;
	public string scenename;

    void start (){
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && timestarted == 0)
            timestarted = Time.time;// if no start time recorded, start record when user click left mouse key(buttons or drag).
        timetaken = Time.time - timestarted;//update is called everyframe, so this will return timelapse in real time
    }
    public void OnDrop(PointerEventData eventData) 
	{
		Saver saver1 = new Saver();//create a saver class for saving 
        saver1.SetScorebytime(timetaken);
        timestarted = 0;//reset start time to zero
		store.gameObject.SetActive (true);
		StartCoroutine(sceneLoader(scenename));// pause execution and return control to Unity

    }

	IEnumerator sceneLoader(string scenename)
	{
		yield return new WaitForSeconds(5);//resume after exactly 5 seconds
		Initiate.Fade(scenename, loadToColor, 2.0f);// load level manager scene
	}


}