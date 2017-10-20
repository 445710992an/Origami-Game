using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//adapt and modified by xuefei, original auther: xOctoManx (an online tutorial)
//link:https://www.youtube.com/watch?v=xSDfSDTtUMs
//use for saving the high score,star grading and unlock progress of the players
public class Saver : MonoBehaviour {
	
	public int score;
	public string LevelManagerName = "LevelManager";
	private int LevelAmount = 4;//semi-dynamically change the total level amount by variable
	private int CurrentLevel;
    public Color loadToColor = Color.white; // integrete with fader to create fade in effect while loading

    public void SetScorebytime(float time) {
        //provide an alternative score recording by time
        //covert time taken to score
        //which is used later for star gradjing
        if (time < 4) { score = 20000; }//3stars for less than 4s, 2 for less than 8s, 1 star for 12s no star for over 12s
        else if (time < 8) { score = 10000; }
        else if (time < 12) { score = 5000; }
        else { score = 0; }
        SetScore(score);//call the setscore function
    }

    public void SetScore(int scoreAmount)
	{
        //if the level directly allocated score to player, this will be called
		score = scoreAmount;//stores the score
		CheckCurrentLevel ();//call next step of saving function
	}

    void CheckCurrentLevel()
	{
		//this function checks in which level we are depending on the name
		for (int i = 1; i <= LevelAmount; i++)
		{
			if(SceneManager.GetActiveScene().name == "Level" + i)
			{
				CurrentLevel = i;//store the found level 
				SaveMyGame ();// call next function
			}
		}
	}

	void SaveMyGame()
	{
		//when this fuction is called all needed data will be save in disk(in windows system this will be saved in registry)
		int NextLevel = CurrentLevel + 1;// this is needed to unlock the next level
		if (NextLevel < LevelAmount+1) {//to prevent overflow
			PlayerPrefs.SetInt ("Level" + NextLevel.ToString (), 1);//unlock next level
			if (PlayerPrefs.GetInt ("Level" + CurrentLevel.ToString () + "_score") < score) //check if the current score is higher then the already stored
			{
				PlayerPrefs.SetInt ("Level" + CurrentLevel.ToString () + "_score", score);//if so, save
			}
		} 
		else //if it's the last possible level
		{
			if (PlayerPrefs.GetInt ("Level" + CurrentLevel.ToString () + "_score") < score) //check if the current score is higher then the already stored
			{
				PlayerPrefs.SetInt ("Level" + CurrentLevel.ToString () + "_score", score);//if so, save
			}
		}
		//BackToLevelSelect ();//go back to the level selector after every save game,unused in later development
	}

	void BackToLevelSelect()
	{
        //go back to the Level Select Menu with fader
        Initiate.Fade("LevelManager", loadToColor, 2.0f);
    }
}
