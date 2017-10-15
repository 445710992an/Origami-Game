using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintePage : MonoBehaviour {

	public GameObject Yb;
	public GameObject Yp;
	public GameObject Rb;
	public GameObject Rp;
	public GameObject Bb;
	public GameObject Bp;
	public GameObject Db;
	public GameObject Dp;

	public void YbClick()
	{
		//Debug.Log ("Click");
		Yp.gameObject.SetActive (true);
		Bp.gameObject.SetActive (false);
		Rp.gameObject.SetActive (false);
		Dp.gameObject.SetActive (false);
	}

	public void BbClick()
	{
		//Debug.Log ("Click");
		Yp.gameObject.SetActive (false);
		Bp.gameObject.SetActive (true);
		Rp.gameObject.SetActive (false);
		Dp.gameObject.SetActive (false);
	}

	public void RbClick()
	{
		//Debug.Log ("Click");
		Yp.gameObject.SetActive (false);
		Bp.gameObject.SetActive (false);
		Rp.gameObject.SetActive (true);
		Dp.gameObject.SetActive (false);
	}

	public void DbClick()
	{
		//Debug.Log ("Click");
		Yp.gameObject.SetActive (false);
		Bp.gameObject.SetActive (false);
		Rp.gameObject.SetActive (false);
		Dp.gameObject.SetActive (true);
	}

}
