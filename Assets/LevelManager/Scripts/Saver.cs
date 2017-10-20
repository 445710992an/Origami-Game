using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Saver : MonoBehaviour {
	
	public int score;
	public string LevelManagerName = "LevelManager";
	private int LevelAmount = 3;//change this to the amount of level you have in your levelmanager - at least 1
	private int CurrentLevel;
    public Color loadToColor = Color.white;

    public void SetScorebytime(float time) {
        Debug.Log(time);
        if (time < 10) { score = 20000; }
        else if (time < 15) { score = 10000; }
        else if (time < 20) { score = 5000; }
        else { score = 0; }
        SetScore(score);

    }

    public void SetScore(int scoreAmount)
	{
		score = scoreAmount;//stores the score
		CheckCurrentLevel ();//call next function
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
		//save all needed data
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
		//BackToLevelSelect ();//call next function
	}

	void BackToLevelSelect()
	{
        //go back to the Level Select Menu
        //SceneManager.LoadScene(LevelManagerName);//unity 5.3+
        Initiate.Fade("LevelManager", loadToColor, 2.0f);
    }
}
