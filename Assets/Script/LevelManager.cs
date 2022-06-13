using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;


    public List<LevelBlock> allTheLevelBlock = new List<LevelBlock>();
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

     int randomIdx, blocklast;

    public void AddLevelBlock()
    {
      
        
        while (blocklast == randomIdx)
        {
            randomIdx = Random.Range(1, allTheLevelBlock.Count);
        }
        
        LevelBlock newBlock;
        Vector3 currentEndPosition;

        if (currentLevelBlocks.Count == 0)
        {
            newBlock = Instantiate(allTheLevelBlock[0]);
            currentEndPosition = levelStartPosition.position;
        }
        else
        {
            newBlock = Instantiate(allTheLevelBlock[randomIdx]);
            currentEndPosition = currentLevelBlocks[currentLevelBlocks.Count - 1].EndPoint.position;
        }

        newBlock.transform.SetParent(this.transform, false);
        newBlock.transform.position = currentEndPosition - newBlock.startPoint.position;
        //SpawnCoins(currentEndPosition);
        currentLevelBlocks.Add(newBlock);

        blocklast = randomIdx;

    }

    public void RemoveLevelBlock()
    {
        LevelBlock oldBlock = currentLevelBlocks[0];
        currentLevelBlocks.Remove(oldBlock);
        Destroy(oldBlock.gameObject);
    }

    public void RemoveAllLevelBlock()
    {
        while (currentLevelBlocks.Count > 0)
        {
            RemoveLevelBlock();
        }
    }

    public void GenerateInitiaBlock()
    {
        if (gameManager.instance.currentGameState == GameState.inGame)
        {
            for (int i = 0; i < 3; i++)
            {
                AddLevelBlock();
            }
        }
        
    }

 




  //  void SpawnCoins(Vector3 spawn)
  //  {
  //      int randomGen = Random.Range(1, 10);
  //      Vector3 spawnCoin = spawn;
  //
  //      for (int i = 0; i < randomGen; i++)
  //      {
  //          Instantiate (coinsppp);
  //          spawnCoin = new Vector3(
  //              spawnCoin.x + Random.Range(5, 10),
  //              spawnCoin.y + Random.Range(-0.077f, 3.3f),
  //              0
  //          );
  //          coinsppp.transform.SetParent(this.transform, false);
  //          coinsppp.transform.position = spawnCoin;
  //          if (spawnCoin.y > 10 || spawnCoin.y < -5)
  //          {
  //              spawnCoin.y = 0;
  //          }
  //      }
  //  }

}

