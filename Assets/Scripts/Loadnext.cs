using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//written by xuefei
//this piece of script is use for when loading a cutscene
//when a cutscene is loaded, it will wait for 2 seconds then call the fader to fade in another secene, in this case,
//level selector
public class Loadnext : MonoBehaviour {
    public string scenename;
    public Color loadToColor = Color.white;//define fade in colour
    void Start()
    {
        StartCoroutine(sceneLoader(scenename));// pause execution and return control to Unity 
    }
    IEnumerator sceneLoader(string scenestring)
    {
        yield return new WaitForSeconds(2);//resume after exactly 2 seconds
        Initiate.Fade(scenestring, loadToColor, 2.0f);// load level manager scene
    }
	// Update is called once per frame
}
