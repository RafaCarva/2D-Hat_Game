using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Lógica para ajustar a img ao canvas
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        Vector3 scaleTemp = GetComponentInChildren<Transform>().transform.localScale;

        float width = sprite.bounds.size.x;
        float height = sprite.bounds.size.y;
        float heightCamera = Camera.main.orthographicSize * 2.0f;
        float widthWorld = heightCamera / Screen.height * Screen.width;

        scaleTemp.x = widthWorld / width;

        transform.localScale = scaleTemp;     
    }

}
