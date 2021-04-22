using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneScript : MonoBehaviour
{
    public Button Play_BT;
    public Button Quit_BT;
    


    // Update is called once per frame
    void Update()
    {
        // scene one is basically saying the first scene that shows should after menu which the where the setting will appear

    }
    public void Open()
    {
        SceneManager.LoadScene(0);
    }
    public void Start_BT()
    {
        SceneManager.LoadScene(1);
    }
   

 
    public void Menu ()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit_Game()
    {
        Application.Quit();

    }



}