using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[ExecuteInEditMode]
public class CurlEf : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{

    public Transform _Front;
    public Transform _Mask;
    public Transform _GradOutter;
    public Vector3 _Pos = new Vector3(-240.0f, -470.0f, 0.0f) * 0.01f;
    bool drag = false;
    //  public Vector3 _OriginalPos;

    // GameObject _Folddraggable = GameObject.FindWithTag("GameController");
    public void OnBeginDrag(PointerEventData eventdata)
    {
        drag = true;
    }
    public void OnEndDrag(PointerEventData eventdata)
    {
        drag = false;
    }

    public void LateUpdate()
    {
        float distance = 10;
        if (drag) { 
        Vector3 _PointerPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 _ObjPos = Camera.main.ScreenToWorldPoint(_PointerPos);
        transform.position = _ObjPos; // To fix position of back image
        }
        else{ transform.position = _Pos; }
        transform.eulerAngles = Vector3.zero;

        Vector3 pos = _Front.localPosition;
        float theta = Mathf.Atan2(pos.y, pos.x) * 180.0f / Mathf.PI; // angle between X and Y?
        if (theta <= 0.0f || theta >= 90.0f) return;

        float deg = -(90.0f - theta) * 2.0f;
        _Front.eulerAngles = new Vector3(0.0f, 0.0f, deg);

        // Move mask to "cut" front and back images
        _Mask.position = (transform.position + _Front.position) * 0.5f;
        _Mask.eulerAngles = new Vector3(0.0f, 0.0f, deg * 0.5f);

        // Move gradient to create effect of volume
        _GradOutter.position = _Mask.position;
        _GradOutter.eulerAngles = new Vector3(0.0f, 0.0f, deg * 0.5f + 90.0f);

        // Next to make immobilize back image
        transform.position = _Pos; // To fix position of back image
        transform.eulerAngles = Vector3.zero;
    }
}
