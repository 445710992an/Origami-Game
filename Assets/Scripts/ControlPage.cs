using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPage : MonoBehaviour {

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

	public GameObject ori;

	bool boolLT = false;
	bool boolRT = false;
	bool boolRB = false;
	bool boolLB = false;

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
	}

	void Update()
	{
		if((boolRB == true && boolRT == true))
		{
			RTtoRB.gameObject.SetActive (true);
			RTtoLB.gameObject.SetActive (false);
			RTtoLT.gameObject.SetActive (false);
			LBtoLT.gameObject.SetActive (false);
			LBtoRB.gameObject.SetActive (false);
			LBtoRT.gameObject.SetActive (false);
			LTtoRB.gameObject.SetActive (false);
			RBtoLT.gameObject.SetActive (false);

			ori.gameObject.SetActive (false);

			boolRB = false;
			boolRT = false;
		}

		if(boolRT == true && boolLB == true)
		{
			RTtoRB.gameObject.SetActive (false);
			RTtoLB.gameObject.SetActive (true);
			RTtoLT.gameObject.SetActive (false);
			LBtoLT.gameObject.SetActive (false);
			LBtoRB.gameObject.SetActive (false);
			LBtoRT.gameObject.SetActive (false);
			LTtoRB.gameObject.SetActive (false);
			RBtoLT.gameObject.SetActive (false);

			ori.gameObject.SetActive (false);

			boolRT = false;
			boolLB = false;
		}

		if(boolLT == true && boolRT == true)
		{
			RTtoRB.gameObject.SetActive (false);
			RTtoLB.gameObject.SetActive (false);
			RTtoLT.gameObject.SetActive (true);
			LBtoLT.gameObject.SetActive (false);
			LBtoRB.gameObject.SetActive (false);
			LBtoRT.gameObject.SetActive (false);
			LTtoRB.gameObject.SetActive (false);
			RBtoLT.gameObject.SetActive (false);

			ori.gameObject.SetActive (false);

			boolLT = false;
			boolRT = false;
		}

		if(boolLB == true && boolLT == true)
		{
			RTtoRB.gameObject.SetActive (false);
			RTtoLB.gameObject.SetActive (false);
			RTtoLT.gameObject.SetActive (false);
			LBtoLT.gameObject.SetActive (true);
			LBtoRB.gameObject.SetActive (false);
			LBtoRT.gameObject.SetActive (false);
			LTtoRB.gameObject.SetActive (false);
			RBtoLT.gameObject.SetActive (false);

			ori.gameObject.SetActive (false);

			boolLB = false;
			boolLT = false;
		}

		if(boolLB == true && boolRB == true)
		{
			RTtoRB.gameObject.SetActive (false);
			RTtoLB.gameObject.SetActive (false);
			RTtoLT.gameObject.SetActive (false);
			LBtoLT.gameObject.SetActive (false);
			LBtoRB.gameObject.SetActive (true);
			LBtoRT.gameObject.SetActive (false);
			LTtoRB.gameObject.SetActive (false);
			RBtoLT.gameObject.SetActive (false);

			ori.gameObject.SetActive (false);

			boolLB = false;
			boolRB = false;
		}

		if(boolLB == true && boolRT == true)
		{
			RTtoRB.gameObject.SetActive (false);
			RTtoLB.gameObject.SetActive (false);
			RTtoLT.gameObject.SetActive (false);
			LBtoLT.gameObject.SetActive (false);
			LBtoRB.gameObject.SetActive (false);
			LBtoRT.gameObject.SetActive (true);
			LTtoRB.gameObject.SetActive (false);
			RBtoLT.gameObject.SetActive (false);

			ori.gameObject.SetActive (false);

			boolLB = false;
			boolRT = false;
		}

		if(boolLT == true && boolRB == true)
		{
			RTtoRB.gameObject.SetActive (false);
			RTtoLB.gameObject.SetActive (false);
			RTtoLT.gameObject.SetActive (false);
			LBtoLT.gameObject.SetActive (false);
			LBtoRB.gameObject.SetActive (false);
			LBtoRT.gameObject.SetActive (false);
			LTtoRB.gameObject.SetActive (true);
			RBtoLT.gameObject.SetActive (false);

			ori.gameObject.SetActive (false);

			boolLT = false;
			boolRB = false;
		}

	}

//	void reset()
//	{
//		bool boolLT = false;
//		bool boolRT = false;
//		bool boolRB = false;
//		bool boolLB = false;
//	}

	public void clickLT()
	{
		boolLT = true;
	}

	public void clickRT()
	{
		boolRT = true;
	}

	public void clickRB()
	{
		boolRB = true;
	}

	public void clickLB()
	{
		boolLB = true;
	}

}
