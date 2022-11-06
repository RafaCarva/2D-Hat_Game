using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTrigger : MonoBehaviour
{
    // Esse GameController é uma instância do meu script
    private GameController gameController;

    private void Start() 
    {
        // Popula o gameCOntroller com o G.O da cena.
        gameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D target) 
    {
        if(target.gameObject.CompareTag("Destroyer"))
        {
            Destroy(this.gameObject);
        }
        else if(target.gameObject.CompareTag("Point"))
        {
            gameController.score += 1;
            Debug.Log("Pontos: " + gameController.score);
        }
    }
}
