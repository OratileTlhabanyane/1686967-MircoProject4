using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDragController : MonoBehaviour
{

    private bool isDragging = false;
    public Rigidbody2D rb;
    public float unhookTime = 0.15f;
    public Rigidbody2D hook;
    public GameObject nextPlayer;

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            rb.position = mousePos; //
        }
        //inn order for the spring joint not to distrubed the dragging when the mouse is pressed then we have to change the rb to kinematic 
    }
    private void OnMouseDown()
    {
        isDragging = true;
        rb.isKinematic = true;
        //for diffrent levels to be harder yoou can mass on the woods higher so that they are harder to knockdown
    }
    private void OnMouseUp()
    {
        isDragging = false;
        rb.isKinematic = false;
        StartCoroutine(Unhook()); //couroutine a methods used in order to call a function in a "non chronological" order way 
        //cant just call the unhook function for the delay because i used the coroutine( the ienumerator) 
    }


    IEnumerator Unhook()
    {
        yield return new WaitForSeconds(unhookTime);  //it will work after 0.15f seconds after unhook or releasing of the button down  
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
        yield return new WaitForSeconds(2f);
        if (nextPlayer != null)
        {

            nextPlayer.SetActive(true); // you have basically lost cause theres no scene loading or ball respawining 
        }

        else
        {
            BarsScript.barsActive = 0;
            SceneManager.LoadScene(3);//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //either have a next level scene or gameover scene bu this code is resetting the code so you reset level if the player cannot get a certain amaount of scores
        }
    }
}
