using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UsedCardsPanelScript : MonoBehaviour {


       
    public Transform[] usedcards;
    public Text MyTestLabel;
    public bool yourmove;
    StartGameDebug mystart = null;
    public bool clicked;
   


    void Update()
        {
            usedcards = new Transform[transform.childCount];
            int i = 0;

            foreach (Transform t in transform)
            {
                usedcards[i++] = t;
            
        }
        if (yourmove)
        {

            MyTestLabel.text =  "Ход с нижнего стола";
        }
        else
        {

            MyTestLabel.text = "Ход c верхнего стола";
        }
       
    }

    void Awake() {
        mystart = GameObject.Find("StartGame").GetComponent<StartGameDebug>();
       
    }

  public void ClickBeat() {
        clicked = true;
        mystart.newmove = true;
        mystart.playersmove = false;

        if (yourmove)
            yourmove = false;
        else
            yourmove = true;
    }
   
    }

