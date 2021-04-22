using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarsScript : MonoBehaviour
{
    public float attempts = 4f;
    public GameObject destroyEffect;
    public static int barsActive = 0;
    public static int barsActive1 = 4;


    public GameObject fungicideButtton;
    public GameObject fertilizerButtton;
    public GameObject powerUpButton;


    // Start is called before the first frame update
    void Start()
    {
        barsActive++;
        barsActive1 = barsActive1 + 4;
        fungicideButtton.SetActive(false);
        fertilizerButtton.SetActive(false);


    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.relativeVelocity.magnitude > attempts)
        {
            Perish();
            fungicideButtton.SetActive(true);
            fertilizerButtton.SetActive(true);
            powerUpButton.SetActive(true);

        }

    }
    void Perish()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);

        barsActive--;


        if (barsActive <= 0)
        {
           // SceneManager.LoadScene(3);//make buttons appear
        }

        barsActive1 = barsActive1 - 4;
        if (barsActive1 <= 0)
        {

            SceneManager.LoadScene(4); //make buttons appear
        }
        Destroy(gameObject);
    }
}
