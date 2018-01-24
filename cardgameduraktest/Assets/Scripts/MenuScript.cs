using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {


    public void StartGame()

    {

        SceneManager.LoadSceneAsync("fool");

    }


    public void ExitGame()

    {

        Application.Quit();

    }

}
