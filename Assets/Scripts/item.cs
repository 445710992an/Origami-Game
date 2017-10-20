using UnityEngine;
using System.Collections;

public class item : MonoBehaviour {

	public bool isChongHe=false;		//是否与其对应的node重合
	
	private GameObject mouseObject;
	// Use this for initialization
	void Start () {
		mouseObject = GameObject.Find ("mouse");
	}
	//进入对应的node时,将isChongHe置为true
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "position") {
			if(other.gameObject.name==mouseObject.GetComponent<puzzle>().puzzlename)
				isChongHe = true;
		}
	}
	//离开对应的node时,将isChongHe置为false
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "position") {
			if(other.gameObject.name==mouseObject.GetComponent<puzzle>().puzzlename)
				isChongHe = false;
		}
	}
	//当自身被拖动到对应的node处并放开后,执行node.die(),销毁自身
	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "position") {
			if(other.gameObject.name==mouseObject.GetComponent<puzzle>().puzzlename && !mouseObject.GetComponent<puzzle>().isClicked){
				//other.GetComponent<node>().die();
			//{	//Destroy(this.gameObject);
				this.transform.tag="position";
				this.transform.position=other.transform.position;
				//mouseObject.GetComponent<puzzle>().num++;
			}
		}

	}

}



