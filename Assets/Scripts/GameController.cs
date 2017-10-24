using UnityEngine;
using System.Collections;

///<summary>
/// enum for game stating
///</summary>
public enum GameState
{
    PUZZLE,
	GAME_OVER
}

///<summary>
/// Controls the game flow
///</summary>
public class GameController 
{
	//current game state
    private GameState currentGameState = GameState.PUZZLE;
	//singleton of this class
    private static GameController gameControllerInstance = null;

	//constructor
	/// <summary>
	/// Initializes a new instance of the <see cref="GameController"/> class.
	/// </summary>
    private GameController()
    {
        
    }

	//propertie to get an instance of this object
	/// <summary>
	/// Gets the game controller properties.
	/// </summary>
	/// <value>The game controller properties.</value>
    public static GameController GameControllerProperties
    {
        get
        {
            if(gameControllerInstance == null)
            {
                gameControllerInstance = new GameController();
            }

            return gameControllerInstance;
        }
    }
	
	//propertie to get and set game state
	/// <summary>
	/// Gets or sets the state of the current game.
	/// </summary>
	/// <value>The state of the current game.</value>
    public GameState CurrentGameState
    {
        get
        {
            return currentGameState;
//			Debug.Log (currentGameState);
        }

        set
        {
			currentGameState = value;
//			Debug.Log (currentGameState);
        }
    }
}
