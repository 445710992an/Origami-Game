﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//written by xie
public class ControlPage : MonoBehaviour {
    //L-left R-right T-top B-bottom
	public GameObject LT;
	public GameObject RT;
	public GameObject LB;
	public GameObject RB;

	public GameObject RTtoLB;
	public GameObject LBtoRT;

	public GameObject RTtoRB;
	public GameObject RTtoLT;
	public GameObject LBtoLT;
	public GameObject LBtoRB;

	public GameObject LTtoRB;
	public GameObject RBtoLT;

	public GameObject ori;//default image, reactive when reset
    //show correct image and hide all other images 

	int change = 0;
	int a = 0;
	int b = 0;

	void Start ()
	{
		ori.gameObject.SetActive (true);
		RTtoRB.gameObject.SetActive (false);
		RTtoLB.gameObject.SetActive (false);
		RTtoLT.gameObject.SetActive (false);
		LBtoLT.gameObject.SetActive (false);
		LBtoRB.gameObject.SetActive (false);
		LBtoRT.gameObject.SetActive (false);
		LTtoRB.gameObject.SetActive (false);
		RBtoLT.gameObject.SetActive (false);
        //initialize to default
	}

	void Update()
	{
		//Debug.Log (first);
		if (change > 0) {

			int num = a * 10 + b;
           // a is the first pressed button, b is the second, this will give a number format of "a"+"b", so for example if a = 1, 
           // b=2 then num=12, which means"first vertice" to second vertices, in this case left bottom to right bottom
			switch (num) {
			case 12:
				ori.gameObject.SetActive (false);
				RTtoRB.gameObject.SetActive (false);
				RTtoLB.gameObject.SetActive (false);
				RTtoLT.gameObject.SetActive (false);
				LBtoLT.gameObject.SetActive (false);
				LBtoRB.gameObject.SetActive (true);
				LBtoRT.gameObject.SetActive (false);
				LTtoRB.gameObject.SetActive (false);
				RBtoLT.gameObject.SetActive (false);

				change = 0;
				a = 0;
				b = 0;
				break;

			case 13:
				ori.gameObject.SetActive (false);
				RTtoRB.gameObject.SetActive (true);
				RTtoLB.gameObject.SetActive (false);
				RTtoLT.gameObject.SetActive (false);
				LBtoLT.gameObject.SetActive (false);
				LBtoRB.gameObject.SetActive (false);
				LBtoRT.gameObject.SetActive (false);
				LTtoRB.gameObject.SetActive (false);
				RBtoLT.gameObject.SetActive (false);

				change = 0;
				a = 0;
				b = 0;
				break;

			case 14:
				ori.gameObject.SetActive (false);
				RTtoRB.gameObject.SetActive (false);
				RTtoLB.gameObject.SetActive (false);
				RTtoLT.gameObject.SetActive (false);
				LBtoLT.gameObject.SetActive (false);
				LBtoRB.gameObject.SetActive (false);
				LBtoRT.gameObject.SetActive (false);
				LTtoRB.gameObject.SetActive (true);
				RBtoLT.gameObject.SetActive (false);

				change = 0;
				a = 0;
				b = 0;
				break;

			case 21:
				ori.gameObject.SetActive (false);
				RTtoRB.gameObject.SetActive (false);
				RTtoLB.gameObject.SetActive (false);
				RTtoLT.gameObject.SetActive (true);
				LBtoLT.gameObject.SetActive (false);
				LBtoRB.gameObject.SetActive (false);
				LBtoRT.gameObject.SetActive (false);
				LTtoRB.gameObject.SetActive (false);
				RBtoLT.gameObject.SetActive (false);

				change = 0;
				a = 0;
				b = 0;
				break;

			case 23:
				ori.gameObject.SetActive (false);
				RTtoRB.gameObject.SetActive (false);
				RTtoLB.gameObject.SetActive (true);
				RTtoLT.gameObject.SetActive (false);
				LBtoLT.gameObject.SetActive (false);
				LBtoRB.gameObject.SetActive (false);
				LBtoRT.gameObject.SetActive (false);
				LTtoRB.gameObject.SetActive (false);
				RBtoLT.gameObject.SetActive (false);

				change = 0;
				a = 0;
				b = 0;
				break;

			case 24:
				ori.gameObject.SetActive (false);
				RTtoRB.gameObject.SetActive (true);
				RTtoLB.gameObject.SetActive (false);
				RTtoLT.gameObject.SetActive (false);
				LBtoLT.gameObject.SetActive (false);
				LBtoRB.gameObject.SetActive (false);
				LBtoRT.gameObject.SetActive (false);
				LTtoRB.gameObject.SetActive (false);
				RBtoLT.gameObject.SetActive (false);

				change = 0;
				a = 0;
				b = 0;
				break;

			case 31:
				ori.gameObject.SetActive (false);
				RTtoRB.gameObject.SetActive (false);
				RTtoLB.gameObject.SetActive (false);
				RTtoLT.gameObject.SetActive (false);
				LBtoLT.gameObject.SetActive (true);
				LBtoRB.gameObject.SetActive (false);
				LBtoRT.gameObject.SetActive (false);
				LTtoRB.gameObject.SetActive (false);
				RBtoLT.gameObject.SetActive (false);

				change = 0;
				a = 0;
				b = 0;
				break;

			case 32:
				ori.gameObject.SetActive (false);
				RTtoRB.gameObject.SetActive (false);
				RTtoLB.gameObject.SetActive (false);
				RTtoLT.gameObject.SetActive (false);
				LBtoLT.gameObject.SetActive (false);
				LBtoRB.gameObject.SetActive (false);
				LBtoRT.gameObject.SetActive (true);
				LTtoRB.gameObject.SetActive (false);
				RBtoLT.gameObject.SetActive (false);

				change = 0;
				a = 0;
				b = 0;
				break;

			case 34:
				ori.gameObject.SetActive (false);
				RTtoRB.gameObject.SetActive (false);
				RTtoLB.gameObject.SetActive (false);
				RTtoLT.gameObject.SetActive (false);
				LBtoLT.gameObject.SetActive (false);
				LBtoRB.gameObject.SetActive (true);
				LBtoRT.gameObject.SetActive (false);
				LTtoRB.gameObject.SetActive (false);
				RBtoLT.gameObject.SetActive (false);

				change = 0;
				a = 0;
				b = 0;
				break;

			case 41:
				ori.gameObject.SetActive (false);
				RTtoRB.gameObject.SetActive (false);
				RTtoLB.gameObject.SetActive (false);
				RTtoLT.gameObject.SetActive (false);
				LBtoLT.gameObject.SetActive (false);
				LBtoRB.gameObject.SetActive (false);
				LBtoRT.gameObject.SetActive (false);
				LTtoRB.gameObject.SetActive (false);
				RBtoLT.gameObject.SetActive (true);

				change = 0;
				a = 0;
				b = 0;
				break;

			case 42:
				ori.gameObject.SetActive (false);
				RTtoRB.gameObject.SetActive (false);
				RTtoLB.gameObject.SetActive (false);
				RTtoLT.gameObject.SetActive (false);
				LBtoLT.gameObject.SetActive (true);
				LBtoRB.gameObject.SetActive (false);
				LBtoRT.gameObject.SetActive (false);
				LTtoRB.gameObject.SetActive (false);
				RBtoLT.gameObject.SetActive (false);

				change = 0;
				a = 0;
				b = 0;
				break;

			case 43:
				ori.gameObject.SetActive (false);
				RTtoRB.gameObject.SetActive (false);
				RTtoLB.gameObject.SetActive (false);
				RTtoLT.gameObject.SetActive (true);
				LBtoLT.gameObject.SetActive (false);
				LBtoRB.gameObject.SetActive (false);
				LBtoRT.gameObject.SetActive (false);
				LTtoRB.gameObject.SetActive (false);
				RBtoLT.gameObject.SetActive (false);

				change = 0;
				a = 0;
				b = 0;
				break;
                    //all possible combinations and change image accordingly
			default:
				break;
			}
		}
	}

	public void clickLT()
	{
		if (change == 0) {
			Debug.Log ("1");
			change++;
			a = 1;
		} else {
			b = 1;
		}
	}

	public void clickRT()
	{
		if (change == 0) {
			change++;
			a = 2;
		} else {
			b = 2;
		}
	}

	public void clickLB()
	{
		if (change == 0) {
			change++;
			a = 3;
		} else {
			b = 3;
		}
	}

	public void clickRB()
	{
		if (change == 0) {
			change++;
			a = 4;
		} else {
			b = 4;
		}
	}//assignment of a and b according to position clicked


	public void returnOri()
	{
		ori.gameObject.SetActive (true);
		RTtoRB.gameObject.SetActive (false);
		RTtoLB.gameObject.SetActive (false);
		RTtoLT.gameObject.SetActive (false);
		LBtoLT.gameObject.SetActive (false);
		LBtoRB.gameObject.SetActive (false);
		LBtoRT.gameObject.SetActive (false);
		LTtoRB.gameObject.SetActive (false);
		RBtoLT.gameObject.SetActive (false);

		change = 0;
		a = 0;
		b = 0;
        //back to default shape
	}
}
