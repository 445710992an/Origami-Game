using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//created by xuefei
//simple drag handler for objects
public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public void OnBeginDrag(PointerEventData eventdata)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;//allow collsion when beginning a drag
    }
    public void OnDrag(PointerEventData eventdata)
    {
        this.transform.position = eventdata.position; //reposition the drag object to the mouse position
    }
    public void OnEndDrag(PointerEventData eventdata)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;//disallow collsion right after a drag action
    }
}
