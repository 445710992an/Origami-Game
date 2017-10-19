using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour {

	public float coldTime = 300;
	private float timer = 0;
	private Image filledImage;

	private bool isStartTimer = false;

	void Start()
	{
		filledImage = transform.Find ("filledImage").GetComponent<Image> ();

	}

	void Update()
	{
		if (isStartTimer) {
			timer += Time.deltaTime;
			filledImage.fillAmount = (timer) / 300;

			if (timer >= coldTime) {
				filledImage.fillAmount = 0;
				timer = 0;
				isStartTimer = false;
			}
		}
	}

	public void Onclick()
	{
		isStartTimer = true;
	}

}
