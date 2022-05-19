using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{

    public string modePause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        
            if (gameManager.instance.currentGameState == GameState.inGame)
            {
                Time.timeScale = 1f;
            modePause = "Disable";

            }
            else if (gameManager.instance.currentGameState == GameState.menu)
            {
                Time.timeScale = 0;
            modePause = "Enable";
        }
        }


 
}
