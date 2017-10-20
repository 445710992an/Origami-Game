using UnityEngine;
using System.Collections;

public class puzzle : MonoBehaviour {

	private int size=8;
	public int num=0;

	public string puzzlename="position";
	public GameObject[] fragment;

	private bool isMouseDown=false;
	public bool isClicked=false;
	private bool overlap=false;
	private Vector3 oldposition;
	private GameObject target=null;
	// Use this for initialization
	void Start () {
		int i,t;
		Vector3 temp = Vector3.zero;
		float xx, yy;

		for (i=0; i<size; i++) {
			t=Random.Range(0,size-1);
			temp=fragment[i].transform.position;
			fragment[i].transform.position=fragment[t].transform.position;
			fragment[t].transform.position=temp;
		}
	}

	void OnGUI()
	{
		if (num == size) {
			if (GUI.Button (new Rect (300, 200, 300, 200), "恭喜过关"))
				Application.LoadLevel ("teach_dinosaur");
		}
	}
	// Update is called once per frame
	void Update () {
		//使mouse始终跟着鼠标走
		transform.position = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y,1));
		//鼠标左键按下时,isMouseDown为true
		isMouseDown=Input.GetMouseButton(0);
		if(!isMouseDown&&isClicked){	//item被拖动过程中鼠标左键放开
			isClicked=false;
			//如果item未被拖到对应node处就被放开,则使其返回起始位置
			if(!overlap)
				target.transform.position=oldposition;
		}
		//在item被拖动过程中保证其始终跟着mouse走,并时刻判定其是否与对应node重合
		if(isClicked){
			target.transform.position=transform.position;
			overlap=target.GetComponent<item>().isChongHe;
		}


	}


	void OnTriggerStay2D(Collider2D other) {
		if(isMouseDown && !isClicked && other.gameObject.tag=="puzzle"){
			isClicked=true;
			target=GameObject.Find(other.gameObject.name);
			oldposition=other.transform.position;
			puzzlename="position_"+other.gameObject.name[7];
			//Debug.Log(puzzlename);
		}
	}
}
