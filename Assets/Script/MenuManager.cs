using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    private playerController controller;

    public Canvas menuCanvas;
    public Canvas gameMenu;
    public Canvas deadMenu;

    public static MenuManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ShowMainMenu()
    {
    
        menuCanvas.enabled = true;
     
      
    }

    public void HideMainMenu()
    {
      
        menuCanvas.enabled = false;
      


    }

    public void ShowDeadMenu()
    {
     
            deadMenu.enabled = true;
        

       
    }

    public void HideDeadMenu()
    {

        deadMenu.enabled = false;



    }

    public void ShowGameMenu()
    {

        gameMenu.enabled = true;



    }

    public void HideGameMenu()
    {

        gameMenu.enabled = false;



    }



    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
    Application.Quit();
#endif
    }



    // Start is called before the first frame update
    void Start()
    {
        deadMenu.enabled = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
