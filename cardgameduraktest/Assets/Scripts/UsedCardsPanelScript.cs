using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedCardsPanelScript : MonoBehaviour {


       
        public Transform[] usedcards;

          public bool yourmove;


    void Update()
        {
            usedcards = new Transform[transform.childCount];
            int i = 0;

            foreach (Transform t in transform)
            {
                usedcards[i++] = t;
            
        }
        }

 

    void OnGUI() {

        if (yourmove) {

             GUI.Label(new Rect(700, 10, 100, 40), "Ход с нижнего стола");
        }
        else {

            GUI.Label(new Rect(700, 10, 100, 40), "Ход c верхнего стола");
        }

        if (GUI.Button(new Rect(346, 5, 256, 28), "Отбой!"))
        {
            GameObject.Find("StartGame").GetComponent<StartGameDebug>().newmove = true;
            GameObject.Find("StartGame").GetComponent<StartGameDebug>().playersmove = false;
            
          
            for (int i = 1; i < usedcards.Length; i++) {

                usedcards[i].SetParent(GameObject.Find("UsedCardsPanel").transform);
            }
            if (yourmove)
                yourmove = false;
            else
                yourmove = true;
           
        }

    }

   
}

