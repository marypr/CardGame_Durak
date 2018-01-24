using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerPanel : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
            GetComponent<Image>().raycastTarget = true;
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Image>().raycastTarget = false;
        }
     
    }

public void OnDrop(PointerEventData eventData)
    {

        DragDrope d = eventData.pointerDrag.GetComponent<DragDrope>();

        if (d != null)
        {

            d.parentTo = this.transform;
          
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
     
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      
      
    }
}

