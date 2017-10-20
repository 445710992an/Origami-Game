using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SgLib;
//create by xie use for controlling main menu,settings and animations
public class LevelManager : MonoBehaviour 
{

	private static bool firstStart = true;
	public GameObject SplashScreen;
	public GameObject GameSapce;
	public GameObject setting;

	public Button btnSoundOn;
	public Button btnSoundOff;
	public Button btnMusicOn;
	public Button btnMusicOff;
	public Button btnSwitch;
	public GameObject menuUI;
	public AnimationClip showMenuPanel;
	public AnimationClip hideMenuPanel;

	[Header("Splash Screen Display Config")]
	public bool showSplashScreen = true;
	public float splashScreenTime;
	//public bool showGameSpace = false;


	private Animator menuAnimator;	

	void Start()
	{
		if(firstStart && showSplashScreen)
		{
			//firstStart = false;
			Debug.Log("in");
			SplashScreen.SetActive(true);
			GameSapce.SetActive (false);
			setting.SetActive(false);
			StartCoroutine(CRHideSplashScreen(splashScreenTime));
		}
		else
		{
			SplashScreen.SetActive(false);
		}

		menuAnimator = menuUI.GetComponentInChildren<Animator>();
		menuUI.SetActive(false);
	}


	void Update()
	{
		UpdateSoundButtons();
		UpdateMusicButtons();
	}


	IEnumerator CRHideSplashScreen(float delay)
	{
		SoundManager.Instance.PlayMusic(SoundManager.Instance.background);
		yield return new WaitForSeconds(delay);
		//SplashScreen.SetActive(false);
		setting.SetActive(true);
		GameSapce.SetActive (true);
		Debug.Log ("out");
	}


	public void HandleExitButton()
	{
		StartCoroutine(HideMenuPanel());
	}

	IEnumerator HideMenuPanel()
	{
		menuAnimator.Play(hideMenuPanel.name);
		yield return new WaitForSeconds(hideMenuPanel.length);
		menuUI.SetActive(false);
	}


	public void HandleMenuButton()
	{
		menuUI.SetActive(true);
		menuAnimator.Play(showMenuPanel.name);
	}



	public void ToggleSound()
	{
		SoundManager.Instance.ToggleMute();
	}


	public void ToggleMusic()
	{
		SoundManager.Instance.ToggleMusic();
	}


	void UpdateSoundButtons()
	{
		if (SoundManager.Instance.IsMuted())
		{
			btnSoundOn.gameObject.SetActive(false);
			btnSoundOff.gameObject.SetActive(true);
		}
		else
		{
			btnSoundOn.gameObject.SetActive(true);
			btnSoundOff.gameObject.SetActive(false);
		}
	}

	void UpdateMusicButtons()
	{
		if (SoundManager.Instance.IsMusicOff())
		{
			btnMusicOff.gameObject.SetActive(true);
			btnMusicOn.gameObject.SetActive(false);
		}
		else
		{
			btnMusicOff.gameObject.SetActive(false);
			btnMusicOn.gameObject.SetActive(true);
		}
	}
		


}
