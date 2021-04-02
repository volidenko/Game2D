using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenuScript : MonoBehaviour{
    public static bool gameIsPaused=false;
    public GameObject pauseMenuUI;
    PlayerController2D plCon;
    public Text text;
    public Text hStext;
    void Start(){
        plCon=GameObject.Find("Player").GetComponent<PlayerController2D>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused){
               Resume();
            }
            else{
               Pause();
            }
        }
        text.text="Score "+plCon.PlayerScore.ToString();
        //hStext.text="Hi-score "+plCon.HiScoreScr.ToString();
    }
    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale=1f;
        gameIsPaused=false;
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale=0f;
        gameIsPaused=true;
        FindObjectOfType<AudioManager>().Pause("Theme");
        FindObjectOfType<AudioManager>().Play("Regret");
    }

    public void LoadMenu(){
        SceneManager.LoadScene(0);
        Time.timeScale=1f;
        FindObjectOfType<AudioManager>().Play("Theme");
        // gameIsPaused=false;
    }

    public void QuitGame(){
        //print("uiyhu7yh");
        Application.Quit();
    }
}
