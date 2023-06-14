using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private SpriteRenderer myImage;

    private void Awake()
    {
        myImage = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        setObstacle_Color();
        InvokeRepeating("setObstacle_Color", 0f, 1f);
    }

    public void setObstacle_Color()
    {
        myImage.color = new Color(Random.Range(0f, 1f), 
                                  Random.Range(0f, 1f), 
                                  Random.Range(0f, 1f), 
                                  Random.Range(0.2f, 1f));
    }
}
