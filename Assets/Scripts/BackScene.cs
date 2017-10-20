﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScene : MonoBehaviour {

	public Color loadToColor = Color.white;
	public int SceneNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void backToScene()
	{
		//yield return new WaitForSeconds(2);
		Initiate.FadeInt(SceneNumber, loadToColor, 2.0f);
	}
}