using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
 
    public Vector3 trans;
    StartGameDebug mystart = null;
    UsedCardsPanelScript usedpanel = null;
    SpriteRenderer mySpriteRen = null;

    void Start()
    {
        usedpanel.yourmove = true;

    }

    void Awake() {
       mystart = GameObject.Find("StartGame").GetComponent<StartGameDebug>();
       usedpanel = GameObject.Find("Table").GetComponent<UsedCardsPanelScript>();
        mySpriteRen = GameObject.FindGameObjectWithTag("ImageSuit").GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Trigg")
        {

            mySpriteRen.enabled = false;

            if (mystart.newmove)
            {

                startGame.xcoord = 180;
                mystart.ycoord = 290;
                mystart.zcoord = 2;
                mystart.sorter = 2 ;
                trans = new Vector3(mystart.xcoord, 290, 2);
                mystart.playersmove = true;
                mystart.newmove = false;

                if (usedpanel.yourmove)
                    usedpanel.yourmove = false;
                else
                    usedpanel.yourmove = true;

            }

            else
            {
                if (mystart.playersmove)
                {
                    if (usedpanel.yourmove)
                        usedpanel.yourmove = false;
                    else
                        usedpanel.yourmove = true;
                    mystart.xcoord = mystart.xcoord + 25;
                    mystart.sorter = mystart.sorter + 1;
                
                    trans =new Vector3(mystart.xcoord, 290, mystart.zcoord);
                    mystart.playersmove = false;
                }

                else
                {
                    if (usedpanel.yourmove)
                        usedpanel.yourmove = false;
                    else
                        usedpanel.yourmove = true;
                    mystart.sorter = mystart.sorter + 1;
                    mystart.xcoord = mystart.xcoord + 75;
                   
                    trans = new Vector3(mystart.xcoord, 290, mystart.zcoord);
                    mystart.playersmove = true;
                }
            }
        }
    
    }


    #region
    public StartGameDebug startGame
    {
        get
        {
            if ((object)mystart == null)
            {
                mystart = GetComponent<StartGameDebug>();
            }
            return mystart;
        }
    }
    #endregion
}
