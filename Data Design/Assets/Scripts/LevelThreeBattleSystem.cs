using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelThreeBattleSystem : MonoBehaviour
{


    public GameObject playerP;//4. so we make variables for the prefabs
    public GameObject enemyP;

    public Transform playerBattleStation;//5. we then make variables for where we want to spawn the prefabs which are the battle stations, we just use transform because we just need to get their locations and not Gameobject
    public Transform enemyBattleStation;

    UnitScript playerUnit;//8.we going to reference playerStart.GetComponent because we are going to aceess it to get health,etc
    UnitScript enemyUnit;

    public Text dialogueMessage;

    public BattleHUD enemyHUD;
    public BattleHUD playerHUD;

    public GameObject powerUp;

    public BattleStateTwo gameStateTwo;







    // Start is called before the first frame update
    void Start()
    {
        powerUp.SetActive(false);
        gameStateTwo = BattleStateTwo.START;//1.we have put our first state which is start
        StartCoroutine(SetUpBattlefield());//2. we gotta set up the battle system 16.put StartCouroutine
    }
    private void Update()
    {
        //Invoke("ActivatePowerUp", 5.0f); //the button us going to show after a few seconds

    }
    IEnumerator SetUpBattlefield() //14. we want to delay the time in which the system is going to load certain parts of the function using Courotines
    {
        GameObject playerStart = Instantiate(playerP, playerBattleStation); //3. Then in here we need to spawn our different units (instatiate the player prefab as a child of/on top of the battle station
        playerUnit = playerStart.GetComponent<UnitScript>();//7. after referecning it we then can get the unit component from that game object which is the player

        GameObject enemyStart = Instantiate(enemyP, enemyBattleStation);
        enemyUnit = enemyStart.GetComponent<UnitScript>();

        dialogueMessage.text = "a vicious " + enemyUnit.unitTitle + " is coming";//9. now we going to display the unit name to the player on the UI

        //6. we need to know what each unit (character) is at using the UI so we going to reference each unit

        playerHUD.SetHUD(playerUnit); //10.now we have the name and level on each HUD
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);//15. we are going to delay the time in which the sript is going to load the player's turn/the player game state
        gameStateTwo = BattleStateTwo.PLAYERSTURN;//11.Now we just need to put in some action and move onto the player's turn because we are done doing the start state
        PlayersTurn(); //12. we going to call out the player's turn function

    }
    IEnumerator PlayerFertlizing()
    {
        bool isDead = enemyUnit.TakeDamageForFertlizer(playerUnit.fertilzerDamage);//20. damage the enemy by changing the enemyUnit but we not going to affect the health drectly but we goin to create a function where the health is affected and use that instead

        enemyHUD.SetHealth(enemyUnit.currentHealth);//23. o after we have attacked the enemy we need to show that the enemy has taken damage so we change the slider in the HUD
        dialogueMessage.text = "Fertilizer is destroying possible bacteria infection"; //24.show the attack in the dialogue to show good feedback and communication

        yield return new WaitForSeconds(2f);

        if (isDead) //21. we need to check if enemy is dead
        {
            gameStateTwo = BattleStateTwo.WON; //25. the enemy is dead so that means we won
            EndtheBattle();
            SceneManager.LoadScene(2);
        }
        else
        {
            gameStateTwo = BattleStateTwo.ENEMYSTURN; //26.Enemy turn //22. and then change state based on the results 
            StartCoroutine(EnemysTurn()); //27. then we need to start enemy's turn after a few seconds
        }



    }
    IEnumerator Fungicide()
    {
        bool isDead = enemyUnit.TakeDamageForFungicide(playerUnit.fungicideDamage);//20. damage the enemy by changing the enemyUnit but we not going to affect the health drectly but we goin to create a function where the health is affected and use that instead

        enemyHUD.SetHealth(enemyUnit.currentHealth);//23. o after we have attacked the enemy we need to show that the enemy has taken damage so we change the slider in the HUD
        dialogueMessage.text = "The bacteria is being destroyed keep spraying the fungicide"; //24.show the attack in the dialogue to show good feedback and communication

        yield return new WaitForSeconds(2f);

        if (isDead) //21. we need to check if enemy is dead
        {
            gameStateTwo = BattleStateTwo.WON; //25. the enemy is dead so that means we won
            EndtheBattle();
            SceneManager.LoadScene(2);
        }
        else
        {
            gameStateTwo = BattleStateTwo.ENEMYSTURN; //26.Enemy turn //22. and then change state based on the results 
            StartCoroutine(EnemysTurn()); //27. then we need to start enemy's turn after a few seconds
        }



    }
    IEnumerator PowerUp()
    {



        playerUnit.PowerUp(10);
        playerHUD.SetHealth(playerUnit.currentHealth);

        dialogueMessage.text = "YOU HAVE POWERED UP!"; //24.show the attack in the dialogue to show good feedback and communication

        yield return new WaitForSeconds(2f);

        gameStateTwo = BattleStateTwo.ENEMYSTURN; //26.Enemy turn //22. and then change state based on the results 
        StartCoroutine(EnemysTurn()); //27. then we need to start enemy's turn after a few seconds




    }
    void ActivatePowerUp()
    {
        powerUp.SetActive(true);
    }
    void DeactivatePowerUp()
    {
        powerUp.SetActive(false);
    }
    IEnumerator EnemysTurn()
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
    public void OnFertilzeButton() //17. now we are going to put action in the buttons
    {
        if (gameStateTwo != BattleStateTwo.PLAYERSTURN)//18. we are going to check first if it is player's turn. so this line of code is basically saying if the game state is not the player's turn then dont do anything
            return;

        StartCoroutine(PlayerFertlizing());//19. but if it players turn then player should attack but they should be a pause in the duration of the attack

    }
    public void OnFungicideButton() //17. now we are going to put action in the buttons
    {
        if (gameStateTwo != BattleStateTwo.PLAYERSTURN)//18. we are going to check first if it is player's turn. so this line of code is basically saying if the game state is not the player's turn then dont do anything
            return;

        StartCoroutine(Fungicide());//19. but if it players turn then player should attack but they should be a pause in the duration of the attack

    }
    public void PowerUpButton() //17. now we are going to put action in the buttons
    {
        if (gameStateTwo != BattleStateTwo.PLAYERSTURN)//18. we are going to check first if it is player's turn. so this line of code is basically saying if the game state is not the player's turn then dont do anything
            return;

        StartCoroutine(PowerUp());//19. but if it players turn then player should attack but they should be a pause in the duration of the attack

    }

    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        bool isDead = enemyUnit.TakeDamageForFertlizer(playerUnit.fertilzerDamage);//20. damage the enemy by changing the enemyUnit but we not going to affect the health drectly but we goin to create a function where the health is affected and use that instead

        enemyHUD.SetHealth(enemyUnit.currentHealth);//23. o after we have attacked the enemy we need to show that the enemy has taken damage so we change the slider in the HUD
        dialogueMessage.text = "Fertilizer is destroying possible bacteria infection"; //24.show the attack in the dialogue to show good feedback and communication

        yield return new WaitForSeconds(2f);

        if (isDead) //21. we need to check if enemy is dead
        {
            gameStateTwo = BattleStateTwo.WON; //25. the enemy is dead so that means we won
            EndtheBattle();
            SceneManager.LoadScene(5);
        }
        else
        {
            gameStateTwo = BattleStateTwo.ENEMYSTURN; //26.Enemy turn //22. and then change state based on the results 
            StartCoroutine(EnemysTurn()); //27. then we need to start enemy's turn after a few seconds
        }

    }
}
