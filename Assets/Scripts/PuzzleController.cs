using UnityEngine;
using System.Collections;
using System.Collections.Generic;

///<summary>
/// Gui of the game
///</summary>
[System.Serializable]
public class GUIP
{
	[Tooltip("Show player scores")]
	public TextMesh showScore;
	[Tooltip("Show minutes")]
	public TextMesh showMinuteTime;
	[Tooltip("Show seconds")]
	public TextMesh showSecondTime;
}

/// <summary>
/// Controls the game
/// </summary>
public class PuzzleController : MonoBehaviour
{
	[Header("GUI of the game")]
	public GUIP guiInstance;
	[Header("Diamonds score level")]
	public GameObject[] diamondsLevel;

	#region ADJUSTABLE VARIABLES
	[Header("Time (in seconds) to player score level")]
	[Tooltip("Player got a excelent time to finish, 3 diamonds")]
	public float excelentTime;
	[Tooltip("Player got a good time to finish, 2 diamonds, greater than this, 1 diamond")]
	public float goodTime;
    //Amount of puzzles to match
    [HideInInspector]
	public float amountOfPuzzlesToMatch;
	[Header("Scores to add")]
	public int amountOfScoresToAdd;
	#endregion

	#region HIDEININSPECTOR VARIABLES
	//start the time counting
	[HideInInspector]
	public bool canStartTime = true;
	//count seconds
	[HideInInspector]
	public float countSeconds;
	//count minutes
	[HideInInspector]
	public float countMinutes;
	//Count player matchs
	[HideInInspector]
	public int countMatch;
	//Count player scores
	[HideInInspector]
	public int playerScores;
	#endregion
	//scene to load
	public string sceneToReload;

	public string scenename;
	public Color loadToColor = Color.white;//define fade in colour

	void Start ()
    {
        //set the quantity of matchs to finish the game
        amountOfPuzzlesToMatch = FindObjectOfType<DragPuzzle>().otherPuzzles.Length;

		//hide player scores rating (diamonds)
		for (int i = 0;i < diamondsLevel.Length;i++)
        {
			if(diamondsLevel[i] != null)
            {
				diamondsLevel[i].SetActive(false);
            }
        }
	}

	void Update ()
	{
		//restart game
		if (GameController.GameControllerProperties.CurrentGameState == GameState.GAME_OVER) {
			if (Input.GetKeyDown (KeyCode.R) || Input.anyKey) {
				RestartGame ();
			}
		}

		if (GameController.GameControllerProperties.CurrentGameState == GameState.PUZZLE) {
			HandleTime ();
		}

		if (countMatch >= amountOfPuzzlesToMatch)
        {
            //Lion
            if (GameController.GameControllerProperties.CurrentGameState == GameState.PUZZLE)
            {
//				ShowPlayerScoreLevel((countMinutes * 60) + countSeconds);
				//Debug.Log ((countMinutes * 60) + countSeconds);
                GameController.GameControllerProperties.CurrentGameState = GameState.GAME_OVER;
				sceneLoader(scenename);
            }
        }
	}

	void sceneLoader(string scenestring)
	{
		Initiate.Fade(scenestring, loadToColor, 2.0f);// load level manager scene
	}


	///<summary>
	/// Add scores and update textmesh
	///</summary>
	public void AddScore()
	{
		//increment player match
		countMatch++;
		//add score
		playerScores += amountOfScoresToAdd;
	}

	///<summary>
	/// Handle game time
	///</summary>
	void HandleTime()
	{
		if (canStartTime)
		{
			countSeconds += Time.deltaTime;
		}

		if (countSeconds >= 60)
		{
			countMinutes++;
			countSeconds = 0;
		}
	}

	/// <summary>
	/// Restarts the game.
	/// </summary>
	public void RestartGame()
	{
		GameController.GameControllerProperties.CurrentGameState = GameState.PUZZLE;
		Application.LoadLevel(sceneToReload);
	}
}
