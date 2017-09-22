using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		GameObject btnObj = GameObject.Find ("Button");
		Button btn = btnObj.GetComponent<Button>();
		btn.onClick.AddListener (delegate() {
			this.GoNextScene(btnObj);
		});
	}

	void Update () 
	{

	}

	public void GoNextScene(GameObject Nscene)
	{
		int i = SceneManager.GetActiveScene().buildIndex;

		SceneManager.LoadScene (i + 1);
	}

	// Update is called once per frame
}
