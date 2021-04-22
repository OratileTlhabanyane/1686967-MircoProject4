using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Slider healthSlider;

    public void SetHUD(UnitScript unit) //1.create a function that is going to update these UI elements and we going to call it in our battle system script
    {
        nameText.text = unit.unitTitle; //2.
        levelText.text = "Level" + unit.unitLevel; //3.
        healthSlider.maxValue = unit.maxHealth; //4.
        healthSlider.value = unit.currentHealth; //5.

    }

   public void SetHealth (int health) //6.going to create a function that will update the health whenever player gets damaged or whatever.
    {
        healthSlider.value = health;
    }
}


//side note, if you trying to get all information from another script to use it in another function in a new script just say public void NameOfFunction(ScriptA scriptA){}

