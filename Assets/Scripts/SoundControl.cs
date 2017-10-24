using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SgLib;

//create by xie using this to control the sound or music for on or off
public class SoundControl : MonoBehaviour {

	public Button btnSoundOn;
	public Button btnSoundOff;
	public Button btnMusicOn;
	public Button btnMusicOff;
	public GameObject menuUI;
	public AnimationClip showMenuPanel;
	public AnimationClip hideMenuPanel;

	private Animator menuAnimator;

	// Use this for initialization
	void Start () {

		menuAnimator = menuUI.GetComponentInChildren<Animator>();
		menuUI.SetActive(false);

	}

	// Update is called once per frame
	void Update () {

		UpdateSoundButtons();
		UpdateMusicButtons();
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
