using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    private GameController gameController;

    public GameObject panelMainMenu;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonExit()
    {
        //Forma genérica (android e PC)
        // if(Input.GetKeyDown(KeyCode.Escape))
        // {
        //     Application.Quit();
        // }

        //Forma Android
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
    }

    public void ButtonStartGame()
    {
        gameController.gameStarted = true;
        panelMainMenu.gameObject.SetActive(false);
    }



}
