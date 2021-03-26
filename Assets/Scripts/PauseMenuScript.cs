﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuScript : MonoBehaviour{
    public static bool gameIsPaused=false;
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused){
               Resume();
            }
            else{
               Pause();
            }
        }
    }
    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale=1f;
        gameIsPaused=false;
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale=0f;
        gameIsPaused=true;
    }

    public void LoadMenu(){
        SceneManager.LoadScene(0);
        Time.timeScale=1f;
        // gameIsPaused=false;
    }

    public void QuitGame(){
        print("uiyhu7yh");
        Application.Quit();
    }
}
