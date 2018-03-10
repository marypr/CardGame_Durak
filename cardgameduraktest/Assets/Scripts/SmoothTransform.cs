using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothTransform : MonoBehaviour {

    UsedCardsPanelScript usedcardsscript = null;
    public Vector3 pos;
    public Vector3 f;
    Transform usedtr = null;
    Image cachImage = null;


    void Awake()
    {

        usedcardsscript = GameObject.Find("Table").GetComponent<UsedCardsPanelScript>();
        usedtr = GameObject.Find("UsedCardsPanel").transform;
        cachImage = GameObject.Find("PlayerPanel").GetComponent<Image>();

    }


    void Update()
    {

        if (usedcardsscript.clicked)
        {

            for (int q = 1; q < usedcardsscript.usedcards.Length; q++)
            {

                usedcardsscript.usedcards[q].transform.position = Vector3.Lerp(usedcardsscript.usedcards[q].transform.position, pos, Time.deltaTime);
                StartCoroutine(Wait());
                cachImage.raycastTarget = true;
            }
        }
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.9f);
        usedcardsscript.clicked = false;
        cachImage.raycastTarget = false;
        for (int q = 1; q < usedcardsscript.usedcards.Length; q++)
        {

            usedcardsscript.usedcards[q].SetParent(usedtr);

        }


    }
}

