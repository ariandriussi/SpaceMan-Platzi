using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    healthPotion,
    manaPotion,
    money,
    deaPotion
}
public class Collectable : MonoBehaviour
{

    public CollectableType type = CollectableType.money;
    
    private SpriteRenderer sprite;
    private CircleCollider2D circleCollider;

   public bool hasBeenCollected = false;

    public int value = 1;

    GameObject player;


    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        player = GameObject.Find("Player");
    }


    public void Show()
    {
        sprite.enabled = true;
        circleCollider.enabled = true;
        hasBeenCollected = false;
    }

   public void Hide()
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
                GetComponent<AudioSource>().Play();
                break;

                case CollectableType.manaPotion:

          
                player.GetComponent<playerController>().CollectableMana(this.value);

                break;

            case CollectableType.healthPotion:

                player.GetComponent<playerController>().CollectableHealth(this.value);
                break;

            case CollectableType.deaPotion:
                player.GetComponent<playerController>().Die();
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
