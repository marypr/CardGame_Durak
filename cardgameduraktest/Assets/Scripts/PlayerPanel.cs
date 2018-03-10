using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerPanel : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    Image cachImage = null;
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
            cachImage.raycastTarget = true;
        if (Input.GetMouseButtonUp(0))
        {
           cachImage.raycastTarget = false;
        }
     
    }

    void Awake() {
        cachImage = GetComponent<Image>();
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

