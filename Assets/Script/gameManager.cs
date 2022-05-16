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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && currentGameState == GameState.menu)
        {
            StartGame();
        }

       else if (Input.GetKeyDown(KeyCode.Return) && currentGameState == GameState.inGame) 
        {
            BackToMenu();
        }

       if (Input.GetKeyDown(KeyCode.P) && currentGameState == GameState.gameOver)
       {
           BackToMenu();
       }


        
    }

    public void StartGame()
    {
        SetGameState(GameState.inGame);

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
