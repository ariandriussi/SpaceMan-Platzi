using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    menu,
    inGame,
    gameOver
}
public class GameManager : MonoBehaviour
{

    public GameState currentGameState = GameState.menu;

    public static GameManager instance;

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
        
    }

    public void StartGame()
    {

    }

    public void EndGame()
    {

    }

    public void BackToMenu()
    {

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
