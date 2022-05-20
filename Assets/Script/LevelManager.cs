using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;


    public List<LevelBlock> allTheLevelBlock = new List<LevelBlock> ();
    public List<LevelBlock> currentLevelBlocks = new List<LevelBlock>();

    public Transform levelStartPosition;
    // Start is called before the first frame update


    void Awake()
    {
      if (instance == null)
        {
            instance = this;
        }  
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLevelBlock()
    {

    }

    public void RemoveLevelBlock()
    {

    }

    public void RemoveAllLevelBlock()
    {

    }

    public void GenerateInitiaBlock()
    {
        for (int i = 0; i < 2; i++)
        {
           AddLevelBlock();
        }
    }
}
