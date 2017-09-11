using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour 
{

	private static bool firstStart = true;
	public GameObject SplashScreen;

	[Header("Splash Screen Display Config")]
	public bool showSplashScreen = true;
	public float splashScreenTime = 3f;

	void start()
	{
		if(firstStart && showSplashScreen)
		{
			firstStart = false;
			SplashScreen.SetActive(true);
			StartCoroutine(CRHideSplashScreen(splashScreenTime));
		}
		else
		{
			SplashScreen.SetActive(false);
		}
	}

	IEnumerator CRHideSplashScreen(float delay)
	{
		yield return new WaitForSeconds(delay);
		SplashScreen.SetActive(false);

		/*
		if (!SoundManager.Instance.IsMusicOff() && SoundManager.Instance.MusicState != SoundManager.PlayingState.Playing)
		{
			SoundManager.Instance.PlayMusic(SoundManager.Instance.background);
		}
		*/
	}
}
