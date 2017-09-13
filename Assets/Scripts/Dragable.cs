using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public void OnBeginDrag(PointerEventData eventdata)
    {
        // Debug.Log("on begin drag");
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventdata)
    {
       // Debug.Log("on drag");
        this.transform.position = eventdata.position;
    }
    public void OnEndDrag(PointerEventData eventdata)
    {
        // Debug.Log("end drag");
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
