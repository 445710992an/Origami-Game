using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
//adapt and modified by xuefei, original auther: xOctoManx (an online tutorial)
//link:https://www.youtube.com/watch?v=xSDfSDTtUMs
//use for select and navigate levels, and display star grading of each level based on high score
public class LevelSelector: MonoBehaviour {

	[System.Serializable]
    //allow we embed a class with sub properties in the inspector.
    public class Level
	{
		public string LevelText;//used for tracking level number
		public int UnLocked;//0 for locked, 1 for unlocked
		public bool IsInteractable;
	}
	public GameObject levelButton;//hold the preset perfab
	public Transform Spacer;//hold the content of level selector
	public List<Level> LevelList;
    public Color loadToColor = Color.white;
    //Score - all level use the same score
    //Can also be changed in the levelManager GameObject
    public int Star0Points = 0;// the score the player need to beat the level, but no star awardedd
    public int Star1Points = 5000;//the score the player needs to unlock the first star
	public int Star2Points = 10000;//the score the player needs to unlock the second star
	public int Star3Points = 20000;//the score the player needs to unlock the third star

	void Start () 
	{
		FillList ();//populate the levellist
	}

	void FillList()
	{
		foreach(var level in LevelList)
		{
			GameObject newbutton = Instantiate(levelButton) as GameObject;//create the button depend on the given prefab
			LevelButton button = newbutton.GetComponent<LevelButton>();//get the levebutton component of the created button
			button.LevelText.text = level.LevelText;//set the leveltext set in the levelmanager onto the button
			//if the current looped button has a saved value of 1 (is unlocked), then set it to be unlocked and interactable
            //as this will be the first level which should be made unconditionally unlocked
			if(PlayerPrefs.GetInt("Level" + button.LevelText.text) == 1)
			{
				level.UnLocked = 1;
				level.IsInteractable = true;
			}
			//set unlocked state
			button.unlocked = level.UnLocked;
			//set interactable state
			button.GetComponent<Button>().interactable = level.IsInteractable;
			//add a listener with a function on it to load the right level when the button is clicked
			button.GetComponent<Button>().onClick.AddListener(() => loadLevels("Level" + button.LevelText.text));
            //check stars depending on score, noted point required for each star get progressive higher
            if (PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score") > Star0Points) {
                button.Star1grey.SetActive(true);
                button.Star2grey.SetActive(true);
                button.Star3grey.SetActive(true);
                //3 grey star for 0 star but have completed the level
            }
            if (PlayerPrefs.GetInt("Level"+ button.LevelText.text + "_score") >= Star1Points)
			{
				button.Star1.SetActive(true);
                button.Star1grey.SetActive(false);
                //1st star unlocked
            }

			if(PlayerPrefs.GetInt("Level"+ button.LevelText.text + "_score") >= Star2Points)
			{
				button.Star2.SetActive(true);
                button.Star2grey.SetActive(false);
                //second star unlocked
            }

			if(PlayerPrefs.GetInt("Level"+ button.LevelText.text + "_score") >= Star3Points)
			{
				button.Star3.SetActive(true);
                button.Star3grey.SetActive(false);
                //third star unlocked
            }
			//set the parent to be the spacer which needs to be in the canvas
			newbutton.transform.SetParent(Spacer,false);
		}
        SaveAll ();//perform a save only the first time the game has been started
	
	}

	void SaveAll()
	{
		if(PlayerPrefs.HasKey("Level1"))//if it has been saved already
		{
			return;// don't do anything
		}
		else//if not
		{
			//go through all existing buttons and save
			GameObject[] allButtons = GameObject.FindGameObjectsWithTag("LevelButton");
			foreach (GameObject buttons in allButtons)
			{
				LevelButton button = buttons.GetComponent<LevelButton>();
				PlayerPrefs.SetInt("Level" + button.LevelText.text, button.unlocked);
			}
		}
	}
	//a test function to reset the player scores and unlock progress
	public void DeleteAll()
	{
		PlayerPrefs.DeleteAll ();
        //SceneManager.LoadScene("LevelManager");
        Initiate.Fade("LevelManager", loadToColor, 2.0f);

    }
	//function to load the right level once clicked on a level button
	void loadLevels(string value)
	{
		//with value being the required level, and fader to fade out
	//	SceneManager.LoadScene(value);
        Initiate.Fade(value, loadToColor, 2.0f);
    }
}
