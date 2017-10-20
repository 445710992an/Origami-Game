using UnityEngine;
using System.Collections;
//created by xie,
//move the camera from top to bottom once.
public class CameraMove : MonoBehaviour {
	public Transform from;//defined positions in editor
	public Transform to;
	public float speed = 0.1F;//defined speed of rotation
	void Update() { 
		transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.time * speed);
        //perform such rotation by Interpolates between those two places
    }
}