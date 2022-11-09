using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int score;
    public float currentTime;
    [SerializeField] private float startTime;

    public bool gameStarted;

    private UIController uiController;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        uiController = FindObjectOfType<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvokeCountDownTime()
    {
        InvokeRepeating("CountDownTime", 1f, 1f);
    }

    public void StartGame()
    {
        score = 0;
        currentTime = startTime;
        gameStarted = true;
        InvokeCountDownTime();
    }

    public void BackMailMenu()
    {
        score = 0;
        currentTime = 0f;
        gameStarted = false;
        InvokeCountDownTime();  
    }


    public void CountDownTime()
    {
        if(currentTime > 0f && gameStarted)
        {
            // Vai decrementar 1 por segundo.
            currentTime -= 1f;
        }
        else
        {
            uiController.panelGameOver.gameObject.SetActive(true);
            uiController.panelGame.gameObject.SetActive(false);
            gameStarted = false;
            currentTime = 0f;
            CancelInvoke("CountdownTime");
            return;
        }

        
    }
}
