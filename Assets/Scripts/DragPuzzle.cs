using UnityEngine;
using UnityEngine.UI;
//adapted and integrated by xie, orignial author Assets4Devs on https://www.assetstore.unity3d.com/cn/#!/content/81480
/// <summary>
/// Player drags the puzzles pieces
/// </summary>
public class DragPuzzle : MonoBehaviour
{
    [Header("PuzzleController instance")]
    public PuzzleController puzzleController;
    [Header("Other puzzles to manage")]
    public DragPuzzle[] otherPuzzles;
    //automatically search the cards in the scene
    public bool searchCardsAutomatically;
    [Header("Smooth of the draggin function")]
    public float smooth;
    [Header("Conditions to match")]
    public bool isNext;
	private bool isScaleOk = true;
	private bool isRotationOk = true;
    [Header("Target of this part")]
    public Transform targetShadow;
    [Header("Can this part execute something?")]
    public bool canGo;
    //initial size of the box collider
    private Vector3 initialBoxCollider;
    //initial layer
    private int initialLayer;
    //can add score?
    private bool canAddScore = true;
    [Header("Match the puzzle with its shadow target when they're?")]
    public bool readjustWhenClose;
    [Header("Congrats and Tips to the user :)")]
    [HeaderAttribute("Edit Mode settings")]
    public float timeLimitToTouch;
    private float currentTime;
    private bool startTime;

    void Start()
    {
        //gets the initial layer
        initialLayer = GetComponent<SpriteRenderer>().sortingOrder;
        //gets the initial box collider
        initialBoxCollider = GetComponent<BoxCollider>().size;

        //search the other pieces automatically
        if (searchCardsAutomatically)
            GetOtherPuzzles();
    }

    /// <summary>
	/// Gets the initial other puzzles.
	/// </summary>
    void GetOtherPuzzles()
    {
        otherPuzzles = FindObjectsOfType<DragPuzzle>();
    }

    /// <summary>
    /// Raises the mouse down event.
    /// </summary>
    void OnMouseDown()
    {
        canGo = false;
        GetComponent<SpriteRenderer>().sortingOrder = 4;//bring the sprite to the front
        startTime = true;
    }

    /// <summary>
    /// Raises the mouse up event.
    /// </summary>
    void OnMouseUp()
    {
        startTime = false;
        currentTime = 0;

        if (GameController.GameControllerProperties.CurrentGameState == GameState.PUZZLE)
        {
            //enable the other parts
            for (int i = 0; i < otherPuzzles.Length; i++)
            {
                if (otherPuzzles[i] != null)
                {
                    otherPuzzles[i].enabled = true;
                }
            }

            canGo = true;
            GetComponent<BoxCollider>().size = initialBoxCollider;
            GetComponent<SpriteRenderer>().sortingOrder = initialLayer;
        }
    }

    /// <summary>
    /// Raises the mouse drag event.
    /// </summary>
    void OnMouseDrag()
    {
        if (currentTime > timeLimitToTouch)
        {
            if (GameController.GameControllerProperties.CurrentGameState == GameState.PUZZLE)
            {
                //GetComponent<BoxCollider>().size = initialBoxCollider * 5f;
                Vector2 lastPosition = transform.position;
                Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                transform.position = Vector2.Lerp(lastPosition, new Vector2(pos.x, pos.y), smooth * Time.deltaTime);

                if (!isNext)
                {
                    for (int i = 0; i < otherPuzzles.Length; i++)
                    {
                        if (otherPuzzles[i] != null)
                        {
                            otherPuzzles[i].enabled = false;
                        }
                    }
                }
            }
        }
    }

    void Update()
    {
        if (GameController.GameControllerProperties.CurrentGameState == GameState.PUZZLE)
        {
            if (startTime)
                currentTime += Time.deltaTime;

			float distanceP = Vector2.Distance(transform.position, targetShadow.transform.position);

            //if distance of the target if 0.5f, isNext
			if (distanceP <= 0.5f)
            {
                isNext = true;
            }

            else
            {
                isNext = false;
            }

            //if is next antomatically transform and lock it to predifined postions
			if (canGo && isNext && targetShadow.gameObject.activeSelf && isScaleOk && isRotationOk)
            {
				transform.position = Vector2.MoveTowards(transform.position, targetShadow.position, smooth * Time.deltaTime);

                //make the size equals the target size
                if (readjustWhenClose)
					transform.localScale = targetShadow.transform.localScale;

                //add score only once, to avoid overhead
                if (canAddScore)
                {
                    canAddScore = false;
                }

                //if distance is smaller or equals 0, AddScore
                //this is the related score calculation in original project, however it was not used in this project
				if (distanceP <= 0)
                {
                    if (puzzleController)
                    {
                        puzzleController.AddScore();
                    }

                    GetComponent<SpriteRenderer>().sortingOrder = initialLayer;

                    if (GameController.GameControllerProperties.CurrentGameState == GameState.PUZZLE)
                    {
						transform.position = targetShadow.position;
                    }

                    for (int i = 0; i < otherPuzzles.Length; i++)
                    {
                        if (otherPuzzles[i] != null)
                        {
                            otherPuzzles[i].enabled = true;
                        }
                    }

                    //destroy unused components
                    Destroy(GetComponent<DragPuzzle>());
                    Destroy(GetComponent<BoxCollider>());
                }
            }
        }
    }
}
