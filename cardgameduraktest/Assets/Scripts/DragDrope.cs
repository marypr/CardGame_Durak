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
    Transform mytransform = null;
    CanvasGroup mycanvas = null;
    CardModel mycardModel = null;
    public Vector3 screenSpace;
    public Vector3 offset;



    void Awake()
    {
        panel = GameObject.Find("PlayerPanel").GetComponent<HorizontalLayoutGroup>();
        enemypanel = GameObject.Find("EnemyPanel").GetComponent<HorizontalLayoutGroup>();
        tablepanel = GameObject.Find("PlayerPanel").GetComponent<HorizontalLayoutGroup>();
      
    }

    public void OnBeginDrag(PointerEventData eventData)
    {


       parentTo = CachedTransform.parent;
        nameof = eventData.pointerDrag.name;
        Cardname = GameObject.Find(nameof);

        #region
        panel.enabled = false;
        tablepanel.enabled = false;
        enemypanel.enabled = false;
        #endregion

        CachedCanvas.blocksRaycasts = false;


       // screenSpace = Camera.main.WorldToScreenPoint(Cardname.transform.position);
      //  offset = Cardname.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));

         cardModel.ToggleFace(true);
    }

    public void OnDrag(PointerEventData eventData)
    {

        // var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
        // var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
        // this.transform.position = Camera.main.ScreenToWorldPoint(curPosition);
        this.CachedTransform.position = Camera.main.ScreenToWorldPoint(eventData.position);
        this.CachedTransform.SetParent(parentTo);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        #region
        panel.enabled = true;
        enemypanel.enabled = true;
        tablepanel.enabled = true;
        #endregion

        this.CachedTransform.SetParent(parentTo);    
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

    #region
    public Transform CachedTransform
    {
        get
        {
            if ((object)mytransform == null)
            {
                mytransform = GetComponent<Transform>();
            }
            return mytransform;
        }
    }


    public CanvasGroup CachedCanvas
    {
        get
        {
            if ((object)mycanvas == null)
            {
                mycanvas = GetComponent<CanvasGroup>();
            }
            return mycanvas;
        }
    }

    public CardModel cardModel
    {
        get
        {
            if ((object)mycardModel == null)
            {
                mycardModel = GetComponent<CardModel>();
            }
            return mycardModel;
        }
    }

    #endregion
}





