using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HatMove : MonoBehaviour
{
    [SerializeField] 
    private float speed;

    private GameController gameController;

    private void Start() {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
       DragTouch(); 
    }

    private void DragTouch()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && gameController.gameStarted)
        {
            // Guarda a posição do dedo na tela
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Aplica a posição no Hat
            transform.Translate(touchDeltaPosition.x * speed * Time.deltaTime, 0f, 0f);
        }
    }
}
