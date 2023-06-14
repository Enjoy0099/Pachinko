using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    private GameManager gameManager_Script;

    private Transform myPos;

    private void Awake()
    {
        myPos = GetComponent<Transform>();
        gameManager_Script = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ball"))
        {
            
            switch (int.Parse(myPos.name.ToString()))
            {
                case 1:
                    gameManager_Script.Bowls[0]++;
                    gameManager_Script.collectedBalls++;
                    break;

                case 2:
                    gameManager_Script.Bowls[1]++;
                    gameManager_Script.collectedBalls++;
                    break;

                case 3:
                    gameManager_Script.Bowls[2]++;
                    gameManager_Script.collectedBalls++;
                    break;

                case 4:
                    gameManager_Script.Bowls[3]++;
                    gameManager_Script.collectedBalls++;
                    break;

                case 5:
                    gameManager_Script.Bowls[4]++;
                    gameManager_Script.collectedBalls++;
                    break;

                case 6:
                    gameManager_Script.Bowls[5]++;
                    gameManager_Script.collectedBalls++;
                    break;
            }
        }

        if(gameManager_Script.collectedBalls == gameManager_Script.totalBall)
        {
            gameManager_Script.FindScore();
        }
        
    }
}
