using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitZone : MonoBehaviour
{

    public int time = 5;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
            {

            Invoke("Destroy", time);
        }

            Debug.Log("debemos destruir los bloques anteriores");

        
    }

     void Destroy()
    {

        LevelManager.instance.RemoveLevelBlock();
        LevelManager.instance.AddLevelBlock();
    }
}
