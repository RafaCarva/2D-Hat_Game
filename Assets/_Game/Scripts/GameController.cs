using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int highScore;
    [HideInInspector] public int score;
    private float currentTime;
    [SerializeField] private float startTime;

    [HideInInspector] public bool gameStarted;

    private UIController uiController;

    private SpawnControler spawnControler;

    [SerializeField] private Transform player;
    private Vector2 playerPosition; 

    private void Awake() 
    {
        DeleteHighscore();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        uiController = FindObjectOfType<UIController>();
        spawnControler = FindObjectOfType<SpawnControler>();
        highScore = GetScore();
        uiController.txtTime.text = startTime.ToString();
        playerPosition = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyAllBalls()
    {
        foreach (Transform child in spawnControler.allBallsParent)
        {
          Destroy(child.gameObject);  
        }
        
    }

    public void SaveScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);  
        }
        else 
        {
            return;
        }
    }

    public int GetScore()
    {
        int highScore = PlayerPrefs.GetInt("highScore");
        return highScore;
    }

    public void DeleteHighscore()
    {
        PlayerPrefs.DeleteKey("highScore");
    }

    public void InvokeCountDownTime()
    {
        InvokeRepeating("CountDownTime", 0f, 1f);
    }

    public void StartGame()
    {
        score = 0;
        currentTime = startTime;
        gameStarted = true;
        InvokeCountDownTime();
        player.position = playerPosition;
        uiController.txtTime.text = currentTime.ToString();
    }

    public void BackMailMenu()
    {
        score = 0;
        currentTime = 0f;
        gameStarted = false;
        InvokeCountDownTime();  
        player.position = playerPosition;
    }


    public void CountDownTime()
    {
        uiController.txtTime.text = currentTime.ToString();

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
            SaveScore();
            currentTime = 0f;
            CancelInvoke("CountdownTime");
            return;
        }

        
    }
}
