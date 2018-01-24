using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartGameDebug : MonoBehaviour
{
    public CardStack dealer;
    public CardStack player;
    public CardStack enemy;
    public bool playersmove;
    public bool newmove;
    public int xcoord;
    public int ycoord;
    public int zcoord;
    public int sorter;
    public bool parentplayer;
    public bool parentenemy;
    public int numerc;


    void Start()
    {
        numerc = 0;
        newmove = true;
        playersmove = false;
        xcoord = 200;
        ycoord = 300;
        zcoord = 0;
        sorter = 2;
        parentenemy = true;
        
        for (int i = 0; i < 6; i++)
        {
            enemy.Push(dealer.Pop());
        }
        StartCoroutine(Wait());

    }


    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0);
        parentenemy = false;
        parentplayer = true;
        for (int i = 0; i < 6; i++)
        {
            player.Push(dealer.Pop());

        }

    }
}
