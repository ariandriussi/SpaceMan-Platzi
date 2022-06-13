using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{

  

    public Text coinsTxt, scoreTxt, maxScoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.instance.currentGameState == GameState.inGame)
        {
            int coins = gameManager.instance.collectedObject;
            float score = 0;
            float maxScore = 0;

            coinsTxt.text = coins.ToString();
           scoreTxt.text = "score: " + score.ToString("f1");
            maxScoreTxt.text = "max score: " + maxScore.ToString("f1");
        }

        else if (gameManager.instance.currentGameState == GameState.gameOver)
        {
         
           
        }
        
    }
}
