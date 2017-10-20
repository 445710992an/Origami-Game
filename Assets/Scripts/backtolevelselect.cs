using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//written by xuefei
//this piece of script is use for when loading a cutscene
//when a cutscene is loaded, it will wait for 2 seconds then call the fader to fade in another secene, in this case,
//level selector
public class backtolevelselect : MonoBehaviour {
    public Color loadToColor = Color.white;//define fade in colour
    void Start()
    {
        StartCoroutine(sceneLoader());// pause execution and return control to Unity 
    }
    IEnumerator sceneLoader()
    {
        yield return new WaitForSeconds(2);//resume after exactly 2 seconds
        Initiate.Fade("LevelManager", loadToColor, 2.0f);// load level manager scene
    }
	// Update is called once per frame
}
