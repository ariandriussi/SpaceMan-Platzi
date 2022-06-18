using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    playerController controller;
  

    public Text coinsTxt, scoreTxt, maxScoreTxt, coinsDeadTxt, scoreDeadTxt;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.instance.currentGameState == GameState.inGame)
        {
            int coins = gameManager.instance.collectedObject;
            float score = controller.GetTravelledDistance();
            float maxScore = PlayerPrefs.GetFloat("maxscore", 0);

         
            


           
            coinsTxt.text = coins.ToString();
           scoreTxt.text = "score: " + score.ToString("f1");
            maxScoreTxt.text = "max score: " + maxScore.ToString("f1");
        }

        else if (gameManager.instance.currentGameState == GameState.gameOver)
        {
          
            coinsDeadTxt.text = coinsTxt.text;
            scoreDeadTxt.text = scoreTxt.text;

        }
        
    }
}
