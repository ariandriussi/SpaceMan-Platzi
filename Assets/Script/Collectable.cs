using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    healthPotion,
    manaPotion,
    money
}
public class Collectable : MonoBehaviour
{

    public CollectableType type = CollectableType.money;
    
    private SpriteRenderer sprite;
    private CircleCollider2D circleCollider;

   public bool hasBeenCollected = false;

    public int value = 1;


    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

 
   public void Show()
    {
        sprite.enabled = true;
        circleCollider.enabled = true;
        hasBeenCollected = false;
    }

    void Hide()
    {
        sprite.enabled = false;
        circleCollider.enabled =false;
        hasBeenCollected = true;
    }

   public void Collect()
    {
        Hide();
        hasBeenCollected = true;

        switch (this.type)
        {
            case CollectableType.money:

                gameManager.instance.CollectObject(this);
                break;

                case CollectableType.manaPotion:
                break;

            case CollectableType.healthPotion:
                break;
        }
    }

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" )
        {
            Collect();
        }
    }
}
