﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//create by xie using this code to show or hide the Panel
public class panelScripts : MonoBehaviour {

	public GameObject Panel;
	int counter;


	public void showhidePanel()
	{
		Panel.gameObject.SetActive (false);
//		counter++;
		if (counter % 2 == 1) {
			Panel.gameObject.SetActive (false);
		} else {
			Panel.gameObject.SetActive (true);
		}
		counter++;
	}
}
