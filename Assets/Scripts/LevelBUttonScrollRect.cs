using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelBUttonScrollRect : MonoBehaviour,IBeginDragHandler,IEndDragHandler {

	private ScrollRect scrollRect;

	private float[] pageArray = new float[]{ 0, 0.333333f, 0.66666f, 1 };
	private float targetHorizontalPosition = 0;
	private bool isDraing = false;

	public float smoothing = 4;
	public Toggle[] toggleArray;

	// Use this for initialization
	void Start () 
	{
		scrollRect = GetComponent<ScrollRect>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isDraing == false) 
		{
			scrollRect.horizontalNormalizedPosition = Mathf.Lerp (scrollRect.horizontalNormalizedPosition,
				targetHorizontalPosition, Time.deltaTime * smoothing);
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		isDraing = true;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		isDraing = false;

		float posX = scrollRect.horizontalNormalizedPosition;

		int index = 0;
		float offset = Mathf.Abs (pageArray[index] - posX);

		for (int i = 1; i < pageArray.Length; i++) 
		{
			float offsetTemp = Mathf.Abs (pageArray[i] - posX);

			if (offsetTemp < offset)
			{
				index = i;
				offset = offsetTemp;
			}
		}

		targetHorizontalPosition = pageArray [index];
		toggleArray [index].isOn = true;
		//scrollRect.horizontalNormalizedPosition = pageArray [index];
			
	}


	public void MoveToPage1(bool isOn)
	{
		if (isOn) 
		{
			targetHorizontalPosition = pageArray [0];
		}
	}

	public void MoveToPage2(bool isOn)
	{
		if (isOn) 
		{
			targetHorizontalPosition = pageArray [1];
		}
	}

	public void MoveToPage3(bool isOn)
	{
		if (isOn) 
		{
			targetHorizontalPosition = pageArray [2];
		}
	}

	public void MoveToPage4(bool isOn)
	{
		if (isOn) 
		{
			targetHorizontalPosition = pageArray [3];
		}
	}

}
