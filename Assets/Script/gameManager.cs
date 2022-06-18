using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    menu,
    inGame,
    gameOver,
    pause
}
public class gameManager : MonoBehaviour
{

    public GameState currentGameState = GameState.menu;

    public static gameManager instance;

    public int collectedObject = 0;

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
        if (Input.GetKeyDown(KeyCode.P) && currentGameState == GameState.inGame)
        {

            // Al tocar la P si el estado del juego está en inGame el estado de juego pasara a pause.
            PauseGame();
            
        } else if (Input.GetKeyDown(KeyCode.P) && currentGameState == GameState.pause)
        {
            // Lo mismo que el anterior pero a la inversa
            currentGameState=GameState.inGame;
            
            

        }

        if (gameManager.instance.currentGameState == GameState.inGame)
        {
            Time.timeScale = 1f;
           

        }
        else if (gameManager.instance.currentGameState == GameState.menu) 
        {
            Time.timeScale = 0;
            
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

    public void PauseGame()
    {
        SetGameState(GameState.pause);
    }

    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            MenuManager.instance.HideDeadMenu();

            MenuManager.instance.ShowMainMenu();

            MenuManager.instance.HideGameMenu();
           





            // colocar la lógica del menu
        } else if (newGameState == GameState.inGame)
        {

            MenuManager.instance.HideMainMenu();
            MenuManager.instance.HideDeadMenu();
            MenuManager.instance.ShowGameMenu();
            GetComponent<AudioSource>().Play();
            collectedObject = 0;




    LevelManager.instance.RemoveAllLevelBlock();
      
            Invoke(nameof(ReloadLevel), 0.1f);



        }
        else if (newGameState == GameState.gameOver)
        {
            // preparar el juego para el game over
            MenuManager.instance.ShowDeadMenu();
            


        }
        else if (newGameState == GameState.pause)
        {
            Time.timeScale = 0;
        }

     this.currentGameState = newGameState;


    }

    void ReloadLevel()
    {
        LevelManager.instance.GenerateInitiaBlock();
        controller.StartGame();
    }

    public void CollectObject(Collectable collectable)
    {
        collectedObject += collectable.value;
    }
}
