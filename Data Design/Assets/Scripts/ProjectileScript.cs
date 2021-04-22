using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProjectileScript : MonoBehaviour
{
    public float projectielSpeed;
    public GameObject impactEffect;

    private Rigidbody2D rb;

    public Text dialogueMessage;

    UnitScript playerUnit;
    UnitScript enemyUnit;

    public BattleHUD enemyHUD;
    public BattleHUD playerHUD;

    public BattleStateTwo gameStateTwo;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * projectielSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(impactEffect, transform.position, Quaternion.identity);

        DamagePlayer();
       

    }
       IEnumerator DamagePlayer()
        {

        dialogueMessage.text = enemyUnit.unitTitle + " attacks!"; //30. if it is enemy's turn then player will take damage so add text

        yield return new WaitForSeconds(1f);//31. wait a few seconds before player takes damage

        bool isDead = playerUnit.TakeDamageEnemy(enemyUnit.enemyDamage); //32. we need to check if player has died and if not then its player's turn

        playerHUD.SetHealth(playerUnit.currentHealth);

        yield return new WaitForSeconds(1f);

        if (isDead) //33. determine player died and change game state
        {
            gameStateTwo = BattleStateTwo.LOST;
            EndtheBattle();
            SceneManager.LoadScene(3);
        }
        else
        {
            gameStateTwo = BattleStateTwo.PLAYERSTURN;
            PlayersTurn();

        }


    }
    void EndtheBattle()
    {
        if (gameStateTwo == BattleStateTwo.WON) //28. we then we going tocheck if the state is 'won' and if so then show text saying that player has won
        {
            dialogueMessage.text = "Plant you have WON the battle against the bacteria";
        }
        else if (gameStateTwo == BattleStateTwo.LOST)//29. but we have lost then show the text that you have lost
        {
            dialogueMessage.text = "The bacteria has infected you, Plant. You have died";
        }
    }
    void PlayersTurn()
    {
        dialogueMessage.text = "Player, please choose an action:";//13. now we need to tell the person playing the game that they can choose and action and this is going to happen on UI
    }
}

