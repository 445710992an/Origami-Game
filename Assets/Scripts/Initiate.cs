using UnityEngine;
using System.Collections;
//script author by FlatTutorial https://www.assetstore.unity3d.com/en/#!/content/81753
public static class Initiate {
    //Create Fader object and assing the fade scripts and assign all the variables
    public static void Fade (string scene,Color col,float damp){
		GameObject init = new GameObject ();
		init.name = "Fader";
		init.AddComponent<Fader> ();
		Fader scr = init.GetComponent<Fader> ();
		scr.fadeDamp = damp;
		scr.fadeScene = scene;
		scr.fadeColor = col;
		scr.start = true;
	}

	public static void FadeInt (int scene,Color col,float damp){
		GameObject init = new GameObject ();
		init.name = "FaderInt";
		init.AddComponent<FaderInt> ();
		FaderInt scr = init.GetComponent<FaderInt> ();
		scr.fadeDamp = damp;
		scr.fadeScene = scene;
		scr.fadeColor = col;
		scr.start = true;
	}

}
