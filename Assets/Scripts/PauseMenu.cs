using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public GameObject Pausemenu, PauseButton;

   public void Pause(){
       Pausemenu.SetActive (true); //pause menu shown
       PauseButton.SetActive(false); //pause button unclickable
       Time.timeScale = 0;
   }
   
   public void Resume(){
       Pausemenu.SetActive (false); //opposite to pause
       PauseButton.SetActive(true);
       Time.timeScale = 1;
   }

   public void LoadMenu(){
    Time.timeScale = 1f;
    Application.LoadLevel("MainMenu");
    
   }

   public void QuitGame(){
    Debug.Log("quit menu");
    Application.Quit();
   }
   }
