using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public void OnStartGame(int SceneIndex)
	{
		Application.LoadLevel(SceneIndex);
	}

}
