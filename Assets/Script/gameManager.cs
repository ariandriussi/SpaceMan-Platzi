using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    menu,
    inGame,
    gameOver
}
public class gameManager : MonoBehaviour
{

    public GameState currentGameState = GameState.menu;

    public static gameManager instance;

    private playerController controller;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && currentGameState == GameState.gameOver)
        {
            StartGame();
        }

        else if (Input.GetKeyDown(KeyCode.P) && currentGameState == GameState.inGame)
        {
            BackToMenu();
        } else if (Input.GetKeyDown(KeyCode.P) && currentGameState == GameState.menu)
        {
            SetGameState(GameState.inGame);
        }





    }

    public void StartGame()
    {
      
        SetGameState(GameState.inGame);
        controller.StartGame();
        


    }

    public void EndGame()
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        
        SetGameState(GameState.menu);
       
    }

    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            // colocar la lógica del menu
        } else if (newGameState == GameState.inGame)
        {
            
        }
        else if (newGameState == GameState.gameOver)
        {
            // preparar el juego para el game over

        }

     this.currentGameState = newGameState;
    }
}
