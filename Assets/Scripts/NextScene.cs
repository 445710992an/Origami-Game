using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//create by xie using this code to go the next scene
public class NextScene : MonoBehaviour
{
	public int SceneNumber;

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

		SceneManager.LoadScene (SceneNumber);
	}

}
