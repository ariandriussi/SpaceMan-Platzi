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
        GenerateInitiaBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLevelBlock()
    {
        int ramdomIdx = Random.Range(0, allTheLevelBlock.Count);

        LevelBlock block;
        Vector3 spawnPosition = Vector3.zero;

        if (currentLevelBlocks.Count == 0)
        {
            block = Instantiate(allTheLevelBlock[0]);
            spawnPosition = levelStartPosition.position;
        }
        else
        {
            block = Instantiate(allTheLevelBlock[ramdomIdx]);
            spawnPosition = currentLevelBlocks[currentLevelBlocks.Count - 1].EndPoint.position;
        }

        block.transform.SetParent(this.transform, false);

        Vector3 correction = new Vector3(spawnPosition.x - block.startPoint.position.x,
            spawnPosition.y - block.startPoint.position.y, 0);

        block.transform.position = correction;
        currentLevelBlocks.Add(block);
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
