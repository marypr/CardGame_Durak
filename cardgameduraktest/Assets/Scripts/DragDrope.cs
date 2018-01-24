using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrope : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform parentTo = null;
    public Ray ray;
    private HorizontalLayoutGroup panel = null;
    private HorizontalLayoutGroup enemypanel = null;
    private HorizontalLayoutGroup tablepanel = null;
    public string nameof;
    private GameObject Cardname = null;


    void Start() {
   
    }

    
    public void OnBeginDrag(PointerEventData eventData)
    {
      
        parentTo = this.transform.parent;
        nameof = eventData.pointerDrag.name;
        Cardname = GameObject.Find(nameof);
     
        #region
        panel = GameObject.Find("PlayerPanel").GetComponent<HorizontalLayoutGroup>();
        enemypanel = GameObject.Find("EnemyPanel").GetComponent<HorizontalLayoutGroup>();
        tablepanel = GameObject.Find("PlayerPanel").GetComponent<HorizontalLayoutGroup>();
        panel.enabled = false;
        tablepanel.enabled = false;
        enemypanel.enabled = false;
        #endregion

      GetComponent<CanvasGroup>().blocksRaycasts = false;
        CardModel cardModel = GetComponent<CardModel>();
       // cardModel.ToggleFace(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
      this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        panel.enabled = true;
        enemypanel.enabled = true;
        tablepanel.enabled = true;
        this.transform.SetParent(parentTo);
        CardModel cardModel = GetComponent<CardModel>();
        cardModel.ToggleFace(true);
        Cardname.transform.position = GameObject.Find(nameof).GetComponent<Trigger>().trans;
        GameObject.Find(nameof).GetComponent<SpriteRenderer>().sortingOrder = GameObject.Find("StartGame").GetComponent<StartGameDebug>().sorter;
        if (gameObject.transform.parent.gameObject.name == "Table")
        {
            GameObject.Find(nameof).GetComponent<DragDrope>().enabled = false;
        }

        if (gameObject.transform.parent.gameObject.name == "CardDeck")
        {
            GameObject.Find(nameof).transform.SetParent(GameObject.Find("PlayerPanel").transform);
        }

        if (gameObject.transform.parent.gameObject.name == "EnemyPanel")
        {
            cardModel.ToggleFace(false);
        }
    }
}
       
    

    

