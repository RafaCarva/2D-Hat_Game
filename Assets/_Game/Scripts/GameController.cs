using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int score;
    public float currentTime;
    [SerializeField] private float startTime;

    public bool gameStarted;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        currentTime = startTime;
        gameStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        CountDownTime();
    }

    public void CountDownTime()
    {
        if(currentTime > 0f && gameStarted)
        {
            // Vai decrementar 1 por segundo.
            currentTime -= Time.deltaTime;
            // COnverte o float para int (para não exibir as casas decimais).
            float currentTimeToInt = Mathf.RoundToInt(currentTime);
            Debug.Log(currentTimeToInt);    
        }
        else
        {
            gameStarted = false;
            currentTime = 0f;
            return;
        }

        
    }
}
