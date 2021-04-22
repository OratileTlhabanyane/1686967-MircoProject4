using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public string unitTitle;
    public int unitLevel;

    public int fertilzerDamage;
    public int fungicideDamage;
    public int enemyDamage;

    public int maxHealth;
    public int currentHealth;

    public bool TakeDamageForFertlizer(int amountofDamage)//20.3 change void into boolean
    {
        currentHealth -= amountofDamage;  //20. 

        if (currentHealth <= 0)//20.1 so when current health reaches zero then we have died and we have to tell the battle system that this thing has dieedddd mahnn
            return true;
        else 
            return false;
    }//20.2 then we want it to return a tru oe false, true if unity has died and false if it hasnt and we do this by changing void function into a bool function
    public bool TakeDamageForFungicide(int amountofDamage)//20.3 change void into boolean
    {
        currentHealth -= amountofDamage;  //20. 

        if (currentHealth <= 0)//20.1 so when current health reaches zero then we have died and we have to tell the battle system that this thing has dieedddd mahnn
            return true;
        else
            return false;
    }
    public bool TakeDamageEnemy(int amountofDamage)//20.3 change void into boolean
    {
        currentHealth -= amountofDamage;  //20. 

        if (currentHealth <= 0)//20.1 so when current health reaches zero then we have died and we have to tell the battle system that this thing has dieedddd mahnn
            return true;
        else
            return false;
    }
    public void PowerUp( int powerup)
    {
        currentHealth += powerup;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }
}
