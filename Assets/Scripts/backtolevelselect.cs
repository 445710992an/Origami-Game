using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backtolevelselect : MonoBehaviour {

    // Use this for initialization
    public Color loadToColor = Color.white;
    void Start()
    {
        StartCoroutine(sceneLoader());
    }
    IEnumerator sceneLoader()
    {
        yield return new WaitForSeconds(2);
        Initiate.Fade("LevelManager", loadToColor, 2.0f);
    }
	// Update is called once per frame
}
