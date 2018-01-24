using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public Vector3 trans;


    void Start()
    {
        GameObject.Find("Table").GetComponent<UsedCardsPanelScript>().yourmove = true;

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Trigg")
        {
          
            GameObject.FindGameObjectWithTag("ImageSuit").GetComponent<SpriteRenderer>().enabled = false;

            if (GameObject.Find("StartGame").GetComponent<StartGameDebug>().newmove)
            {

                GameObject.Find("StartGame").GetComponent<StartGameDebug>().xcoord = 200;
                GameObject.Find("StartGame").GetComponent<StartGameDebug>().ycoord = 260;
                GameObject.Find("StartGame").GetComponent<StartGameDebug>().zcoord = 0;
                GameObject.Find("StartGame").GetComponent<StartGameDebug>().sorter = 2 ;
                trans = new Vector3(GameObject.Find("StartGame").GetComponent<StartGameDebug>().xcoord, 260, 0);
                GameObject.Find("StartGame").GetComponent<StartGameDebug>().playersmove = true;
                GameObject.Find("StartGame").GetComponent<StartGameDebug>().newmove = false;

                if (GameObject.Find("Table").GetComponent<UsedCardsPanelScript>().yourmove)
                    GameObject.Find("Table").GetComponent<UsedCardsPanelScript>().yourmove = false;
                else
                    GameObject.Find("Table").GetComponent<UsedCardsPanelScript>().yourmove = true;

            }

            else
            {
                if (GameObject.Find("StartGame").GetComponent<StartGameDebug>().playersmove)
                {
                    if (GameObject.Find("Table").GetComponent<UsedCardsPanelScript>().yourmove)
                        GameObject.Find("Table").GetComponent<UsedCardsPanelScript>().yourmove = false;
                    else
                        GameObject.Find("Table").GetComponent<UsedCardsPanelScript>().yourmove = true;
                    GameObject.Find("StartGame").GetComponent<StartGameDebug>().xcoord = GameObject.Find("StartGame").GetComponent<StartGameDebug>().xcoord + 25;
                    GameObject.Find("StartGame").GetComponent<StartGameDebug>().sorter = GameObject.Find("StartGame").GetComponent<StartGameDebug>().sorter + 1;
                    trans = new Vector3(GameObject.Find("StartGame").GetComponent<StartGameDebug>().xcoord, 260, GameObject.Find("StartGame").GetComponent<StartGameDebug>().zcoord);
                    GameObject.Find("StartGame").GetComponent<StartGameDebug>().playersmove = false;
                }

                else
                {
                    if (GameObject.Find("Table").GetComponent<UsedCardsPanelScript>().yourmove)
                        GameObject.Find("Table").GetComponent<UsedCardsPanelScript>().yourmove = false;
                    else
                        GameObject.Find("Table").GetComponent<UsedCardsPanelScript>().yourmove = true;
                    GameObject.Find("StartGame").GetComponent<StartGameDebug>().sorter = GameObject.Find("StartGame").GetComponent<StartGameDebug>().sorter + 1;
                    GameObject.Find("StartGame").GetComponent<StartGameDebug>().xcoord = GameObject.Find("StartGame").GetComponent<StartGameDebug>().xcoord + 75;
                    trans = new Vector3(GameObject.Find("StartGame").GetComponent<StartGameDebug>().xcoord, 260, GameObject.Find("StartGame").GetComponent<StartGameDebug>().zcoord);
                    GameObject.Find("StartGame").GetComponent<StartGameDebug>().playersmove = true;
                }
            }
        }
    
    }
}
