using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum barType
{
    healtBar,
    manaBar
}
public class PlayerBar : MonoBehaviour
{

    private Slider barSlider;


    public barType type;

    // Start is called before the first frame update
    void Start()
    {
        barSlider = GetComponent<Slider>();

        switch (type)
        {
            case barType.healtBar:
                barSlider.maxValue = playerController.INITIAL_HEALTH;

                break;
                case barType.manaBar:
                barSlider.maxValue = playerController.INITIAL_MANA;

                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case barType.healtBar:
                barSlider.value = GameObject.Find("Player").GetComponent<playerController>().GetHealth();
                break;

            case barType.manaBar:
                barSlider.value = GameObject.Find("Player").GetComponent<playerController>().GetMana();
                break;
        }

       

        
    }
}
