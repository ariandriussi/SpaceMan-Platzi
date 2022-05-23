﻿using System.Collections;
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
        int rand_i = Random.Range(0, allTheLevelBlock.Count);
        LevelBlock newBlock;
        Vector3 currentEndPosition;

        if (currentLevelBlocks.Count == 0)
        {
            newBlock = Instantiate(allTheLevelBlock[0]);
            currentEndPosition = levelStartPosition.position;
        }
        else
        {
            newBlock = Instantiate(allTheLevelBlock[rand_i]);
            currentEndPosition = currentLevelBlocks[currentLevelBlocks.Count - 1].EndPoint.position;
        }

        newBlock.transform.SetParent(this.transform, false);
        newBlock.transform.position = currentEndPosition - newBlock.startPoint.position;
        currentLevelBlocks.Add(newBlock);
    }

    public void RemoveLevelBlock()
    {
        
    }

    public void RemoveAllLevelBlock()
    {

    }

    public void GenerateInitiaBlock()
    {
        for (int i = 0; i < 4; i++)
        {
           AddLevelBlock();
        }
    }
}
